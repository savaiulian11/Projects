import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { IndexComponent } from './index/index.component';
import { ForgotAccountComponent } from './forgot-account/forgot-account.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { SearchComponent } from './search/search.component';
import { MyPublicationsComponent } from './my-publications/my-publications.component';
import { UsersManagementComponent } from './users-management/users-management.component';
import { ArticleComponent } from './article/article.component';

const routes: Routes = [
  { path: '', redirectTo: '/index', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'index', component: IndexComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'forgot-account', component: ForgotAccountComponent },
  { path: 'home', component: HomeComponent },
  { path: 'my-account', component: MyAccountComponent },
  { path: 'search', component: SearchComponent },
  { path: 'my-publications', component: MyPublicationsComponent },
  { path: 'users-management', component: UsersManagementComponent },
  { path: 'article/:action/:id', component: ArticleComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
