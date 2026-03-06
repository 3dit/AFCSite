import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', loadComponent: () => import('./pages/home/home').then(m => m.HomeComponent) },
  { path: 'recipes', loadComponent: () => import('./pages/recipes/recipes').then(m => m.RecipesComponent) },
  { path: 'recipes/:slug', loadComponent: () => import('./pages/recipe-detail/recipe-detail').then(m => m.RecipeDetailComponent) },
  { path: 'tips', loadComponent: () => import('./pages/tips/tips').then(m => m.TipsComponent) },
  { path: 'meal-planning', loadComponent: () => import('./pages/meal-planning/meal-planning').then(m => m.MealPlanningComponent) },
  { path: 'about', loadComponent: () => import('./pages/about/about').then(m => m.AboutComponent) },
  { path: 'contact', loadComponent: () => import('./pages/contact/contact').then(m => m.ContactComponent) },
  { path: '**', redirectTo: '' }
];
