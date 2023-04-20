import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {CreateUserComponent} from './components/createUser/createUser.component'
import {ReactiveFormsModule} from '@angular/forms'
import {AuthGuardService} from '../shared/services/authGuard.service'
import {UpdateUserComponent} from './components/updateUser/updateUser.component'
import {DeleteUserComponent} from './components/deleteUser/deleteUser.component'
import {UsersComponent} from './components/users/users.component'
import {FilterUsersPipe} from '../shared/pipes/filter-users.pipe'
import {NgForOf} from '@angular/common'
import {UserService} from './services/user.service'
import {CreateGroupComponent} from './components/createGroup/createGroup.component'
import {GroupService} from './services/group.service'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {SidebarAdminComponent} from './components/sidebarAdmin/sidebarAdmin.component'
import {ProfileAdminComponent} from './components/profileAdmin/profileAdmin.component'
import {GroupsComponent} from './components/groups/groups.component'
import {DeleteGroupComponent} from './components/deleteGroup/deleteGroup.component'

const routes: Routes = [
  {
    path: 'admin/create',
    component: CreateUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/update',
    component: UpdateUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/delete',
    component: DeleteUserComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/users',
    component: UsersComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/createGroup',
    component: CreateGroupComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/profile',
    component: ProfileAdminComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/groups',
    component: GroupsComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'admin/deleteGroup',
    component: DeleteGroupComponent,
    canActivate: [AuthGuardService],
  },
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    NgForOf,
    AngularSvgIconModule.forRoot(),
  ],
  declarations: [
    FilterUsersPipe,
    CreateUserComponent,
    UpdateUserComponent,
    DeleteUserComponent,
    UsersComponent,
    CreateGroupComponent,
    DeleteGroupComponent,
    GroupsComponent,
    ProfileAdminComponent,
    SidebarAdminComponent,
  ],
  providers: [UserService, GroupService],
  exports: [FilterUsersPipe],
})
export class AdminModule {}
