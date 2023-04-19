import {Component, OnInit} from '@angular/core'
import {UserService} from '../../../admin/services/user.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'mc-student-profile',
  templateUrl: 'profileStudent.component.html',
  styleUrls: ['profileStudent.component.scss'],
})
export class ProfileStudentComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.currentUser.email),
    name: new FormControl<string | null>(this.userService.currentUser.name),
    password: new FormControl<string>(''),
  })

  Submit() {
    this.userService
      .UpdateProfile({
        id: this.userService.currentUser.id,
        name: this.form.value.name as string,
        email: this.form.value.email as string,
        password: this.form.value.password as string,
      })
      .subscribe(() => {
        this.userService.getCurrentUser()
      })
  }
}
