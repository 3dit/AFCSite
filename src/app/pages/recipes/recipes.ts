import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from '../../components/sidebar/sidebar';
import { RecipeService } from '../../services/recipe.service';
import { RecipeSummary } from '../../models/recipe';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [RouterLink, SidebarComponent],
  templateUrl: './recipes.html',
  styleUrl: './recipes.css'
})
export class RecipesComponent implements OnInit {
  filters = ['All', 'Dairy-Free', 'Gluten-Free', 'Nut-Free', 'Soy-Free', 'Egg-Free', 'Top-8 Free'];
  activeFilter = signal('All');
  recipes = signal<RecipeSummary[]>([]);

  private recipeService = inject(RecipeService);

  filteredRecipes = computed(() => {
    if (this.activeFilter() === 'All') return this.recipes();
    return this.recipes().filter(r => r.category === this.activeFilter());
  });

  ngOnInit() {
    this.recipeService.getAll().subscribe(recipes => this.recipes.set(recipes));
  }

  setFilter(filter: string) {
    this.activeFilter.set(filter);
  }
}
