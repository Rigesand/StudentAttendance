import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {StudentService} from '../../services/student.service'
import {Router} from '@angular/router'

@Component({
  selector: 'app-delete-student',
  templateUrl: './delete-student.component.html',
  styleUrls: ['./delete-student.component.scss'],
})
export class DeleteStudentComponent implements OnInit {
  constructor(public studentService: StudentService, private router: Router) {}

  ngOnInit(): void {}

  DeleteUser() {
    this.studentService
      .DeleteStudent(this.studentService.deleteStudent)
      .subscribe(() => {
        this.studentService.getAll()
        this.router.navigate(['attendance/students']).then(() => {})
      })
  }
}
