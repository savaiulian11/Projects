import { Component, HostListener, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ArticleService } from '../apiFiles/Article/articol.service';
import { ArticolExplicit } from '../apiFiles/Article/articolExplicit';
import { AutorDetalii } from '../apiFiles/Author/autorDetalii';
import { Citari } from '../apiFiles/Article/citari';
import { AuthorService } from '../apiFiles/Author/autori.service';
import { Autor } from '../apiFiles/Author/autori';
import { ModPrezentare } from '../apiFiles/Article/modPrezentare';
import { TipPublicatie } from '../apiFiles/Article/tipPublicatie';
import { Detalii } from '../apiFiles/Article/detalii';
import { Publicatie } from '../apiFiles/Article/publicatie';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css'],
})
export class ArticleComponent implements OnInit {
  deletedAuthors: AutorDetalii[] = [];
  deletedCitari: Citari[] = [];
  mods: ModPrezentare[] = [];
  pubs: TipPublicatie[] = [];
  authorsRegistred: Autor[] = [];
  articol: ArticolExplicit = <ArticolExplicit>{};
  authorsNumber: number = 0;
  citationsNumber: number = 0;
  action: string;
  id: number;

  backButton() {
    let lastPage = sessionStorage.getItem('lastPage');
    switch (lastPage) {
      case 'search':
        this.router.navigate(['/search']);
        break;
      case 'home':
        this.router.navigate(['/home']);
        break;
      case 'publications':
        this.router.navigate(['/my-publications']);
        break;
    }
  }
  //0-autor nou fara cont ---adaugare nou in tabela
  //1-autor nou cu cont   ---adaugare nou in tabela
  //2-autor existent fara cont   ---nu adaugi nimic
  //3-autor existent cu cont     ---nu adaugi nimic
  addAuthor() {
    let temp: AutorDetalii = <AutorDetalii>{
      nume: 'nou',
      tipAutor: 1,
    };
    this.articol.autori.push(temp);
    this.authorsNumber++;
  }
  removeAuthor(index: number) {
    if (
      this.articol.autori[index].tipAutor == 2 ||
      this.articol.autori[index].tipAutor == 3
    ) {
      this.articol.autori[index].tipAutor = 4;
      this.deletedAuthors.push(this.articol.autori[index]);
    }
    this.articol.autori.splice(index, 1);
    this.authorsNumber--;
  }

  createArticle() {
    this.deletedAuthors.forEach((element) => {
      this.articol.autori.push(element);
    });
    if (this.getDataFromArticle() == false) return;
    this.articol.vizitatori = 0;
    this.articol.idutilizator = Number(sessionStorage.getItem('id'));
    this.articleService.postArticles(this.articol).subscribe();
    this.router.navigate(['/my-publications']);
  }

  updateArticle() {
    if (this.deletedAuthors.length != 0)
      this.deletedAuthors.forEach((element) => {
        this.articol.autori.push(element);
      });
    if (this.getDataFromArticle() == false) return;
    this.articleService.updateArticle(this.articol).subscribe();
    location.reload();
  }

  deleteArticle() {
    this.articleService.deleteArticle(this.articol.idarticol).subscribe();
    let lastPage = sessionStorage.getItem('lastPage');
    switch (lastPage) {
      case 'search':
        this.router.navigate(['/search']);
        break;
      case 'home':
        this.router.navigate(['/home']);
        break;
      case 'publications':
        this.router.navigate(['/my-publications']);
        break;
    }
  }

  getDataFromArticle() {
    for (let i = 0; i < this.authorsNumber; i++) {
      if ($('#autor' + i).prop('value') == '') {
        alert('You have left an author name empty!');
        return;
      }
      this.articol.autori[i].prenume = '';
      this.articol.autori[i].nume = '';
      let numeInterg: string = $('#autor' + i).prop('value');
      let split = numeInterg.split(' ', 100);
      let j = 0;
      while (split[0] == '') split.splice(0, 1);
      this.articol.autori[i].nume = split[0];
      if (split.length <= 1) {
        alert('You have not added the full name on an author!');
        this.articol.autori.splice(i, 1);
        return false;
      }
      j = 1;
      for (; j < split.length - 1; j++)
        this.articol.autori[i].prenume += split[j] + ' ';
      this.articol.autori[i].prenume += split[split.length - 1];

      if (this.articol.autori[i].tipAutor == 1) {
        this.authorsRegistred.forEach((element) => {
          if (
            element.nume == this.articol.autori[i].nume &&
            element.prenume == this.articol.autori[i].prenume
          )
            this.articol.autori[i].idautor = this.authorsRegistred[i].idautor;
        });
      }
    }
    this.articol.detalii.an = $('#an').prop('value');
    this.articol.detalii.numar = $('#numar').prop('value');
    this.articol.detalii.pagina = $('#pagina').prop('value');
    this.articol.detalii.volum = $('#volum').prop('value');
    this.articol.nume = $('#nume').prop('value');
    this.articol.wos = $('#wos').prop('value');
    this.articol.doi = $('#doi').prop('value');
    this.articol.factorImpact = $('#factorImpact').prop('value');
    this.articol.jurnal = $('#jurnal').prop('value');
    this.articol.publicatie.nume = $('#numePublicatie').prop('value');
    this.articol.publicatie.editor = $('#editorPublicatie').prop('value');

    this.articol.publicatie.tip = $('#tipPublicatie').prop('value');
    console.log(this.articol.publicatie.tip);
    this.pubs.forEach((element) => {
      if (element.tip == this.articol.publicatie.tip)
        this.articol.publicatie.idTipPublicatie = element.idtipPublicatie;
    });
    this.articol.modPrezentare.tip = $('#modPrezentare').prop('value');
    this.mods.forEach((element) => {
      if (element.tip == this.articol.modPrezentare.tip)
        this.articol.modPrezentare.idmod = element.idmod;
    });
    for (let i = 0; i < this.citationsNumber; i++)
      this.articol.citari[i].nume = $('#citare' + i).prop('value');
    this.deletedCitari.forEach((element) => {
      this.articol.citari.push(element);
    });
    return true;
  }

  isNewAuthor(index: number) {
    console.log($('#autor' + index).prop('value'));
    if ($('#autor' + index).prop('value') == 'Adauga nou') {
      this.articol.autori[index].nume = '';
      this.articol.autori[index].tipAutor = 0;
    }
  }

  addCitations() {
    let temp: Citari = <Citari>{};
    temp.tip = 0;
    this.articol.citari.push(temp);
    this.citationsNumber++;
  }
  removeCitations(index: number) {
    this.articol.citari[index].tip = 4;
    this.deletedCitari.push(this.articol.citari[index]);
    this.articol.citari.splice(index, 1);
    this.citationsNumber--;
  }

  initData() {
    this.route.params.subscribe((params) => {
      this.id = params['id'];
      this.action = params['action'];
      if (this.action == 'create' || this.action == 'update') {
        var utilizator = sessionStorage.getItem('userType');
        if (utilizator == '1') {
          alert('Acces denied!');
          this.router.navigate(['/search']);
        }
      }
      if (this.action != 'create') {
        this.articleService.getArticleByID(this.id).subscribe((res) => {
          this.articol = res;
          console.log(res);
          this.authorsNumber = this.articol.autori.length;
          this.citationsNumber = this.articol.citari.length;
          if (this.action == 'view') {
            this.articleService.addViews(res).subscribe();
          }
        });
      }
    });
  }

  temp() {
    console.log(this.pubs);
    console.log(this.mods);
  }

  ngOnInit(): void {
    this.articleService.getAllMods().subscribe((res) => {
      res.forEach((element) => this.mods.push(element));
    });
    this.articleService.getAllPubs().subscribe((res) => {
      res.forEach((element) => this.pubs.push(element));
    });
    this.authorService.getAllExistingAuthors().subscribe((res) => {
      res.forEach((element) => {
        this.authorsRegistred.push(element);
      });
    });

    this.appComponent.userValidation();
    this.initData();
  }

  constructor(
    private appComponent: AppComponent,
    private router: Router,
    private route: ActivatedRoute,
    private articleService: ArticleService,
    private authorService: AuthorService
  ) {
    this.articol.detalii = <Detalii>{};
    this.articol.publicatie = <Publicatie>{};
    this.articol.modPrezentare = <ModPrezentare>{};
    this.articol.autori = <AutorDetalii[]>[];
    this.articol.citari = <Citari[]>[];
    this.deletedAuthors = <AutorDetalii[]>[];
  }
}
