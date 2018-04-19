export class Todo {
    
    todoList: Array<TodoItem>;

    constructor() {
        this.todoList = new Array<TodoItem>();
    }

    getTodos() {
        return this.todoList;
    }

    addTodo(todo: TodoItem) {
        if (todo &&  typeof todo === 'function')
        this.todoList.push(todo);
    }

    completeTodo(todo: TodoItem) {
        // var c = this.todoList.find( => t.id == todo.id);
        //var c = this.todoList.
        todo.done = true;
    }

    displayTodos() {
        var container = document.querySelector('#todos');
        for (const t in this.todoList) {
            var li = document.createElement('li');
            var tx = this.todoList[t];
            li.innerHTML = tx.content;
            li.setAttribute('id', tx.id.toString());
            container.appendChild(li);
        }
    }

}