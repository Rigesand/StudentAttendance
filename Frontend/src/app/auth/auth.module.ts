import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {ReactiveFormsModule} from '@angular/forms'
import {UserService} from '../admin/services/user.service'
import {LoginComponent} from './components/login/login.component'

const routes: Routes = [{path: '', component: LoginComponent}]
@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule],
  declarations: [LoginComponent],
  providers: [UserService],
})
export class AuthModule {}
