import {Injectable} from '@angular/core'
import {HttpClient, HttpParams} from '@angular/common/http'
import {IUserResponse} from '../types/UserResponse'
import {Observable, retry, tap} from 'rxjs'
import {ITokenResponse} from '../../auth/types/TokenResponse'
import {IUserRequest} from '../types/UserRequest'
import {ILoginRequest} from '../../auth/types/LoginRequest'
import {IProfileRequest} from '../../models/Profiles/ProfileRequest'

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

  UpdateProfile(profileRequest: IProfileRequest) {
    return this.http.post('/api/Profile/ChangeUserData', profileRequest)
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

  getCurrentUser(): Observable<IUserResponse> {
    return this.http.get<IUserResponse>('/api/Auth/GetCurrentUser')
  }
}
