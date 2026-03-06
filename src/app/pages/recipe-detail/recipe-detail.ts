import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ElementRef, PLATFORM_ID, inject, signal } from '@angular/core';
import { Location, isPlatformBrowser } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { RecipeService } from '../../services/recipe.service';
import { Recipe } from '../../models/recipe';

@Component({
  selector: 'app-recipe-detail',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './recipe-detail.html',
  styleUrl: './recipe-detail.css'
})
export class RecipeDetailComponent implements OnInit, AfterViewInit, OnDestroy {
  recipe = signal<Recipe | null>(null);
  titleStuck = signal(false);

  @ViewChild('recipeHeader') recipeHeader!: ElementRef;
  private observer!: IntersectionObserver;
  private platformId = inject(PLATFORM_ID);
  private recipeService = inject(RecipeService);

  constructor(private route: ActivatedRoute, private location: Location) {}

  goBack() {
    this.location.back();
  }

  ngOnInit() {
    const slug = this.route.snapshot.paramMap.get('slug');
    if (slug) {
      this.recipeService.getBySlug(slug).subscribe(recipe => this.recipe.set(recipe));
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
