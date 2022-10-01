import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPageComponent } from './pages/auth-page/auth-page.component';
import {ReactiveFormsModule,FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {CookieService} from "ngx-cookie-service";
import { AdminPageComponent } from './pages/admin-page/admin-page.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { SidebarPanelComponent } from './components/sidebar-panel/sidebar-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthPageComponent,
    AdminPageComponent,
    CreateUserComponent,
    SidebarPanelComponent
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
