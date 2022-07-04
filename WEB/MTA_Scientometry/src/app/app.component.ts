import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './apiFiles/User/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'ScientometrieMTA';
  userType: number;
  constructor(private route: Router) {}
  ngOnInit(): void {}

  userValidation() {
    let userType = sessionStorage.getItem('userType');
    if (userType == null || userType == '0') {
      this.route.navigate(['/login']);
      alert('Please log in to access this page!');
      this.route.navigate(['']);
      return;
    }
    this.userType = Number(userType);
  }

  initStorage() {
    this.userType = 0;
    sessionStorage.setItem('userType', '0');
  }
}
