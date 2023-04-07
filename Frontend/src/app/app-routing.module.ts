import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {AuthPageComponent} from './pages/auth-page/auth-page.component'
import {CreateuserPageComponent} from './pages/admin/createuser-page/createuser-page.component'
import {UpdateuserPageComponent} from './pages/admin/updateuser-page/updateuser-page.component'
import {UsersPageComponent} from './pages/admin/users-page/users-page.component'
import {StudentsPageComponent} from './pages/attendance/students-page/students-page.component'
import {CreateStudentPageComponent} from './pages/attendance/create-student-page/create-student-page.component'
import {UpdateStudentPageComponent} from './pages/attendance/update-student-page/update-student-page.component'
import {ProfilePageComponent} from './pages/attendance/profile-page/profile-page.component'
import {AttendancesPageComponent} from './pages/attendance/attendances-page/attendances-page.component'
import {DeleteUserPageComponent} from './pages/admin/delete-user-page/delete-user-page.component'
import {AuthGuardService} from './shared/authGuard.service'
import {DeleteStudentPageComponent} from './pages/attendance/delete-student-page/delete-student-page.component'
import {CreateGroupPageComponent} from './pages/admin/create-group-page/create-group-page.component'

const routes: Routes = [
  {path: '', component: AuthPageComponent},
  {
    path: 'admin/createUser',
    component: CreateuserPageComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/updateUser',
    component: UpdateuserPageComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/deleteUser',
    component: DeleteUserPageComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/users',
    component: UsersPageComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/createGroup',
    component: CreateGroupPageComponent,
    canActivate: [AuthGuardService],
  },
  {path: 'attendance/students', component: StudentsPageComponent},
  {path: 'attendance/createStudent', component: CreateStudentPageComponent},
  {path: 'attendance/updateStudent', component: UpdateStudentPageComponent},
  {path: 'attendance/deleteStudent', component: DeleteStudentPageComponent},
  {path: 'attendance/profile', component: ProfilePageComponent},
  {path: 'attendance/attendances', component: AttendancesPageComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
