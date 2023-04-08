import {NgModule} from '@angular/core'
import {BrowserModule} from '@angular/platform-browser'
import {AppRoutingModule} from './app-routing.module'
import {AppComponent} from './app.component'
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http'
import {CookieService} from 'ngx-cookie-service'
import {ProfileComponent} from './components/shared/profile/profile.component'
import {TokenService} from './shared/services/token.service'
import {AuthInterseptor} from './shared/services/authInterseptor.service'
import {AuthGuardService} from './shared/services/authGuard.service'
import {AdminModule} from './admin/admin.module'
import {ToggleMenuModule} from './shared/modules/toggleMenu/toggleMenu.module'
import {StudentModule} from './student/student.module'
import {AuthModule} from './auth/auth.module'
import {ReactiveFormsModule} from '@angular/forms'

@NgModule({
  declarations: [AppComponent, ProfileComponent],
  imports: [
    AdminModule,
    ToggleMenuModule,
    StudentModule,
    AuthModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterseptor,
      multi: true,
    },
    HttpClient,
    CookieService,
    TokenService,
  ],
  bootstrap: [AppComponent],
  exports: [],
})
export class AppModule {}
