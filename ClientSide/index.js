'use strict';


//hello = "hello"; //dangerous: this is document scope - not within its scope //illegal in use strict
var hello = "hello"; //dangerous: this is document scope - not within its scope //illegal in use strict
var allo = "allo"; // document scope - withing its scope, var makes it respect its scope


//Anything goes in Javascript
// null = 1; //crazy thing we can do //illegal in use strict
// undefined = true; //crazy thing we can do //illegal in use strict


console.log(hello);
console.log(allo);

console.log("What is up my peeoples");

first(); // this works because first() is document scoped
console.log(typeof(second)); // second is hoisted but it does not have a value


function first() { //first() is document scope
    //banana = 23;
    console.log("first");
}

var second = function () { //second is document scope but is just a var in document scope
    console.log("second");
}

function FirstClass() {  //JS uses camel casing, but for constructors use Pascal Casing
//functions that have this keyword are constructor functions
    this.firstName = "fred";
    this.lastName = "belotte";
}

//how do we use a constructor ?

var fc = new FirstClass(); // new means give me an instance of FirstClass
var fc2 = new FirstClass();
console.log(fc.firstName, fc.lastName);  //This prints out fred belotte to console


fc.firstName = "banana";

console.log(fc2.firstName, fc.lastName);

//console.log(banana);