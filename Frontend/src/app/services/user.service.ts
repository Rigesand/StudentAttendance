import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {IUserDto} from "../models/UserDto";
import {Observable, retry, tap} from "rxjs";
import {AuthResult} from "../models/authResult";


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  users: IUserDto[]=[]


  /*login(loginUser:IUserDto):Observable<AuthResult>
  {
    return this.http.post<AuthResult>("/api/User/Login",loginUser).pipe()
  }*/

  CreateUserAndSendEmail(createUser:IUserDto):Observable<IUserDto>
  {
    return this.http.post<IUserDto>("/api/User/CreateUserAndSendEmail",createUser)
      .pipe(
        tap(newUser=>this.users.push(newUser))
      )
  }

  getAll():Observable<IUserDto[]>
  {
    return this.http.get<IUserDto[]>("/api/User/GetAllUsers",
      {
        params: new HttpParams(
          {
            fromObject:{limit:10}
          })
      }).pipe(
      retry(2),
      tap(users=>this.users=users)
    )
  }
  Delete(deleteUser:IUserDto) :Observable<boolean>
  {
    return this.http.post<boolean>("/api/User/Delete",deleteUser)
      .pipe(
        tap(this.getAll())
      )
  }
}
