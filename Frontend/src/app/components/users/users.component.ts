import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(public userService:UserService,
  private cookieService: CookieService) { }
  term: string=""
  ngOnInit(): void {
    this.userService.getAll(this.cookieService.get("JwtToken")).subscribe(() => {
    });
  }
    form = new FormGroup(
      {
        email: new FormControl<string>('', [
          Validators.required,
          Validators.minLength(6)
        ]),
        role: new FormControl<string>("")
      }
    )
    /*DeleteUser()
    {
      this.userService.Delete(
        {
          email: this.form.value.email as string,
          role: this.form.value.role as string,
        }
      ).subscribe(()=>
      {
        this.form.controls.email.setValue('')
      })
    }*/
}
