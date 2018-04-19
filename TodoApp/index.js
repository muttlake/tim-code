var TODO = (function () {
    'use strict';

    var todoList = []; //var todoList = new Array();, but the commented version not reccommended


    var addButton = document.querySelector('#addTodo');
    addButton.addEventListener('click', function (event) {
        event.stopImmediatePropagation();
        event.preventDefault();
        var text = document.querySelector('#todo').value;
        var t = new TodoItem();
        t.content = text;
        t.id = todoList.length; 

        addTodo(t);
        displayTodos();
    });

    var formSubmit = document.querySelector('#formsubmit');
    formSubmit.addEventListener('submit', (e) => {
        e.stopImmediatePropagation();
        e.preventDefault();
        var text = document.querySelector('#todo').value;
        var t = new TodoItem();
        t.content = text;
        t.id = todoList.length; 

        addTodo(t);
        displayTodos();
    });


    function callServer(params) {
        var ajax = new XMLHttpRequest(); // This is what ajax uses
        ajax.open('get', 'https://swapi.co/api/people/4');
 
        ajax.onreadystatechange = () => {
            if (ajax.readyState == 4 && ajax.status === 200) //state 4 is connection closed, 200 HTTP code = success
            {
                console.log(JSON.parse(ajax.response));
            }
        }

        ajax.send();
    }


    var swapiButton =document.querySelector('#swapi');

    swapiButton.addEventListener('click', () => {
        callServer();
    });




    

    var bosysubmit = document.querySelector('body');
    bosysubmit.addEventListener('click', (e) => {
        // var element = e.target;
        // element.style.color = 'red';
        e.target.style.color = 'green';
        // console.log("rdrdrtdrdtdt");
    });


    // capitalize.call(obj, arg1, arg2, arg3);   //like extension methods in C#
    // capitalize.apply(obj, [arg1, arg2]);
    // obj.capitalize();
    // function capitalize(arg1, arg2, arg3)
    // {

    // }

    // {  // This is what an array looks like in javascript: and object that is a collection of other objects
    //     0:jwfnekvnjkne,
    //     1:asdfslklkmlk,
    // }

    /**
     * The todoItem function
     * @params ()
     * 
     */
    function TodoItem() {
        this.id = null;
        this.content = null;
        this.done = false;
    }

    function getTodos() {
        return todoList;
    }

    function addTodo(todo) {
        if (todo &&  typeof todo === 'function')
        todoList.push(todo);
    }

    function completeTodo(todo) {
        var c = todoList.find(todo);
        c.done = true;
    }

    function displayTodos() {
        var container = document.querySelector('#todos');
        for (const t in todoList) {
            var li = document.createElement('li');
            var tx = todoList[t];
            li.innerHTML = tx.content;
            li.setAttribute('id', tx.id);
            container.appendChild(li);
        }
    }
    

    return {
        make: TodoItem,
        get: getTodos,
        add: addTodo,
        done: completeTodo
    }

}) ();  //This is a closure object, it access something that should have disappeared from memory


// console.log(TODO);
// console.log(TODO.make);
// console.log(TODO.todoList);
// console.log(TODO.displayTodos);
