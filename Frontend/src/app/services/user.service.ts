import {Injectable} from '@angular/core'
import {HttpClient, HttpParams} from '@angular/common/http'
import {IUserDto} from '../models/UserDto'
import {Observable, retry, tap} from 'rxjs'
import {TokenModel} from '../models/TokenModel'
import {CookieService} from 'ngx-cookie-service'
import {TokenService} from './token.service'

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(
    private http: HttpClient,
    private cookieService: CookieService,
    private tokenService: TokenService
  ) {}

  users: IUserDto[] = []

  login(loginUser: IUserDto): Observable<TokenModel> {
    return this.http.post<TokenModel>('/api/Auth/Login', loginUser).pipe()
  }

  CreateUserAndSendEmail(createUser: IUserDto): Observable<IUserDto> {
    return this.http
      .post<IUserDto>('/api/User/CreateUserAndSendEmail', createUser, {
        headers: {
          Authorization: this.tokenService.GetJwtFromCookie(),
        },
      })
      .pipe(tap((newUser) => this.users.push(newUser)))
  }

  getAll(): Observable<IUserDto[]> {
    return this.http
      .get<IUserDto[]>('/api/User/GetAllUsers', {
        headers: {
          Authorization: this.tokenService.GetJwtFromCookie(),
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
}
