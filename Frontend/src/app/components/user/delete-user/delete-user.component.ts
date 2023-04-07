import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {UserService} from '../../../services/user.service'
import {Router} from '@angular/router'

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss'],
})
export class DeleteUserComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.deleteUser.email),
    groupNumber: new FormControl<number>(
      this.userService.deleteUser.groupNumber
    ),
  })

  DeleteUser() {
    this.userService
      .DeleteUser({
        id: this.userService.deleteUser.id,
        email: this.form.value.email as string,
        groupNumber: this.form.value.groupNumber as number,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.router.navigate(['admin/users']).then(() => {})
      })
  }
}
