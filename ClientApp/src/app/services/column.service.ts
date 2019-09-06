import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Column } from "../models/column.model";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class ColumnService {
  constructor(private http: HttpClient) {}

  getByBoardId(boardId: number): Observable<Column[]> {
    return this.http.get<Column[]>(`/api/boards/${boardId}/columns`);
  }

  create(column: Column, boardId: number) {
    return this.http.post<Column>(`/api/boards/${boardId}/columns`, column);
  }
}
