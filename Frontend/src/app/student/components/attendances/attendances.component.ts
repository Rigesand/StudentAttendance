import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {UserService} from '../../../admin/services/user.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'mc-attendance',
  templateUrl: 'attendances.component.html',
  styleUrls: ['attendances.component.scss'],
})
export class AttendancesComponent implements OnInit {
  constructor(
    public lessonService: LessonService,
    public studentService: StudentService,
    private userService: UserService
  ) {}

  form = new FormGroup({
    lesson: new FormControl<string>(''),
  })
  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((res) => {
      this.userService.currentUser = res
      this.studentService.getAll().subscribe(() => {})
      this.lessonService.getAll().subscribe(() => {})
    })
  }
}
