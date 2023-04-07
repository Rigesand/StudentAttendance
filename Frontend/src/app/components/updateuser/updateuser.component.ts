import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup} from '@angular/forms'
import {Router} from '@angular/router'

@Component({
  selector: 'app-updateuser',
  templateUrl: './updateuser.component.html',
  styleUrls: ['./updateuser.component.scss'],
})
export class UpdateuserComponent implements OnInit {
  constructor(public userService: UserService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.editUser.email),
    groupNumber: new FormControl<number>(this.userService.editUser.groupNumber),
  })

  UpdateUser() {
    this.userService
      .UpdateUser({
        id: this.userService.editUser.id,
        email: this.form.value.email as string,
        groupNumber: this.form.value.groupNumber as number,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.router.navigate(['admin/users']).then(() => {})
      })
  }
}
