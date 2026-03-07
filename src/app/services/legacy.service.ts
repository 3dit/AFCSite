import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LegacyRecipe, LegacyRecipeDetail } from '../models/legacy-recipe';
import { API_BASE_URL } from './api-base';

export interface LegacyListCache {
  recipes: LegacyRecipe[];
  skip: number;
  hasMore: boolean;
  scrollY: number;
}

@Injectable({ providedIn: 'root' })
export class LegacyService {
  private http = inject(HttpClient);
  private base = inject(API_BASE_URL);

  private _cache: LegacyListCache | null = null;
  get cache(): LegacyListCache | null { return this._cache; }

  shouldRestore = false;

  setCache(recipes: LegacyRecipe[], skip: number, hasMore: boolean, scrollY: number) {
    this._cache = { recipes, skip, hasMore, scrollY };
  }

  clearCache() { this._cache = null; }

  getAll(skip = 0): Observable<LegacyRecipe[]> {
    return this.http.get<LegacyRecipe[]>(`${this.base}/api/legacy?skip=${skip}`);
  }

  getById(id: number): Observable<LegacyRecipeDetail> {
    return this.http.get<LegacyRecipeDetail>(`${this.base}/api/legacy/${id}`);
  }
}
