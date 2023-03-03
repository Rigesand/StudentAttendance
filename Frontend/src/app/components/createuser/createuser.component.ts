import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'app-createuser',
  templateUrl: './createuser.component.html',
  styleUrls: ['./createuser.component.scss'],
})
export class CreateuserComponent implements OnInit {
  constructor(public userService: UserService) {}

  ngOnInit(): void {}

  roles = ['Студент', 'Администратор']

  form = new FormGroup({
    email: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6),
    ]),
    role: new FormControl<string>(this.roles[0]),
  })

  CreateUserAndSendEmail() {
    this.userService
      .CreateUserAndSendEmail({
        email: this.form.value.email as string,
        role: this.form.value.role as string,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.form.controls.email.setValue('')
      })
  }
}
