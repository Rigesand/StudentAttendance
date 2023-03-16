import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup, Validators} from '@angular/forms'
import {Router} from '@angular/router'

@Component({
  selector: 'app-updateuser',
  templateUrl: './updateuser.component.html',
  styleUrls: ['./updateuser.component.scss'],
})
export class UpdateuserComponent implements OnInit {
  constructor(public userService: UserService, private router: Router) {}

  ngOnInit(): void {}

  roles = ['Студент', 'Администратор']

  form = new FormGroup({
    email: new FormControl<string>(this.userService.editUser.email),
    role: new FormControl<string | undefined>(this.userService.editUser.role),
  })

  UpdateUser() {
    this.userService
      .UpdateUser({
        id: this.userService.editUser.id,
        email: this.form.value.email as string,
        role: this.form.value.role as string,
        groupNumber: this.userService.currentUser.groupNumber,
      })
      .subscribe(() => {
        this.userService.getAll()
        this.router.navigate(['admin/users']).then(() => {})
      })
  }
}
