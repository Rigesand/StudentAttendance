import {Injectable} from '@angular/core'
import {CookieService} from 'ngx-cookie-service'
import jwt_decode from 'jwt-decode'
import {TokenModel} from '../models/TokenModel'

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  constructor(private cookieService: CookieService) {}

  private Issuer = 'StudentAttendance'
  private role = 'Администратор'

  private getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token)
    } catch (Error) {
      return null
    }
  }

  GetJwtFromCookie() {
    return 'Bearer ' + this.cookieService.get('JwtToken')
  }

  SetJwtInCookie(jwt: TokenModel) {
    this.cookieService.set('JwtToken', jwt.accessToken)
    this.cookieService.set('RefreshToken', jwt.refreshToken)
  }

  ValidateToken(token: string) {
    let jwtdecoded = this.getDecodedAccessToken(token)

    if (jwtdecoded.role == this.role && jwtdecoded.iss == this.Issuer) {
      return true
    }
    return false
  }
}
