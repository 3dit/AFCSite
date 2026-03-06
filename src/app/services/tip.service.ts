import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Guide, GuideSummary } from '../models/guide';
import { API_BASE_URL } from './api-base';

@Injectable({ providedIn: 'root' })
export class TipService {
  private http = inject(HttpClient);
  private base = inject(API_BASE_URL);

  getAll(): Observable<GuideSummary[]> {
    return this.http.get<GuideSummary[]>(`${this.base}/api/tips`);
  }

  getBySlug(slug: string): Observable<Guide> {
    return this.http.get<Guide>(`${this.base}/api/tips/${slug}`);
  }
}
