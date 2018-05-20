import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User'

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  user: User = {
    firstName: '',
    lastName: '',
    age: null,
    address: {
      street: '',
      city: '',
      state: ''
    }
  };

  users: User[];
  showExtended: boolean = true;
  loaded: boolean = false;
  enableAdd: boolean = false;
  showUserForm: boolean = false;



  constructor() { }

  ngOnInit() {
      this.users = [
        {
        firstName: 'John',
        lastName: 'Doe',
        age: 70,
        address: {
            street: '50 Main St',
            city: 'Boston',
            state: 'MA'
        },
        isActive: true,
        registered: new Date('01/02/2018 08:30:00'),
        hide: true
      },
      {
        firstName: 'Kevin',
        lastName: 'Johnson',
        age: 24,
        address: {
            street: '50 School St',
            city: 'Lynn',
            state: 'MA'
        },
        isActive: false,
        registered: new Date('12/02/2018 06:20:00'),
        hide: true
      },
      {
        firstName: 'Karen',
        lastName: 'Wilkerson',
        age: 30,
        address: {
            street: '55 Mill St',
            city: 'Miami',
            state: 'FL'
        },
        isActive: true,
        registered: new Date('12/02/2018 10:20:00'),
        hide: true
      }
      ];

      this.loaded = true;
  }


  addUser() {
    this.user.isActive = true;
    this.user.registered = new Date();
    this.users.unshift(this.user); //unshift adds to beginning of array
    this.user = {
      firstName: '',
      lastName: '',
      age: null,
      address: {
        street: '',
        city: '',
        state: ''
      }
    };
  }

  onSubmit(e) {
    console.log(123);
    e.preventDefault();
  }

  fireEvent(e) {
    console.log(e.type);
    console.log(e.target.value);
  }

}
