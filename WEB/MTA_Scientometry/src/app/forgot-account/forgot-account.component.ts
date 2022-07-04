import {
  Component,
  ElementRef,
  HostListener,
  OnInit,
  ViewChild,
} from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Code } from '../apiFiles/User/code';
import { User } from '../apiFiles/User/user';
import { UserService } from '../apiFiles/User/user.service';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-forgot-account',
  templateUrl: './forgot-account.component.html',
  styleUrls: ['./forgot-account.component.css'],
})
export class ForgotAccountComponent implements OnInit {
  passwordForm = this.form.group({
    nPassword: [],
    rPassword: [],
  });
  emailForm = this.form.group({
    email: [],
  });
  myForm = this.form.group({
    mycode: [],
  });

  code: Code[];
  verified: number = 0;
  sent: number = 0;

  verifyCode() {
    let myCode = this.myForm.value['mycode'];

    if (myCode == this.code[0].code) {
      this.verified = 1;
      $('.code').prop('disabled', true);
      $('#verifyCodeButton').prop('disabled', true);
    } else {
      alert('Incorrect code! Please try again');
      $('.code').prop('value', '');
    }
  }

  sendRequest() {
    if (this.emailForm.value['email'] == null) {
      alert('Please insert your email!');
      return;
    }
    this.userService
      .getVerificationCode(this.emailForm.value['email'])
      .subscribe((res) => {
        this.code = res;
        if (this.code == undefined) alert('Email incorrect');
        else {
          this.sent = 1;
          $('#emailInput').prop('disabled', true);
          $('#sendEmailButton').prop('disabled', true);
        }
      });
  }

  changePassword() {
    if (
      this.passwordForm.value['nPassword'] !=
      this.passwordForm.value['rPassword']
    ) {
      alert('Passwords are not the same');
      return;
    }
    this.userService.getUserByID(this.code[0].id).subscribe((res) => {
      console.log(res);
      this.userService
        .updatePassword(this.passwordForm.value['nPassword'], res)
        .subscribe();
    });
    alert('Your password has been changed');
    this.route.navigate(['/login']);
  }

  constructor(
    private appComponent: AppComponent,
    private userService: UserService,
    private form: FormBuilder,
    private route: Router
  ) {
    this.appComponent.initStorage();
  }

  ngOnInit(): void {}
}
