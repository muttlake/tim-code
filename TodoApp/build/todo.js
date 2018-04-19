"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Todo = /** @class */ (function () {
    function Todo() {
        this.todoList = new Array();
    }
    Todo.prototype.getTodos = function () {
        return this.todoList;
    };
    Todo.prototype.addTodo = function (todo) {
        if (todo && typeof todo === 'function')
            this.todoList.push(todo);
    };
    Todo.prototype.completeTodo = function (todo) {
        // var c = this.todoList.find( => t.id == todo.id);
        //var c = this.todoList.
        todo.done = true;
    };
    Todo.prototype.displayTodos = function () {
        var container = document.querySelector('#todos');
        for (var t in this.todoList) {
            var li = document.createElement('li');
            var tx = this.todoList[t];
            li.innerHTML = tx.content;
            li.setAttribute('id', tx.id.toString());
            container.appendChild(li);
        }
    };
    return Todo;
}());
exports.Todo = Todo;
