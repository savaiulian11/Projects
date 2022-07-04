import { Component, ElementRef, HostListener, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { ArticleService } from '../apiFiles/Article/articol.service';
import { ArticolExplicit } from '../apiFiles/Article/articolExplicit';
import { User } from '../apiFiles/User/user';
import { Router } from '@angular/router';
import { ModPrezentare } from '../apiFiles/Article/modPrezentare';
import { TipPublicatie } from '../apiFiles/Article/tipPublicatie';
import { Filters } from '../filters';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  focus: boolean = false;
  list: number[] = [];
  mods: ModPrezentare[];
  pubs: TipPublicatie[];
  articole: ArticolExplicit[] = [];
  articoleTemp: ArticolExplicit[] = [];
  user: User;
  tip: number = 0;

  getAllArticles() {
    this.artService.getArticles().subscribe((res) => {
      this.articole = [];
      res.forEach((element) => {
        this.articole.push(element);
      });
      console.log(this.articole);
    });
  }

  sortFilter(sortElement: string) {
    console.log('Filtru sortare aplicat!');
    switch (sortElement) {
      case 'Sortare dupa an':
        this.articole.sort((a, b) => (a.detalii.an > b.detalii.an ? 1 : -1));
        break;
      case 'Sortare dupa nume':
        this.articole.sort((a, b) => (a.nume > b.nume ? 1 : -1));
        break;
    }
  }

  yearFilter() {
    let beginYear = $('#beginYear').prop('value');
    let endYear = $('#endYear').prop('value');
    if (beginYear == '') beginYear = 0;
    if (endYear == '') endYear = 9999;
    console.log('Filtru perioada aplicat!' + beginYear + '-' + endYear);
    $('#beginYear').prop('value', '');
    $('#endYear').prop('value', '');
    let perioada = beginYear + '-' + endYear;
    this.setValue('Perioada:', perioada);
    for (let i = 0; i < this.articole.length; i++)
      if (
        this.articole[i].detalii.an < beginYear ||
        this.articole[i].detalii.an > endYear
      )
        this.list.push(i);
    this.removeData();
  }

  modsFilter(tip: string) {
    console.log(tip);
    console.log('Filtru mod prezentare aplicat!');
    for (let i = 0; i < this.articole.length; i++)
      if (this.articole[i].modPrezentare.tip != tip) this.list.push(i);
    this.removeData();
  }

  pubsFilter(tip: string) {
    console.log('Filtru tip publicatie aplicat!');
    console.log('Filtru: ' + tip);
    for (let i = 0; i < this.articole.length; i++)
      if (this.articole[i].publicatie.tip != tip) this.list.push(i);
    this.removeData();
  }

  searchFilter() {
    console.log('Filtru de nume aplicat!');
    let value: string = $('#searchInput').prop('value');
    this.setValue('Nume:', value);
    if (value == '') {
      this.removeFilter('Nume:');
      return;
    }
    for (let i = 0; i < this.articole.length; i++)
      if (this.articole[i].nume.includes(value) == false) this.list.push(i);
    this.removeData();
  }

  removeData() {
    let total = this.list.length - 1;
    for (let i = total; i >= 0; i--) {
      this.articoleTemp.push(this.articole[this.list[i]]);
      this.articole.splice(this.list[i], 1);
    }
    this.list = [];
  }
  applyFilters(nume: string, value: string) {
    this.setActive(nume, true);
    this.setValue(nume, value);
    this.refreshData();
  }

  removeFilter(nume: string) {
    this.setActive(nume, false);
    this.setValue(nume, '');
    this.refreshData();
  }

  refreshData() {
    this.articoleTemp.forEach((element) => {
      this.articole.push(element);
    });
    this.articoleTemp = [];
    this.articole.sort((a, b) => (a.idarticol > b.idarticol ? 1 : -1));
    console.log(this.filters);
    this.filters.forEach((element) => {
      switch (element.name) {
        case 'Perioada:':
          if (element.active) this.yearFilter();
          break;
        case 'Publicatie:':
          if (element.active) this.pubsFilter(this.getValue('Publicatie:'));
          break;
        case 'Mod Prezentare:':
          console.log('aici');
          if (element.active) this.modsFilter(this.getValue('Mod Prezentare:'));
          break;
        case 'Sortare:':
          if (element.active) this.sortFilter(this.getValue('Sortare:'));
          break;
        case 'Nume:':
          if (element.active) this.searchFilter();
          break;
      }
    });
    console.log(this.articole);
  }

  showData(item: ArticolExplicit) {
    sessionStorage.setItem('lastPage', 'search');
    let user = sessionStorage.getItem('userType');
    if (user == '3') this.route.navigate(['/article/update/' + item.idarticol]);
    else this.route.navigate(['/article/view/' + item.idarticol]);
  }

  constructor(
    private appComponent: AppComponent,
    private artService: ArticleService,
    private route: Router
  ) {
    this.getAllArticles();
    this.mods = [];
    this.pubs = [];
  }
  ngOnInit(): void {
    this.appComponent.userValidation();
    this.artService.getAllPubs().subscribe((res) => {
      res.forEach((element) => {
        this.pubs.push(element);
      });
    });
    this.artService.getAllMods().subscribe((res) => {
      res.forEach((element) => this.mods.push(element));
    });
    let myFilters: string[] = [
      'Publicatie:',
      'Mod Prezentare:',
      'Perioada:',
      'Sortare:',
      'Nume:',
    ];
    this.setName(myFilters);
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
      if (this.focus == true) this.applyFilters(':', 'nume');
    }
  }

  filters: Filters[] = [];

  /**Setare nume pentru filtre */
  setName(names: string[]) {
    names.forEach((element) => {
      this.filters.push(<Filters>{
        name: element,
        active: false,
      });
    });
  }
  /**Setare filtru activ/inactiv */
  setActive(name: string, value: boolean) {
    if (value == false) console.log('Filtru ' + name + ' dezactivat');
    this.filters.forEach((element) => {
      if (element.name == name) element.active = value;
    });
  }

  /**Setare valoare pentru filtru */
  setValue(name: string, value: string) {
    this.filters.forEach((element) => {
      if (element.name == name) element.value = value;
    });
  }

  /**Intoarecere valoare pentru filtru */
  getValue(name: string) {
    let returnValue: string = <string>{};
    this.filters.forEach((element) => {
      if (element.name == name) returnValue = element.value;
    });
    return returnValue;
  }
}
