import { Component, OnInit, Input } from "@angular/core";
import { Column } from "../models/column.model";

@Component({
  selector: "app-column",
  templateUrl: "./column.component.html",
  styleUrls: ["./column.component.css"]
})
export class ColumnComponent implements OnInit {
  @Input("column") column: Column;
  
  constructor() {
    console.log(this.column);
  }

  ngOnInit() {}
}
