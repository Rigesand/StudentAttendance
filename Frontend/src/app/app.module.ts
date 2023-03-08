import {NgModule} from '@angular/core'
import {BrowserModule} from '@angular/platform-browser'
import {AppRoutingModule} from './app-routing.module'
import {AppComponent} from './app.component'
import {AuthPageComponent} from './pages/auth-page/auth-page.component'
import {ReactiveFormsModule, FormsModule} from '@angular/forms'
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import {CookieService} from 'ngx-cookie-service'
import {SidebarComponent} from './components/sidebar/sidebar.component'
import {CreateuserComponent} from './components/createuser/createuser.component'
import {CreateuserPageComponent} from './pages/admin/createuser-page/createuser-page.component'
import {UpdateuserPageComponent} from './pages/admin/updateuser-page/updateuser-page.component'
import {UpdateuserComponent} from './components/updateuser/updateuser.component'
import {FilterUsersPipe} from './pipes/filter-users.pipe'
import {UsersComponent} from './components/users/users.component'
import {UsersPageComponent} from './pages/admin/users-page/users-page.component'
import {TopbarComponent} from './components/topbar/topbar.component'
import {StudentsComponent} from './components/students/students.component'
import {StudentsPageComponent} from './pages/attendance/students-page/students-page.component'
import {UpdateStudentPageComponent} from './pages/attendance/update-student-page/update-student-page.component'
import {UpdateStudentComponent} from './components/update-student/update-student.component'
import {CreateStudentPageComponent} from './pages/attendance/create-student-page/create-student-page.component'
import {CreateStudentComponent} from './components/create-student/create-student.component'
import {ProfilePageComponent} from './pages/attendance/profile-page/profile-page.component'
import {ProfileComponent} from './components/profile/profile.component'
import {AttendancesPageComponent} from './pages/attendance/attendances-page/attendances-page.component'
import {AttendancesComponent} from './components/attendances/attendances.component'
import {TokenService} from './services/token.service'
import {DeleteUserComponent} from './components/delete-user/delete-user.component'
import {DeleteUserPageComponent} from './pages/admin/delete-user-page/delete-user-page.component'
import {AuthInterseptor} from './shared/authInterseptor.service'
import {UserService} from './services/user.service'
import {StudentService} from './services/student.service'

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
    UsersPageComponent,
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
    DeleteUserComponent,
    DeleteUserPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    CookieService,
    TokenService,
    UserService,
    StudentService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterseptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
