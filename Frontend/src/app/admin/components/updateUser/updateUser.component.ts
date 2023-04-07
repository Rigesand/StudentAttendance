import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {UserService} from '../../services/user.service'
import {Router} from '@angular/router'

@Component({
  selector: 'mc-updateUser',
  templateUrl: 'updateUser.component.html',
  styleUrls: ['updateUser.component.scss'],
})
export class UpdateUserComponent implements OnInit {
  constructor(public userService: UserService, private router: Router) {}
  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.editUser.email),
    groupNumber: new FormControl<string>(this.userService.editUser.groupNumber),
  })

  Submit() {
    this.userService
      .UpdateUser({
        id: this.userService.editUser.id,
        email: this.form.value.email as string,
        groupNumber: this.form.value.groupNumber as string,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.router.navigate(['admin/users']).then(() => {})
      })
  }
}
