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

const routes: Routes = [
  {path: '', component: AuthPageComponent},
  {path: 'admin/createUser', component: CreateuserPageComponent},
  {path: 'admin/updateUser', component: UpdateuserPageComponent},
  {path: 'admin/users', component: UsersPageComponent},
  {path: 'attendance/students', component: StudentsPageComponent},
  {path: 'attendance/createStudent', component: CreateStudentPageComponent},
  {path: 'attendance/updateStudent', component: UpdateStudentPageComponent},
  {path: 'attendance/profile', component: ProfilePageComponent},
  {path: 'attendance/attendances', component: AttendancesPageComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
