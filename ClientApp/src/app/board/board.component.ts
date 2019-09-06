import { Component, OnInit, Input } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ColumnService } from "../services/column.service";
import { Column } from "../models/column.model";
import { Board } from "../models/board.model";
import { BoardService } from "../services/board.service";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { ColumnModalComponent } from "../column-modal/column-modal.component";

@Component({
  selector: "app-board",
  templateUrl: "./board.component.html",
  styleUrls: ["./board.component.css"]
})
export class BoardComponent implements OnInit {
  board: Board;
  columns: Column[];

  constructor(
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private columnService: ColumnService,
    private boardService: BoardService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params["id"];

      this.boardService.get(id).subscribe(board => (this.board = board));

      this.columnService
        .getByBoardId(id)
        .subscribe(columns => (this.columns = columns));
    });
  }

  createColumn() {
    const modalRef = this.modalService.open(ColumnModalComponent);
    modalRef.result.then(result => {
      var column = result as Column;
      this.columnService.create(column, this.board.id).subscribe(createdColumn => {
        this.columns.push(createdColumn);
      })
    });
  }
}
