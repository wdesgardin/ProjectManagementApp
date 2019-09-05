import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { BoardsListComponent } from "./boards-list/boards-list.component";
import { BoardFormComponent } from "./board-form/board-form.component";
import { NavbarComponent } from "./navbar/navbar.component";

@NgModule({
  declarations: [
    AppComponent,
    BoardsListComponent,
    BoardFormComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", pathMatch: "full", redirectTo: "boards"},
      { path: "boards", component: BoardsListComponent, pathMatch: "full" },
      { path: "boards/new", component: BoardFormComponent, pathMatch: "full" }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
