import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import {ReactiveFormsModule} from '@angular/forms'

import { authInterceptor } from './Authentication/Interceptor/auth.interceptor';
import { UsersComponent } from './Admin/users/users.component';
import { SigninComponent } from './Authentication/signin/signin.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { CommonModule } from '@angular/common';
import { AttendanceComponent } from './attendance/attendance.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LogoutComponent } from './logout/logout.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SigninComponent,
    SidebarComponent,
    UsersComponent,
    AttendanceComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule ,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'SignIn', component: SigninComponent },
    //  { path: 'User', component: UsersComponent },
      { path: 'Sidebar', component: SidebarComponent,children: [

        { path: 'User', component: UsersComponent },
        { path: 'Attendance', component: AttendanceComponent },
        { path: 'Logout', component: LogoutComponent },

      ], },
    ]),
    CommonModule,
    NgbModule
  ],
  providers: [{ provide: 'BASE_URL', useValue: 'http://localhost:5072/' },
  provideHttpClient(withInterceptors([authInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule { }
