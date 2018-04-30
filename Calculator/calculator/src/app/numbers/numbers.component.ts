import { Component, OnInit } from '@angular/core';
import { Num } from '../num';
import { NUMBERS } from '../numberslist';

@Component({
  selector: 'app-numbers',
  templateUrl: './numbers.component.html',
  styleUrls: ['./numbers.component.css']
})
export class NumbersComponent implements OnInit {

  numbers: Num[];

  operand1: string = '';
  operand2: string = '';

  equalsOperator: string = '='

  currentOperator: string = '';

  operators: string[] = [ '+', '-', '*', '/' ]

  operatorHit: boolean = false;

  result: string = '';

  constructor() { }

  ngOnInit() {
    this.getNumbers();
  }

  getNumbers(): void {
    this.numbers = NUMBERS;
  }

  getValue(num: Num): number {
    console.log("Get num value " + num.name);

    if(!this.operatorHit) {
    	this.operand1 += num.name;
    }
    else {
    	this.operand2 += num.name;
    }


    return num.value;
  }

  getOperator(op: string): void {

    if(!this.operatorHit)
    {
      this.currentOperator = op;
      this.operatorHit = true;
    }

    console.log("Current operator value " + this.currentOperator);
  }

  evaluate(): void {
    if(this.operand1 && this.currentOperator && this.operand2)
    {
    	var op1 = +this.operand1;
	var op2 = +this.operand2;

	if(this.currentOperator === '+') {
	   var result = op1 + op2;
	   this.result = String(result);
	}
	else if(this.currentOperator === '-') {
	   var result = op1 - op2;
	   this.result = String(result);
	}
	else if(this.currentOperator === '/') {
	   var result = op1 / op2;
	   this.result = String(result);
	}
	else if(this.currentOperator === '*') {
	   var result = op1 * op2;
	   this.result = String(result);
	}

	if(this.result) {
	   this.operand1 = this.result;
	   this.operand2 = '';
	   this.currentOperator = '';
	   this.operatorHit = false;
	}

    }
  }

  clear(): void {
  	this.operand1 = '';
	this.operand2 = '';
	this.currentOperator = '';
	this.result = '';
	this.operatorHit = false;
  }



}
