import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {Router} from '@angular/router'
import {FormControl, FormGroup} from '@angular/forms'
@Component({
  selector: 'mc-updateStudent',
  templateUrl: 'updateStudent.component.html',
  styleUrls: ['updateStudent.component.scss'],
})
export class UpdateStudentComponent implements OnInit {
  constructor(public studentService: StudentService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    name: new FormControl<string>(this.studentService.editStudent.name),
    email: new FormControl<string>(this.studentService.editStudent.email),
  })

  Submit() {
    this.studentService.editStudent.name = this.form.value.name as string
    this.studentService.editStudent.email = this.form.value.email as string
    this.studentService
      .UpdateStudent(this.studentService.editStudent)
      .subscribe(() => {
        this.studentService.getAll()
        this.router.navigate(['attendance/students']).then(() => {})
      })
  }
}
