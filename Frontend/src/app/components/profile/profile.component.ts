import {Component, OnInit} from '@angular/core'
import {UserService} from '../../services/user.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>(this.userService.currentUser.email),
    name: new FormControl<string | null>(this.userService.currentUser.name),
    password: new FormControl<string>(''),
  })

  UpdateProfile() {
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
