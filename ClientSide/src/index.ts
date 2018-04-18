
//export means we want this to be available to other people
export class Person { 
    
    firstName: string;
    lastName: string;



    constructor(first: string, last: any) {
        this.firstName = first;
        this.lastName = last;
    }

}

var p = new Person("Jimmy", "CricketSnap");