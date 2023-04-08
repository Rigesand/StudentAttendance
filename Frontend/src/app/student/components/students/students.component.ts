import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {IStudentResponse} from '../../types/StudentResponse'

@Component({
  selector: 'mc-students',
  templateUrl: 'students.component.html',
  styleUrls: ['students.component.scss'],
})
export class StudentsComponent implements OnInit {
  constructor(public studentService: StudentService) {}

  ngOnInit(): void {
    this.studentService.getAll().subscribe(() => {})
  }

  ChangeStudent(student: IStudentResponse) {
    this.studentService.editStudent = student
  }

  DeleteStudent(student: IStudentResponse) {
    this.studentService.deleteStudent = student
  }
}
