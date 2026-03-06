import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe, RecipeSummary } from '../models/recipe';
import { API_BASE_URL } from './api-base';

@Injectable({ providedIn: 'root' })
export class RecipeService {
  private http = inject(HttpClient);
  private base = inject(API_BASE_URL);

  getAll(): Observable<RecipeSummary[]> {
    return this.http.get<RecipeSummary[]>(`${this.base}/api/recipes`);
  }

  getBySlug(slug: string): Observable<Recipe> {
    return this.http.get<Recipe>(`${this.base}/api/recipes/${slug}`);
  }
}
