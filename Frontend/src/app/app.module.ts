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
import {SidebarComponent} from './components/shared/sidebar/sidebar.component'
import {CreateuserComponent} from './components/user/createuser/createuser.component'
import {CreateuserPageComponent} from './pages/admin/createuser-page/createuser-page.component'
import {UpdateuserPageComponent} from './pages/admin/updateuser-page/updateuser-page.component'
import {UpdateuserComponent} from './components/user/updateuser/updateuser.component'
import {FilterUsersPipe} from './pipes/filter-users.pipe'
import {UsersComponent} from './components/user/users/users.component'
import {UsersPageComponent} from './pages/admin/users-page/users-page.component'
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
import {DeleteUserComponent} from './components/user/delete-user/delete-user.component'
import {DeleteUserPageComponent} from './pages/admin/delete-user-page/delete-user-page.component'
import {AuthInterseptor} from './shared/authInterseptor.service'
import {UserService} from './services/user.service'
import {StudentService} from './services/student.service'
import {AuthGuardService} from './shared/authGuard.service'
import {DeleteStudentComponent} from './components/student/delete-student/delete-student.component'
import {DeleteStudentPageComponent} from './pages/attendance/delete-student-page/delete-student-page.component'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {CreateGroupComponent} from './components/group/create-group/create-group.component'
import {GroupService} from './services/group.service';
import { CreateGroupPageComponent } from './pages/admin/create-group-page/create-group-page.component'

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
    DeleteStudentComponent,
    DeleteStudentPageComponent,
    CreateGroupComponent,
    CreateGroupPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AngularSvgIconModule.forRoot(),
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
    UserService,
    StudentService,
    GroupService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
