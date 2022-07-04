import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Autor } from './autori';
import { User } from '../User/user';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  constructor(private http: HttpClient) {}

  getAuthors(): Observable<any[]> {
    return this.http.get<any>(environment.URL + '/Autori/approved=false');
  }

  getAllAuthors(): Observable<Autor[]> {
    return this.http.get<Autor[]>(environment.URL + '/Autori');
  }

  getAllExistingAuthors(): Observable<Autor[]> {
    return this.http.get<Autor[]>(environment.URL + '/Autori/existing');
  }

  postAuthor(author: Autor) {
    return this.http.post(environment.URL + '/Autori', author);
  }

  getUser(id: string): Observable<User> {
    return this.http.get<any>(environment.URL + '/Utilizatori/?id=' + id);
  }

  updateType(author: Autor) {
    return this.http.put<Autor>(
      environment.URL + '/Autori/' + author.idautor,
      author
    );
  }

  deleteReq(author: Autor) {
    return this.http.delete(environment.URL + '/Autori/' + author.idautor);
  }
}
