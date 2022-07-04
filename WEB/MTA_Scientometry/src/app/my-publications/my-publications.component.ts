import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../apiFiles/Article/articol.service';
import { NumeArticole } from '../apiFiles/Article/numeArticole';
import { TopArticole } from '../apiFiles/Article/topArticole';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-my-publications',
  templateUrl: './my-publications.component.html',
  styleUrls: ['./my-publications.component.css'],
})
export class MyPublicationsComponent implements OnInit {
  articole: NumeArticole[] = [];

  getAuthorPubs() {
    let id = sessionStorage.getItem('id');
    this.articleService.getArticlesByAuthor(id).subscribe((res) => {
      this.articole = res;
      console.log(this.articole);
    });
  }

  constructor(
    private appComponent: AppComponent,
    private articleService: ArticleService
  ) {}

  ngOnInit(): void {
    sessionStorage.setItem('lastPage', 'publications');
    this.getAuthorPubs();
    this.appComponent.userValidation();
  }
}
