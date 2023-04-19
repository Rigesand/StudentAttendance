import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup, Validators} from '@angular/forms'
import {IUserResponse} from '../../types/UserResponse'

@Component({
  selector: 'mc-users',
  templateUrl: 'users.component.html',
  styleUrls: ['users.component.scss'],
})
export class UsersComponent implements OnInit {
  constructor(public userService: UserService) {}

  term: string = ''

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((res) => {
      this.userService.currentUser = res
      this.userService.getAll().subscribe(() => {})
    })
  }

  form = new FormGroup({
    email: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6),
    ]),
    role: new FormControl<string>(''),
  })

  ChangeUser(user: IUserResponse) {
    this.userService.editUser = user
  }

  DeleteUser(user: IUserResponse) {
    this.userService.deleteUser = user
  }
}
