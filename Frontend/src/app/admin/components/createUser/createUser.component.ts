import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup} from '@angular/forms'
import {GroupService} from '../../services/group.service'

@Component({
  selector: 'mc-createUser',
  templateUrl: 'createUser.component.html',
  styleUrls: ['createUser.component.scss'],
})
export class CreateUserComponent implements OnInit {
  constructor(
    public userService: UserService,
    public groupService: GroupService
  ) {}

  ngOnInit(): void {
    this.groupService.getAll().subscribe()
  }

  form = new FormGroup({
    email: new FormControl<string>(''),
    groupNumber: new FormControl<string>(''),
  })

  Submit() {
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
