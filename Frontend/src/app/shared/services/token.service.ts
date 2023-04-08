import {Injectable} from '@angular/core'
import {CookieService} from 'ngx-cookie-service'
import jwt_decode from 'jwt-decode'
import {ITokenResponse} from '../../auth/types/TokenResponse'
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  constructor(private cookieService: CookieService, private http: HttpClient) {}

  private Issuer = 'StudentAttendance'
  private role = 'Администратор'

  private getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token)
    } catch (Error) {
      return null
    }
  }

  GetJwtFromCookie(): string {
    return 'Bearer ' + this.cookieService.get('JwtToken')
  }

  SetJwtInCookie(jwt: ITokenResponse) {
    this.cookieService.set('JwtToken', jwt.accessToken)
    this.cookieService.set('RefreshToken', jwt.refreshToken)
  }

  GetRefreshFromCookie(): string {
    return this.cookieService.get('RefreshToken')
  }

  SendRefreshToken() {
    this.http
      .post<ITokenResponse>('/api/Auth/GetRefreshToken', {
        refreshToken: this.GetRefreshFromCookie(),
      })
      .subscribe((res) => {
        this.SetJwtInCookie(res)
      })
  }

  ValidateToken(token: string) {
    let jwtdecoded = this.getDecodedAccessToken(token)

    if (jwtdecoded.role == this.role && jwtdecoded.iss == this.Issuer) {
      return true
    }
    return false
  }

  IsAdmin() {
    return this.ValidateToken(this.GetJwtFromCookie())
  }
}
