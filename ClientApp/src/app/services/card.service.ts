import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../models/card.model';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  constructor(private http: HttpClient) { }

  getByColumnId(columnId: number): Observable<Card[]> {
    return this.http.get<Card[]>(`/api/boards/columns/${columnId}/cards`);
  }

  create(card: Card, columnId: number) : Observable<Card> {
    return this.http.post<Card>(`/api/boards/columns/${columnId}/cards`, card);
  }
}
