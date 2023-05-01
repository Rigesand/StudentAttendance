import {NgModule} from '@angular/core'
import {CreateStudentComponent} from './components/createStudent/createStudent.component'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'
import {RouterModule, Routes} from '@angular/router'
import {UpdateStudentComponent} from './components/updateStudent/updateStudent.component'
import {DeleteStudentComponent} from './components/deleteStudent/deleteStudent.component'
import {StudentsComponent} from './components/students/students.component'
import {AsyncPipe, NgForOf} from '@angular/common'
import {AttendancesComponent} from './components/attendances/attendances.component'
import {StudentService} from './services/student.service'
import {SidebarStudentComponent} from './components/sidebarStudent/sidebarStudent.component'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {ProfileStudentComponent} from './components/profileStudent/profileStudent.component'
import {FilterLessonsPipe} from './pipes/filter-lessons.pipe'
import {MatAutocompleteModule} from '@angular/material/autocomplete'
import {MatInputModule} from '@angular/material/input'
import {AttendanceService} from './services/attendance.service'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'

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
    FormsModule,
    MatAutocompleteModule,
    BrowserAnimationsModule,
    MatInputModule,
    AsyncPipe,
  ],
  declarations: [
    CreateStudentComponent,
    UpdateStudentComponent,
    DeleteStudentComponent,
    StudentsComponent,
    AttendancesComponent,
    ProfileStudentComponent,
    SidebarStudentComponent,
    FilterLessonsPipe,
  ],
  providers: [StudentService, AttendanceService],
  exports: [],
})
export class StudentModule {}
