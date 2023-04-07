import {Component, OnInit} from '@angular/core'
import {UserService} from '../../../services/user.service'
import {FormControl, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'app-createuser',
  templateUrl: './createuser.component.html',
  styleUrls: ['./createuser.component.scss'],
})
export class CreateuserComponent implements OnInit {
  constructor(public userService: UserService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6),
    ]),
    groupNumber: new FormControl<string>(''),
  })

  CreateUserAndSendEmail() {
    this.userService
      .CreateUserAndSendEmail({
        id: null,
        email: this.form.value.email as string,
        groupNumber: this.form.value.groupNumber as string,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.form.controls.email.setValue('')
        this.form.controls.groupNumber.setValue('')
      })
  }
}
