import { Component, OnInit, EventEmitter } from "@angular/core";
import { Card } from "../models/card.model";
import { CardService } from "../services/card.service";

@Component({
  selector: "app-card-form",
  templateUrl: "./card-form.component.html",
  styleUrls: ["./card-form.component.css"]
})
export class CardFormComponent implements OnInit {
  card: Card = {
    content: ''
  };
  canceled: EventEmitter<void> = new EventEmitter();
  submitted: EventEmitter<Card> = new EventEmitter<Card>();

  constructor() {}

  ngOnInit() {}

  cancel() {
    this.canceled.emit();
  }

  submit() {
    this.submitted.emit(this.card);
  }
}
