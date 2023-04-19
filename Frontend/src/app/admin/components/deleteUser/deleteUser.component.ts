import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {Router} from '@angular/router'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'mc-deleteUser',
  templateUrl: 'deleteUser.component.html',
  styleUrls: ['deleteUser.component.scss'],
})
export class DeleteUserComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.deleteUser.email),
    groupNumber: new FormControl<string>(
      this.userService.deleteUser.groupNumber
    ),
  })

  Submit() {
    this.userService
      .DeleteUser({
        id: this.userService.deleteUser.id,
        email: this.form.value.email as string,
        groupNumber: this.form.value.groupNumber as string,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.router.navigate(['admin/users']).then(() => {})
      })
  }
}
