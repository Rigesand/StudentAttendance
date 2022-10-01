import { Component, OnInit } from '@angular/core';
import {ChiefService} from "../../services/chief.service";
import {UserService} from "../../services/user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent implements OnInit {

  constructor(public chiefService: ChiefService,
              public userService:UserService) { }

  ngOnInit(): void {
    this.chiefService.getAll()
  }

  form = new FormGroup(
    {
      email: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(6)
      ]),
      password: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(6)
      ])
    }
  )

  registration()
  {
    this.userService.registration(
      {
        email: this.form.value.email as string,
        password: this.form.value.password as string
      }
    ).subscribe((res)=>
    {

    })
  }

}
