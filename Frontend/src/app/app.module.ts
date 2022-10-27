import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPageComponent } from './pages/auth-page/auth-page.component';
import {ReactiveFormsModule,FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {CookieService} from "ngx-cookie-service";
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { CreateuserComponent } from './components/createuser/createuser.component';
import { CreateuserPageComponent } from './pages/admin/createuser-page/createuser-page.component';
import { UpdateuserPageComponent } from './pages/admin/updateuser-page/updateuser-page.component';
import { UpdateuserComponent } from './components/updateuser/updateuser.component';
import { FilterUsersPipe } from './pipes/filter-users.pipe';
import { UsersComponent } from './components/users/users.component';
import { UsersPageComponent } from './pages/admin/users-page/users-page.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthPageComponent,
    SidebarComponent,
    CreateuserComponent,
    CreateuserPageComponent,
    UpdateuserPageComponent,
    UpdateuserComponent,
    FilterUsersPipe,
    UsersComponent,
    UsersPageComponent
  ],
    imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule
    ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
