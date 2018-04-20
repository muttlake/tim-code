import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { TodoComponent } from '../todo/todo.component'
import {enableProdMode} from '@angular/core';
import { ApiService } from '../api/api.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

enableProdMode();

@NgModule({
  declarations: [
    AppComponent,
    TodoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent, TodoComponent]
})
export class AppModule { }
