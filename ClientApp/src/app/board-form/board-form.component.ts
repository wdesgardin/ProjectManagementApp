import { Component, OnInit } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Board } from "../models/board.model";
import { BoardService } from "../services/board.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-board-form",
  templateUrl: "./board-form.component.html",
  styleUrls: ["./board-form.component.css"]
})
export class BoardFormComponent implements OnInit {
  board: Board = {
    name: "",
    description: ""
  };
  constructor(private boardService: BoardService, private router: Router) {}

  ngOnInit() {}

  onSubmit() {
    this.boardService
      .create(this.board)
      .subscribe(() => this.router.navigateByUrl("/boards"));
  }
}
