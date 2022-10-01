import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IloginUserDto} from "../models/loginUserDto";
import {Observable} from "rxjs";
import {AuthResult} from "../models/authResult";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }


  login(loginUser:IloginUserDto):Observable<AuthResult>
  {
    return this.http.post<AuthResult>("/api/User/Login",loginUser).pipe()
  }

  registration(loginUser:IloginUserDto):Observable<AuthResult>
  {
    return this.http.post<AuthResult>("/api/User/Register",loginUser).pipe()
  }
}
