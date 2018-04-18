'use strict';

//Re-write run function this way

(function() {  //var run is in the document scope
    function Person(name) { // all this stuff is in function scope of above function
        this.name = name;
    }

    function sayMyName() {
        var p = new Person("FouererereYERRERES");
        return p.name;
    }

    console.log(sayMyName());

    return function() {
        console.log("from the inner function");
    }
} () );  //IFFE function: immediately invoked function expression
         //IFFE functions avoid namespace problem
         // right now return function is now being called

( function(){}() ); //you wrap function in an expression

( function(){}) ();

//one object is always part of document scope:
//window //like window.console.log();

var APP = (function() {
    'use strict';

    console.log("APP IFFE");

    return {   //return literal object here
        name: "Timimimimimim",
        job: "software engineer",
        method: function(a, b) {
            if(typeof(a) === 'Number' && typeof(b) === 'Number')
                return a + b;
        }
    }
});

APP();
console.log(APP().name);
console.log(APP().method("ab", 12));

//app has access to this anonymous function below
var app = function() {};
app();

// Two different way of dealing with objects
//constructor object
function Thing() {
    this.name = null;  //this binds to what you are calling it from
    this.job = null;   //factory
}

//literal object
var thing = {   
    name: null,   //singleton, cannot make new objects from this
    job: null
}









