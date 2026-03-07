import { Component, inject, OnInit, signal } from '@angular/core';
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
export class LegacyComponent implements OnInit {
  recipes = signal<LegacyRecipe[]>([]);
  loading = signal(true);

  private legacyService = inject(LegacyService);

  ngOnInit() {
    this.legacyService.getAll().subscribe({
      next: recipes => {
        this.recipes.set(recipes);
        this.loading.set(false);
      },
      error: () => this.loading.set(false),
    });
  }
}
