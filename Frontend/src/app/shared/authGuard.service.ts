import {CanActivate, Router} from '@angular/router'
import {TokenService} from '../services/token.service'
import {Injectable} from '@angular/core'

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public tokenService: TokenService, public router: Router) {}
  canActivate(): boolean {
    if (!this.tokenService.IsAdmin()) {
      this.router.navigate(['']).then(() => {})
      return false
    }
    return true
  }
}
