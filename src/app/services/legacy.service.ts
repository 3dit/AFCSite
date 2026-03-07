import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LegacyRecipe, LegacyRecipeDetail } from '../models/legacy-recipe';
import { API_BASE_URL } from './api-base';

@Injectable({ providedIn: 'root' })
export class LegacyService {
  private http = inject(HttpClient);
  private base = inject(API_BASE_URL);

  getAll(): Observable<LegacyRecipe[]> {
    return this.http.get<LegacyRecipe[]>(`${this.base}/api/legacy`);
  }

  getById(id: number): Observable<LegacyRecipeDetail> {
    return this.http.get<LegacyRecipeDetail>(`${this.base}/api/legacy/${id}`);
  }
}
