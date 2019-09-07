import {
  Component,
  OnInit,
  Input,
  ViewChild,
  ViewContainerRef,
  ComponentFactoryResolver,
  ComponentRef
} from "@angular/core";
import { Column } from "../models/column.model";
import { CardFormComponent } from "../card-form/card-form.component";
import { Card } from "../models/card.model";
import { CardService } from "../services/card.service";
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem
} from "@angular/cdk/drag-drop";

@Component({
  selector: "app-column",
  templateUrl: "./column.component.html",
  styleUrls: ["./column.component.css"]
})
export class ColumnComponent implements OnInit {
  @Input("column") column: Column;
  cards: Card[] = [];

  @ViewChild("formContainer", { static: true, read: ViewContainerRef })
  container: ViewContainerRef;
  cardForm: ComponentRef<CardFormComponent>;

  constructor(
    private componentFactoryResolver: ComponentFactoryResolver,
    private cardService: CardService
  ) {}

  ngOnInit() {
    this.cardService
      .getByColumnId(this.column.id)
      .subscribe(cards => (this.cards = cards));
  }

  toggleCardForm() {
    if (!this.cardForm) {
      this.addForm();
    } else {
      this.removeForm();
    }
  }

  private addForm() {
    this.container.clear();

    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(
      CardFormComponent
    );
    this.cardForm = this.container.createComponent(componentFactory);

    this.cardForm.instance.canceled.subscribe(() => this.removeForm());
    this.cardForm.instance.submitted.subscribe(card => this.createCard(card));
  }

  private createCard(card) {
    this.cardService.create(card, this.column.id).subscribe(created => {
      this.cards.push(created);
      this.removeForm();
    });
  }

  private removeForm() {
    this.cardForm.instance.canceled.unsubscribe();
    this.cardForm.instance.submitted.unsubscribe();
    this.cardForm.destroy();
    this.cardForm = null;
    this.container.clear();
  }

  cardDropped(event: CdkDragDrop<any>) {
    console.log(event);
    if (event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    }
  }
}
