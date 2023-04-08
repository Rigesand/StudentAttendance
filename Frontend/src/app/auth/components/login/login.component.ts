import {Component, OnInit} from '@angular/core'
import {UserService} from '../../../admin/services/user.service'
import {CookieService} from 'ngx-cookie-service'
import {Router} from '@angular/router'
import {TokenService} from '../../../shared/services/token.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'mc-login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.scss'],
})
export class LoginComponent implements OnInit {
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

  Submit() {
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
