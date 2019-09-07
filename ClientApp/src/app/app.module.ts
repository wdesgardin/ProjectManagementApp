import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { NgbModalModule } from "@ng-bootstrap/ng-bootstrap";
import { DragDropModule } from "@angular/cdk/drag-drop"

import { AppComponent } from "./app.component";
import { BoardsListComponent } from "./boards-list/boards-list.component";
import { BoardFormComponent } from "./board-form/board-form.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { BoardComponent } from "./board/board.component";
import { ColumnComponent } from "./column/column.component";
import { ColumnModalComponent } from './column-modal/column-modal.component';
import { CardFormComponent } from './card-form/card-form.component';

@NgModule({
  declarations: [
    AppComponent,
    BoardsListComponent,
    BoardFormComponent,
    NavbarComponent,
    BoardComponent,
    ColumnComponent,
    ColumnModalComponent,
    CardFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", pathMatch: "full", redirectTo: "boards" },
      { path: "boards", component: BoardsListComponent, pathMatch: "full" },
      { path: "boards/new", component: BoardFormComponent, pathMatch: "full" },
      { path: "boards/:id", component: BoardComponent, pathMatch: "full" }
    ]),
    NgbModalModule,
    DragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [ColumnModalComponent, CardFormComponent]
})
export class AppModule {}
