import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user';
import { environment } from 'src/environments/environment.prod';
import { Code } from './code';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUser(username: string, password: string): Observable<User[]> {
    return this.http.get<any>(
      environment.URL +
        '/Utilizatori/username=' +
        username +
        '&password=' +
        password
    );
  }
  getUserByID(id: number): Observable<User[]> {
    return this.http.get<any>(environment.URL + '/Utilizatori/' + id);
  }

  getUserByUsername(username: string): Observable<User[]> {
    return this.http.get<any>(
      environment.URL + '/Utilizatori/partialUsername=' + username
    );
  }

  getUsers(): Observable<User[]> {
    return this.http.get<any>(environment.URL + '/Utilizatori');
  }

  usedEmail(email: string): Observable<User[]> {
    return this.http.get<any>(
      environment.URL + '/Utilizatori/usedEmail=' + email
    );
  }

  usedUsername(username: string): Observable<User[]> {
    return this.http.get<any>(
      environment.URL + '/Utilizatori/usedUsername=' + username
    );
  }

  addUser(user: User) {
    return this.http.post(environment.URL + '/Utilizatori', user);
  }

  updatePassword(password: any, user: any) {
    user.password = password;
    return this.http.put<User>(
      environment.URL + '/Utilizatori/' + user.id,
      user
    );
  }
  updateUsername(username: any, user: User) {
    user.username = username;
    return this.http.put<User>(
      environment.URL + '/Utilizatori/' + user.id,
      user
    );
  }

  updateEmail(email: any, user: User) {
    user.email = email;
    return this.http.put<User>(
      environment.URL + '/Utilizatori/' + user.id,
      user
    );
  }

  getVerificationCode(email: any) {
    return this.http.get<Code[]>(
      environment.URL + '/Utilizatori/email=' + email
    );
  }

  deleteUser(user: User) {
    return this.http.delete(environment.URL + '/Utilizatori/' + user.id);
  }
}
