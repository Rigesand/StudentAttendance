import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthPageComponent} from "./pages/auth-page/auth-page.component";
import {CreateuserPageComponent} from "./pages/admin/createuser-page/createuser-page.component";
import {UpdateuserPageComponent} from "./pages/admin/updateuser-page/updateuser-page.component";
import {DeleteuserPageComponent} from "./pages/admin/deleteuser-page/deleteuser-page.component";

const routes: Routes = [
  {path:'',component: AuthPageComponent},
  {path:'admin/createUser',component: CreateuserPageComponent},
  {path:'admin/updateUser',component: UpdateuserPageComponent},
  {path:'admin/deleteUser',component: DeleteuserPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
