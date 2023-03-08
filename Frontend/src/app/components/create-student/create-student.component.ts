import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup, Validators} from '@angular/forms'
import {StudentService} from '../../services/student.service'
import {UserService} from '../../services/user.service'

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.scss'],
})
export class CreateStudentComponent implements OnInit {
  constructor(
    private studentService: StudentService,
    private userService: UserService
  ) {}

  ngOnInit(): void {}

  form = new FormGroup({
    email: new FormControl<string>('', [
      Validators.required,
      Validators.minLength(6),
    ]),
    firstName: new FormControl<string>('', [Validators.required]),
    secondName: new FormControl<string>('', [Validators.required]),
    lastName: new FormControl<string>('', [Validators.required]),
  })

  CreateStudent() {
    const name = ((((this.form.value.lastName as string) +
      ' ' +
      this.form.value.firstName) as string) +
      ' ' +
      this.form.value.secondName) as string
    this.studentService
      .CreateStudent({
        email: this.form.value.email as string,
        name: name,
        groupNumber: this.userService.currentUser.groupNumber!,
      })
      .subscribe(() => {
        this.form.controls.email.setValue('')
        this.form.controls.firstName.setValue('')
        this.form.controls.secondName.setValue('')
        this.form.controls.lastName.setValue('')
      })
  }
}
