'use strict';

//The whole point of run() is to be a scope
var run = function() {  //var run is in the document scope
    function Person(name) { // all this stuff is in function scope of above function
        this.name = name;
    }

    function sayMyName() {
        var p = new Person("Thingererre");
        return p.name;
    }

    console.log(sayMyName());
}

run(); // can only call run here, because only var run