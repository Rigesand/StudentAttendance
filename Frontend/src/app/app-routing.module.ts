import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthPageComponent} from "./pages/auth-page/auth-page.component";
import {AdminPageComponent} from "./pages/admin-page/admin-page.component";

const routes: Routes = [
  {path:'',component: AuthPageComponent},
  {path:'admin',component: AdminPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
