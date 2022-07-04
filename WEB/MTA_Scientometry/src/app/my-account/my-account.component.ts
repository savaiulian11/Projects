import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { User } from '../apiFiles/User/user';
import { AppComponent } from '../app.component';
import { UserService } from '../apiFiles/User/user.service';
import * as $ from 'jquery';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.css'],
})
export class MyAccountComponent implements OnInit {
  user: User = <User>{
    username: sessionStorage.getItem('username'),
    password: sessionStorage.getItem('password'),
    email: sessionStorage.getItem('email'),
    id: Number(sessionStorage.getItem('id')),
    type: Number(sessionStorage.getItem('userType')),
  };
  myForm = this.form.group({
    usernameInput: [sessionStorage.getItem('username')],
    newPasswordInput: [''],
    oldPasswordInput: [''],
    emailInput: [sessionStorage.getItem('email')],
  });

  verifyPassword() {
    if (
      this.myForm.value['oldPasswordInput'] ==
      sessionStorage.getItem('password')
    ) {
      $('#passwordButton').show();
      alert('You can change your password.');
    } else alert('Wrong password! Try again!');
  }

  updateUsername() {
    this.userService
      .updateUsername(this.myForm.value['usernameInput'], this.user)
      .subscribe();
    this.user.username = this.myForm.value['usernameInput'];
    sessionStorage.setItem('username', this.user.username);
    console.log('You have updated your username');
    $('#passwordButton').hide();
  }
  updatePassword() {
    this.userService
      .updatePassword(this.myForm.value['newPasswordInput'], this.user)
      .subscribe();
    this.user.password = this.myForm.value['newPasswordInput'];
    sessionStorage.setItem('password', this.user.password);
    console.log('You have updated your password');
    $('#passwordButton').hide();
  }
  updateEmail() {
    this.userService
      .updateEmail(this.myForm.value['emailInput'], this.user)
      .subscribe();
    this.user.email = this.myForm.value['emailInput'];
    sessionStorage.setItem('email', this.user.email);
    console.log('You have updated your email');
  }

  constructor(
    private appComponent: AppComponent,
    private userService: UserService,
    private form: FormBuilder
  ) {}
  ngOnInit(): void {
    $('#passwordButton').hide();
    this.appComponent.userValidation();
  }
}
