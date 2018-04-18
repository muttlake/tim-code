"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Person = (function () {
    function Person(first, last) {
        this.firstName = first;
        this.lastName = last;
    }
    return Person;
}());
exports.Person = Person;
var x = new Person("Ally", "Whatsnaggle");
