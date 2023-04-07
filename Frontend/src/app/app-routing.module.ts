import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {AuthPageComponent} from './pages/auth-page/auth-page.component'
import {StudentsPageComponent} from './pages/attendance/students-page/students-page.component'
import {CreateStudentPageComponent} from './pages/attendance/create-student-page/create-student-page.component'
import {UpdateStudentPageComponent} from './pages/attendance/update-student-page/update-student-page.component'
import {ProfilePageComponent} from './pages/attendance/profile-page/profile-page.component'
import {AttendancesPageComponent} from './pages/attendance/attendances-page/attendances-page.component'
import {DeleteStudentPageComponent} from './pages/attendance/delete-student-page/delete-student-page.component'

const routes: Routes = [
  {path: '', component: AuthPageComponent},
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
