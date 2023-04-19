import {NgModule} from '@angular/core'
import {CreateStudentComponent} from './components/createStudent/createStudent.component'
import {ReactiveFormsModule} from '@angular/forms'
import {RouterModule, Routes} from '@angular/router'
import {UpdateStudentComponent} from './components/updateStudent/updateStudent.component'
import {DeleteStudentComponent} from './components/deleteStudent/deleteStudent.component'
import {StudentsComponent} from './components/students/students.component'
import {NgForOf} from '@angular/common'
import {AttendancesComponent} from './components/attendances/attendances.component'
import {StudentService} from './services/student.service'
import {SidebarStudentComponent} from './components/sidebarStudent/sidebarStudent.component'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {ProfileStudentComponent} from './components/profileStudent/profileStudent.component'

const routes: Routes = [
  {
    path: 'attendance/createStudent',
    component: CreateStudentComponent,
  },
  {
    path: 'attendance/updateStudent',
    component: UpdateStudentComponent,
  },
  {
    path: 'attendance/deleteStudent',
    component: DeleteStudentComponent,
  },
  {
    path: 'attendance/students',
    component: StudentsComponent,
  },
  {
    path: 'attendances',
    component: AttendancesComponent,
  },
  {
    path: 'attendances/profile',
    component: ProfileStudentComponent,
  },
]

@NgModule({
  imports: [
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    NgForOf,
    AngularSvgIconModule,
  ],
  declarations: [
    CreateStudentComponent,
    UpdateStudentComponent,
    DeleteStudentComponent,
    StudentsComponent,
    AttendancesComponent,
    ProfileStudentComponent,
    SidebarStudentComponent,
  ],
  providers: [StudentService],
  exports: [],
})
export class StudentModule {}
