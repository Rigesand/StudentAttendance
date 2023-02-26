import {Injectable} from '@angular/core'
import {HttpClient, HttpParams} from '@angular/common/http'
import {IUserDto} from '../models/UserDto'
import {Observable, retry, tap} from 'rxjs'
import {TokenModel} from '../models/TokenModel'
import jwt_decode from 'jwt-decode'
import {CookieService} from 'ngx-cookie-service'

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}

  users: IUserDto[] = []
  private Issuer = 'StudentAttendance'
  private role = 'Администратор'

  login(loginUser: IUserDto): Observable<TokenModel> {
    return this.http.post<TokenModel>('/api/Auth/Login', loginUser).pipe()
  }

  CreateUserAndSendEmail(createUser: IUserDto): Observable<IUserDto> {
    return this.http
      .post<IUserDto>('/api/User/CreateUserAndSendEmail', createUser, {
        headers: {
          Authorization: 'Bearer ' + this.cookieService.get('JwtToken'),
        },
      })
      .pipe(tap((newUser) => this.users.push(newUser)))
  }

  getAll(jwt: string): Observable<IUserDto[]> {
    let key = 'Bearer ' + jwt
    return this.http
      .get<IUserDto[]>('/api/User/GetAllUsers', {
        headers: {
          Authorization: key,
        },
        params: new HttpParams({
          fromObject: {limit: 10},
        }),
      })
      .pipe(
        retry(2),
        tap((users) => (this.users = users))
      )
  }
  ValidateToken(token: string) {
    let jwtdecoded = this.getDecodedAccessToken(token)

    if (jwtdecoded.role == this.role && jwtdecoded.iss == this.Issuer) {
      return true
    }
    return false
  }

  private getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token)
    } catch (Error) {
      return null
    }
  }
  /*Delete(deleteUser:IUserDto) :Observable<boolean>
  {
    return this.http.post<boolean>("/api/User/Delete",deleteUser)
      .pipe(
        tap(this.getAll())
      )
  }*/
}
