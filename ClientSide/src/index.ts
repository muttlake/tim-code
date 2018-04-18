
//export means we want this to be available to other people
export class Person { 
// class Person { 
    
    firstName: string;
    lastName: string;



    constructor(first: string, last: any) {
        this.firstName = first;
        this.lastName = last;
    }

}

var x = new Person("Ally", "Whatsnaggle");

// var p = new Person("Jimmy", "CricketSnap");

// console.log("inside index.ts");

// console.log(x);
// console.log(p);