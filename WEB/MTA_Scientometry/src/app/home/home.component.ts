import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { AuthorService } from '../apiFiles/Author/autori.service';
import { FormBuilder } from '@angular/forms';
import { Autor } from '../apiFiles/Author/autori';
import { ArticleService } from '../apiFiles/Article/articol.service';
import { Router } from '@angular/router';
import { TopArticole } from '../apiFiles/Article/topArticole';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  arts: TopArticole[] = [];
  userType: any;
  myForm = this.form.group({
    prenume: [],
    nume: [],
    uefid: [],
    link: [],
    details: [],
  });

  constructor(
    private appComponent: AppComponent,
    private authorService: AuthorService,
    private articleService: ArticleService,
    private form: FormBuilder,
    private route: Router
  ) {}

  authorRequest() {
    const newAuth: Autor = <Autor>(<unknown>{
      idutilizator: sessionStorage.getItem('id'),
      uefid: this.myForm.value['uefid'],
      prenume: this.myForm.value['prenume'],
      nume: this.myForm.value['nume'],
      link: this.myForm.value['link'],
      details: this.myForm.value['details'],
      approved: false,
    });
    console.log(newAuth);
    this.authorService.postAuthor(newAuth).subscribe((res) => console.log(res));
    alert('Your request has been registred!');
  }

  seeArticol(index: number) {
    sessionStorage.setItem('lastPage', 'home');

    this.route.navigate(['article/view/' + this.arts[index].id]);
  }

  ngOnInit(): void {
    this.articleService.getMostSearchedArticles().subscribe((res) => {
      res.forEach((element) => {
        this.arts.push(element);
      });
      console.log(this.arts);
    });
    this.userType = sessionStorage.getItem('userType');
    this.appComponent.userValidation();
  }
}
