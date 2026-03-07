import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef, PLATFORM_ID, inject, signal } from '@angular/core';
import { Location, isPlatformBrowser } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { LegacyService } from '../../services/legacy.service';
import { LegacyRecipeDetail } from '../../models/legacy-recipe';

@Component({
  selector: 'app-legacy-detail',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './legacy-detail.html',
  styleUrl: './legacy-detail.css'
})
export class LegacyDetailComponent implements OnInit, AfterViewInit, OnDestroy {
  recipe = signal<LegacyRecipeDetail | null>(null);
  titleStuck = signal(false);

  @ViewChild('recipeHeader') recipeHeader!: ElementRef;
  private observer!: IntersectionObserver;
  private platformId = inject(PLATFORM_ID);
  private legacyService = inject(LegacyService);

  constructor(private route: ActivatedRoute, private location: Location) {}

  goBack() {
    this.legacyService.shouldRestore = true;
    this.location.back();
  }

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.legacyService.getById(id).subscribe(recipe => this.recipe.set(recipe));
    }
  }

  ngAfterViewInit() {
    if (isPlatformBrowser(this.platformId) && this.recipeHeader) {
      this.observer = new IntersectionObserver(
        ([entry]) => { this.titleStuck.set(!entry.isIntersecting); },
        { threshold: 0 }
      );
      this.observer.observe(this.recipeHeader.nativeElement);
    }
  }

  ngOnDestroy() {
    this.observer?.disconnect();
  }
}
