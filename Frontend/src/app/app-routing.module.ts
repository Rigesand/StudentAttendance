import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthPageComponent} from "./pages/auth-page/auth-page.component";
import {CreateuserPageComponent} from "./pages/admin/createuser-page/createuser-page.component";
import {UpdateuserPageComponent} from "./pages/admin/updateuser-page/updateuser-page.component";
import {UsersPageComponent} from "./pages/admin/users-page/users-page.component";
import {TestPageComponent} from "./pages/test-page/test-page.component";

const routes: Routes = [
  {path:'',component: AuthPageComponent},
  {path:'admin/createUser',component: CreateuserPageComponent},
  {path:'admin/updateUser',component: UpdateuserPageComponent},
  {path:'admin/users',component: UsersPageComponent},
  {path:'admin/test',component: TestPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
