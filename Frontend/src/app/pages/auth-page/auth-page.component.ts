import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup} from '@angular/forms'
import {CookieService} from 'ngx-cookie-service'
import {Router} from '@angular/router'
import {TokenService} from '../../services/token.service'

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.scss'],
})
export class AuthPageComponent implements OnInit {
  constructor(
    private userService: UserService,
    private cookieService: CookieService,
    private router: Router,
    private tokenService: TokenService
  ) {}

  form = new FormGroup({
    email: new FormControl<string>(''),
    password: new FormControl<string>(''),
  })
  ngOnInit(): void {}

  login() {
    this.userService
      .login({
        email: this.form.value.email as string,
        password: this.form.value.password as string,
      })
      .subscribe((res) => {
        this.tokenService.SetJwtInCookie(res)
        this.userService.getCurrentUser()
        if (this.tokenService.ValidateToken(res.accessToken)) {
          this.router.navigate(['admin/users']).then(() => {})
        } else {
          this.router.navigate(['attendance/students']).then(() => {})
        }
      })
  }
}
