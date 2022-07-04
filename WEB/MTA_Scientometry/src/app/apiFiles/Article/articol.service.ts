import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { ArticolExplicit } from './articolExplicit';
import { NumeArticole } from './numeArticole';
import { ModPrezentare } from './modPrezentare';
import { TipPublicatie } from './tipPublicatie';
import { TopArticole } from './topArticole';

@Injectable({
  providedIn: 'root',
})
export class ArticleService {
  constructor(private http: HttpClient) {}

  addViews(article: ArticolExplicit) {
    return this.http.put(
      environment.URL + '/Articole/vizitatori=' + article.idarticol,
      article
    );
  }

  getMostSearchedArticles(): Observable<TopArticole[]> {
    return this.http.get<TopArticole[]>(environment.URL + '/Articole/top');
  }

  getArticles(): Observable<ArticolExplicit[]> {
    return this.http.get<ArticolExplicit[]>(environment.URL + '/Articole/all');
  }
  postArticles(articol: ArticolExplicit) {
    return this.http.post<ArticolExplicit[]>(
      environment.URL + '/Articole',
      articol
    );
  }
  getArticlesByName(name: string): Observable<ArticolExplicit[]> {
    return this.http.get<ArticolExplicit[]>(
      environment.URL + '/Articole/search=' + name
    );
  }
  updateArticle(article: ArticolExplicit) {
    return this.http.put(
      environment.URL + '/Articole/' + article.idarticol,
      article
    );
  }

  deleteArticle(id: number) {
    return this.http.delete(environment.URL + '/Articole/' + id);
  }

  getArticlesByAuthor(id: string | null): Observable<NumeArticole[]> {
    return this.http.get<NumeArticole[]>(
      environment.URL + '/Articole/idutilizator=' + id
    );
  }

  getArticlesByYear(
    beginYear: number,
    endYear: number
  ): Observable<ArticolExplicit[]> {
    return this.http.get<ArticolExplicit[]>(
      environment.URL +
        '/Articole/beginYear=' +
        beginYear +
        '&endYear=' +
        endYear
    );
  }

  getAllMods(): Observable<ModPrezentare[]> {
    return this.http.get<ModPrezentare[]>(environment.URL + '/ModPrezentare');
  }

  getAllPubs(): Observable<TipPublicatie[]> {
    return this.http.get<TipPublicatie[]>(environment.URL + '/TipPublicatii');
  }

  getArticleByID(id: number) {
    return this.http.get<ArticolExplicit>(environment.URL + '/Articole/' + id);
  }
}
