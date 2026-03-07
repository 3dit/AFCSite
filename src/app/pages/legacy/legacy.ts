import { Component, inject, OnInit, OnDestroy, AfterViewInit, PLATFORM_ID, signal } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { LegacyService } from '../../services/legacy.service';
import { LegacyRecipe } from '../../models/legacy-recipe';

@Component({
  selector: 'app-legacy',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './legacy.html',
  styleUrl: './legacy.css'
})
export class LegacyComponent implements OnInit, AfterViewInit, OnDestroy {
  recipes = signal<LegacyRecipe[]>([]);
  loading = signal(true);
  loadingMore = signal(false);
  hasMore = signal(false);

  private skip = 0;
  private readonly pageSize = 20;
  private restoreScroll = 0;

  private legacyService = inject(LegacyService);
  private platformId = inject(PLATFORM_ID);

  ngOnInit() {
    const cache = this.legacyService.cache;

    if (this.legacyService.shouldRestore && cache) {
      this.legacyService.shouldRestore = false;
      this.recipes.set(cache.recipes);
      this.skip = cache.skip;
      this.hasMore.set(cache.hasMore);
      this.restoreScroll = cache.scrollY;
      this.loading.set(false);
    } else {
      this.legacyService.clearCache();
      this.legacyService.getAll(0).subscribe({
        next: recipes => {
          this.recipes.set(recipes);
          this.skip = recipes.length;
          this.hasMore.set(recipes.length === this.pageSize);
          this.loading.set(false);
        },
        error: () => this.loading.set(false),
      });
    }
  }

  ngAfterViewInit() {
    if (this.restoreScroll > 0 && isPlatformBrowser(this.platformId)) {
      setTimeout(() => window.scrollTo(0, this.restoreScroll), 0);
    }
  }

  ngOnDestroy() {
    const scrollY = isPlatformBrowser(this.platformId) ? window.scrollY : 0;
    this.legacyService.setCache(this.recipes(), this.skip, this.hasMore(), scrollY);
  }

  loadMore() {
    this.loadingMore.set(true);
    this.legacyService.getAll(this.skip).subscribe({
      next: recipes => {
        this.recipes.update(current => [...current, ...recipes]);
        this.skip += recipes.length;
        this.hasMore.set(recipes.length === this.pageSize);
        this.loadingMore.set(false);
      },
      error: () => this.loadingMore.set(false),
    });
  }
}
