import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Board } from "../models/board.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class BoardService {
  private url = "/api/boards";

  constructor(private http: HttpClient) {}

  create(board: Board): Observable<Board> {
    return this.http.post<Board>(this.url, board);
  }

  getAll(): Observable<Board[]> {
    return this.http.get<Board[]>(this.url);
  }

  get(id: number): Observable<Board> {
    return this.http.get<Board>(`${this.url}/${id}`);
  }
}
