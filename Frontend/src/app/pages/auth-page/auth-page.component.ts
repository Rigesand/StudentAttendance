import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup} from "@angular/forms";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.scss']
})
export class AuthPageComponent implements OnInit {

  constructor(private userService: UserService,
              private cookieService: CookieService,
              private router: Router) {
  }

  form=new FormGroup(
    {
      email: new FormControl<string>(''),
      password: new FormControl<string>('')
    }
  )
  ngOnInit(): void {
  }

  login()
  {
    this.userService.login(
      {
        email: this.form.value.email as string,
        password: this.form.value.password as string
      }
    ).subscribe((res)=>
    {
      if(res.success)
      {
        this.cookieService.set("JwtToken",res.token)
        this.cookieService.set("RefreshToken",res.refreshToken)
        this.router.navigate(['admin'])
      }
    })
  }
}
