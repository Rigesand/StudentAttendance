import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {Router} from '@angular/router'

@Component({
  selector: 'mc-deleteStudent',
  templateUrl: 'deleteStudent.component.html',
  styleUrls: ['deleteStudent.component.scss'],
})
export class DeleteStudentComponent implements OnInit {
  constructor(public studentService: StudentService, private router: Router) {}

  ngOnInit(): void {}

  Submit() {
    this.studentService
      .DeleteStudent(this.studentService.deleteStudent)
      .subscribe(() => {
        this.studentService.getAll()
        this.router.navigate(['attendance/students']).then(() => {})
      })
  }
}
