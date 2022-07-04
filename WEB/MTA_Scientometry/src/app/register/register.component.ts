import { Component, HostListener, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { FormBuilder } from '@angular/forms';
import { UserService } from '../apiFiles/User/user.service';
import { User } from '../apiFiles/User/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  myForm = this.form.group({
    usernameInput: [''],
    passwordInput: [''],
    RpasswordInput: [''],
    emailInput: [''],
  });
  constructor(
    private appComponent: AppComponent,
    private userService: UserService,
    private form: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.appComponent.initStorage();
  }

  emptyData() {
    if (
      this.myForm.value['passwordInput'] != this.myForm.value['RpasswordInput']
    ) {
      alert('Passwords are not the same!');
      return true;
    }
    if (this.myForm.value['usernameInput'] == '') {
      alert('You have not inserted your username!');
      return true;
    }
    if (this.myForm.value['passwordInput'] == '') {
      alert('You have not inserted your password!');
      return true;
    }
    if (this.myForm.value['emailInput'] == '') {
      alert('You have not inserted your email!');
      return true;
    }
    return false;
  }

  existingData() {
    var result: boolean = false;
    this.userService
      .usedUsername(this.myForm.value['usernameInput'])
      .subscribe((res) => {
        if (res.length != 0) {
          alert('Already used username!');
          result = true;
        }
      });
    this.userService
      .usedEmail(this.myForm.value['emailInput'])
      .subscribe((res) => {
        if (res.length != 0) {
          alert('Already used email!');
          result = true;
        }
      });
    return result;
  }

  addUser() {
    if (this.emptyData() == true) return;
    if (this.existingData() == true) return;
    const user: User = <User>{
      username: this.myForm.value['usernameInput'],
      password: this.myForm.value['passwordInput'],
      email: this.myForm.value['emailInput'],
      type: 1,
    };

    this.userService.addUser(user).subscribe();
    alert('You have registred with succes!');
    this.router.navigate(['/login']);
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
      this.addUser();
    }
  }
}
