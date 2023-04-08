import {NgModule} from '@angular/core'
import {BrowserModule} from '@angular/platform-browser'
import {AppRoutingModule} from './app-routing.module'
import {AppComponent} from './app.component'
import {AuthPageComponent} from './pages/auth-page/auth-page.component'
import {ReactiveFormsModule, FormsModule} from '@angular/forms'
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http'
import {CookieService} from 'ngx-cookie-service'
import {TopbarComponent} from './components/shared/topbar/topbar.component'
import {StudentsComponent} from './components/student/students/students.component'
import {StudentsPageComponent} from './pages/attendance/students-page/students-page.component'
import {UpdateStudentPageComponent} from './pages/attendance/update-student-page/update-student-page.component'
import {UpdateStudentComponent} from './components/student/update-student/update-student.component'
import {CreateStudentPageComponent} from './pages/attendance/create-student-page/create-student-page.component'
import {CreateStudentComponent} from './components/student/create-student/create-student.component'
import {ProfilePageComponent} from './pages/attendance/profile-page/profile-page.component'
import {ProfileComponent} from './components/shared/profile/profile.component'
import {AttendancesPageComponent} from './pages/attendance/attendances-page/attendances-page.component'
import {AttendancesComponent} from './components/student/attendances/attendances.component'
import {TokenService} from './services/token.service'
import {AuthInterseptor} from './shared/authInterseptor.service'
import {StudentService} from './services/student.service'
import {AuthGuardService} from './shared/authGuard.service'
import {DeleteStudentComponent} from './components/student/delete-student/delete-student.component'
import {DeleteStudentPageComponent} from './pages/attendance/delete-student-page/delete-student-page.component'
import {AdminModule} from './admin/admin.module'
import {ToggleMenuModule} from './shared/modules/toggleMenu/toggleMenu.module'

@NgModule({
  declarations: [
    AppComponent,
    AuthPageComponent,
    TopbarComponent,
    StudentsComponent,
    StudentsPageComponent,
    UpdateStudentPageComponent,
    UpdateStudentComponent,
    CreateStudentPageComponent,
    CreateStudentComponent,
    ProfilePageComponent,
    ProfileComponent,
    AttendancesPageComponent,
    AttendancesComponent,
    DeleteStudentComponent,
    DeleteStudentPageComponent,
  ],
  imports: [
    AdminModule,
    ToggleMenuModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
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
    StudentService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
