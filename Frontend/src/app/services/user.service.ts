import {Injectable} from '@angular/core'
import {HttpClient, HttpParams} from '@angular/common/http'
import {IUserResponse} from '../models/Users/UserResponse'
import {Observable, retry, tap} from 'rxjs'
import {ITokenResponse} from '../models/Auth/TokenResponse'
import {IUserRequest} from '../models/Users/UserRequest'
import {ILoginRequest} from '../models/Auth/LoginRequest'

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  users: IUserResponse[] = []
  editUser: IUserResponse
  deleteUser: IUserResponse
  currentUser: IUserResponse

  login(loginUser: ILoginRequest): Observable<ITokenResponse> {
    return this.http.post<ITokenResponse>('/api/Auth/Login', loginUser).pipe()
  }

  CreateUserAndSendEmail(createUser: IUserRequest) {
    return this.http.post<IUserResponse>(
      '/api/User/CreateUserAndSendEmail',
      createUser
    )
  }

  UpdateUser(updateUser: IUserRequest) {
    return this.http.put('/api/User/UpdateUser', updateUser)
  }

  DeleteUser(deleteUser: IUserRequest) {
    return this.http.post('/api/User/DeleteUser', deleteUser)
  }

  getAll(): Observable<IUserResponse[]> {
    return this.http
      .get<IUserResponse[]>('/api/User/GetAllUsers', {
        params: new HttpParams({
          fromObject: {limit: 10},
        }),
      })
      .pipe(
        retry(2),
        tap((users) => (this.users = users))
      )
  }

  getCurrentUser() {
    this.http
      .get<IUserResponse>('/api/Auth/GetCurrentUser')
      .subscribe((res) => {
        this.currentUser = res
      })
  }
}
