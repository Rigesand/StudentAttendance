import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {IStudentResponse} from '../../types/StudentResponse'
import {UserService} from '../../../admin/services/user.service'
import {concatMap} from 'rxjs'
import {IUserResponse} from '../../../admin/types/UserResponse'

@Component({
  selector: 'mc-students',
  templateUrl: 'students.component.html',
  styleUrls: ['students.component.scss'],
})
export class StudentsComponent implements OnInit {
  constructor(
    public studentService: StudentService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((res) => {
      this.userService.currentUser = res
      this.studentService.getAll().subscribe(() => {})
    })
  }

  ChangeStudent(student: IStudentResponse) {
    this.studentService.editStudent = student
  }

  DeleteStudent(student: IStudentResponse) {
    this.studentService.deleteStudent = student
  }
}
