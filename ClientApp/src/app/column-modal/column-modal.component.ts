import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Column } from '../models/column.model';

@Component({
  selector: 'app-column-modal',
  templateUrl: './column-modal.component.html',
  styleUrls: ['./column-modal.component.css']
})
export class ColumnModalComponent {

  column: Column = {
    title: ''
  }

  constructor(public activeModal: NgbActiveModal) { }

}
