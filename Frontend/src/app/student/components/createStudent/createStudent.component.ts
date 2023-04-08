import {Component} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {UserService} from '../../../admin/services/user.service'
import {FormControl, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'mc-createStudent',
  templateUrl: 'createStudent.component.html',
  styleUrls: ['createStudent.component.scss'],
})
export class CreateStudentComponent {
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

  Submit() {
    const name = ((((this.form.value.lastName as string) +
      ' ' +
      this.form.value.firstName) as string) +
      ' ' +
      this.form.value.secondName) as string
    this.studentService
      .CreateStudent({
        id: null,
        email: this.form.value.email as string,
        name: name,
        groupNumber: this.userService.currentUser.groupNumber,
      })
      .subscribe(() => {
        this.studentService.getAll()
        this.form.controls.email.setValue('')
        this.form.controls.firstName.setValue('')
        this.form.controls.secondName.setValue('')
        this.form.controls.lastName.setValue('')
      })
  }
}
