import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {ReactiveFormsModule} from '@angular/forms'
import {NgForOf} from '@angular/common'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {AuthGuardService} from '../shared/services/authGuard.service'
import {UpdateUserComponent} from '../admin/components/updateUser/updateUser.component'
import {LessonService} from './services/lesson.service'
import {CreateLessonComponent} from './components/createLesson/createLesson.component'
import {AdminModule} from '../admin/admin.module'
import {DeleteLessonComponent} from './components/deleteLesson/deleteLesson.component'
import {LessonsComponent} from './components/lessons/lessons.component'

const routes: Routes = [
  {
    path: 'admin/lesson/create',
    component: CreateLessonComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/lesson/update',
    component: UpdateUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/lesson/delete',
    component: DeleteLessonComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/lessons',
    component: LessonsComponent,
    canActivate: [AuthGuardService],
  },
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    NgForOf,
    AngularSvgIconModule.forRoot(),
    AdminModule,
  ],
  declarations: [
    CreateLessonComponent,
    DeleteLessonComponent,
    LessonsComponent,
  ],
  providers: [LessonService],
  exports: [],
})
export class LessonModule {}
