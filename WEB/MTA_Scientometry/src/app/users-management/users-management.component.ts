import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { AuthorService } from '../apiFiles/Author/autori.service';
import { Autor } from '../apiFiles/Author/autori';
import { UserService } from '../apiFiles/User/user.service';
import { User } from '../apiFiles/User/user';
import { ArticleService } from '../apiFiles/Article/articol.service';

@Component({
  selector: 'app-users-management',
  templateUrl: './users-management.component.html',
  styleUrls: ['./users-management.component.css'],
})
export class UsersManagementComponent implements OnInit {
  header: boolean = true;
  index: number = 1;
  authors: Autor[] = [];
  users: User[] = [];

  getRequests() {
    let index: number = 0;
    this.authService.getAuthors().subscribe((res) => {
      this.authors = res;
    });
  }
  acceptRequest(author: Autor, index: number) {
    author.approved = true;
    this.authService.updateType(author).subscribe();
    this.authors.splice(index, 1);
  }
  rejectRequest(author: Autor, index: number) {
    console.log(author);
    this.authService.deleteReq(author).subscribe();
    this.authors.splice(index, 1);
  }

  getAllUsers() {
    this.userService.getUsers().subscribe((res) => {
      this.users = res;
    });
  }

  searchByUsername(username: string) {
    this.userService.getUserByUsername(username).subscribe((res) => {
      this.users = [];
      this.users = res;
    });
  }

  deleteUser(user: User, index: number) {
    if (user.type == 3) {
      alert('Nu poti sterge contul de admin!');
      return;
    }
    var dialog = confirm(
      'Toate datele asociate contului, cu exceptia articolelor, vor fi sterse. Doriti sa continuati?'
    );
    if (dialog) {
      this.userService.deleteUser(user).subscribe();
      this.users.splice(index, 1);
    }
  }

  search() {
    let username = $('#searchInput').prop('value');
    if (username == '') this.getAllUsers();
    else this.searchByUsername(username);
  }

  constructor(
    private appComponent: AppComponent,
    private authService: AuthorService,
    private userService: UserService,
    private articolService: ArticleService
  ) {}

  ngOnInit(): void {
    this.appComponent.userValidation();
    this.getRequests();
  }
}
