import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {ReactiveFormsModule} from '@angular/forms'
import {NgForOf} from '@angular/common'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {AuthGuardService} from '../shared/services/authGuard.service'
import {UpdateUserComponent} from '../admin/components/updateUser/updateUser.component'
import {DeleteUserComponent} from '../admin/components/deleteUser/deleteUser.component'
import {UsersComponent} from '../admin/components/users/users.component'
import {LessonService} from './services/lesson.service'
import {CreateLessonComponent} from './components/createLesson/createLesson.component'
import {AdminModule} from '../admin/admin.module'

const routes: Routes = [
  {
    path: 'admin/lesson/create',
    component: CreateLessonComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'lesson/update',
    component: UpdateUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'lesson/delete',
    component: DeleteUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'lesson/users',
    component: UsersComponent,
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
  declarations: [CreateLessonComponent],
  providers: [LessonService],
  exports: [],
})
export class LessonModule {}
