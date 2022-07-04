import { Component, HostListener, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { AppComponent } from '../app.component';
import { UserService } from '../apiFiles/User/user.service';
import { environment } from 'src/environments/environment.prod';
import * as $ from 'jquery';

@Injectable({
  providedIn: 'root',
})
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  myForm = this.form.group({
    username: [this.getCookie('username')],
    password: [this.getCookie('password')],
  });

  onSubmit() {
    this.userService
      .getUser(this.myForm.value['username'], this.myForm.value['password'])
      .subscribe((data) => {
        if (data.length == 1) {
          sessionStorage.setItem('username', data[0].username);
          sessionStorage.setItem('password', data[0].password);
          sessionStorage.setItem('email', data[0].email);
          sessionStorage.setItem('id', data[0].id.toString());
          sessionStorage.setItem('userType', data[0].type.toString());
          this.route.navigate(['/home']);
        } else alert('Username or password incorrect!');
      });
  }

  setCookie() {
    if ($('#rememberUser').prop('checked')) {
      document.cookie =
        'username=' +
        this.myForm.value['username'] +
        ';path=' +
        environment.URLCookies +
        '/login/';
      document.cookie =
        'password=' +
        this.myForm.value['password'] +
        ';path=' +
        environment.URLCookies +
        '/login/';
    }
  }

  getCookie(cname: string) {
    var name = cname + '=';
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return '';
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
      if (this.myForm.value['username'] == '') {
        alert('You have not inserted the username!');
        return;
      }
      if (this.myForm.value['password'] == '') {
        alert('You have not inserted the password!');
        return;
      }

      this.onSubmit();
    }
  }

  constructor(
    private form: FormBuilder,
    private route: Router,
    private appComponent: AppComponent,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.appComponent.initStorage();
  }
}
