import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(public userService:UserService) { }
  term: string=""
  ngOnInit(): void {
    this.userService.getAll().subscribe(() => {
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
    DeleteUser()
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
    }
}
