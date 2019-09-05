import { Component, OnInit } from "@angular/core";
import { BoardService } from "../services/board.service";
import { Board } from "../models/board.model";

@Component({
  selector: "app-boards-list",
  templateUrl: "./boards-list.component.html",
  styleUrls: ["./boards-list.component.css"]
})
export class BoardsListComponent implements OnInit {
  boards: Board[];

  constructor(private boardService: BoardService) {}

  ngOnInit() {
    this.boardService.getAll().subscribe(boards => (this.boards = boards));
  }
}
