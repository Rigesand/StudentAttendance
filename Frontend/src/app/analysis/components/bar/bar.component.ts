import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {AttendanceService} from '../../../student/services/attendance.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {UserService} from '../../../admin/services/user.service'
import {StudentService} from '../../../student/services/student.service'

@Component({
  selector: 'mc-bar',
  templateUrl: 'bar.component.html',
  styleUrls: ['bar.component.scss'],
})
export class BarComponent implements OnInit {
  form = new FormGroup({
    lesson: new FormControl<string>(''),
    student: new FormControl<string>(''),
  })

  dates: Date[]
  name: string | null

  constructor(
    private attendanceService: AttendanceService,
    public lessonService: LessonService,
    public studentService: StudentService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.studentService.getAll()
    this.lessonService.getAll()
    this.userService.getCurrentUser()
  }

  Submit() {
    this.dates = []
    this.name = this.form.controls.student.value
    const groupNumber = this.userService.currentUser.groupNumber
    const lessonId = this.lessonService.lessons.find(
      (x) => x.name === this.form.controls.lesson.value
    )!.id
    const studentId = this.studentService.students.find(
      (x) => x.name === this.form.controls.student.value
    )!.id
    this.attendanceService
      .GetAbsenceList(lessonId, studentId, groupNumber)
      .subscribe((dates) => (this.dates = dates))
  }
}
