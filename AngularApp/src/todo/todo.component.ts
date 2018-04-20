import { Component } from '@angular/core';
import {TodoItem } from './todoitem'
import { ApiService } from "../api/api.service"


@Component({
  selector: 'todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent {
    todoList: Array<TodoItem>;
    todoItem: TodoItem;
    client: ApiService;

    constructor(client: ApiService) {
        if(!this.todoList)   {
            this.todoList = new Array<TodoItem>();
        }          

        this.todoItem = new TodoItem();
        this.client = client;
    }

    add(content: string) {
        console.log("trying to add todo");
        // let todo = new TodoItem();
        this.todoItem.content = content;
        this.todoItem.id = this.todoList.length;
        this.todoItem.done = false;
        this.todoList.push(this.todoItem);
    }

    
    callService() {
        this.client.getSwapi(1);
    }

}