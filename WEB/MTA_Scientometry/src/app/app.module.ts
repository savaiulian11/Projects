import { BrowserModule } from '@angular/platform-browser';
import { Injectable, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientJsonpModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { IndexComponent } from './index/index.component';
import { RegisterComponent } from './register/register.component';
import { ForgotAccountComponent } from './forgot-account/forgot-account.component';
import { HomeComponent } from './home/home.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { SearchComponent } from './search/search.component';
import { MyPublicationsComponent } from './my-publications/my-publications.component';
import { UsersManagementComponent } from './users-management/users-management.component';
import { ArticleComponent } from './article/article.component';

import { UserService } from './apiFiles/User/user.service';
import { AuthorService } from './apiFiles/Author/autori.service';
import { ArticleService } from './apiFiles/Article/articol.service';

@Injectable({
  providedIn: 'root',
})
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    IndexComponent,
    RegisterComponent,
    ForgotAccountComponent,
    HomeComponent,
    MyAccountComponent,
    SearchComponent,
    MyPublicationsComponent,
    UsersManagementComponent,
    ArticleComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientJsonpModule,
    HttpClientModule,
  ],
  providers: [UserService, AuthorService, ArticleService],
  bootstrap: [AppComponent],
})
export class AppModule {}
