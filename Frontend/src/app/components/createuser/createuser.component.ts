import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-createuser',
  templateUrl: './createuser.component.html',
  styleUrls: ['./createuser.component.scss']
})
export class CreateuserComponent implements OnInit {

  constructor(public userService:UserService) { }

  ngOnInit(): void {
    this.userService.getAll().subscribe(()=>
    {
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

  CreateUserAndSendEmail()
  {
    this.userService.CreateUserAndSendEmail(
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
