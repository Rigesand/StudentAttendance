import {Component, Input, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {UserService} from '../../../admin/services/user.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {FormControl, FormGroup} from '@angular/forms'
import {AttendanceService} from '../../services/attendance.service'
import {AttendingLesson} from '../../types/AttendingLesson'

@Component({
  selector: 'mc-attendance',
  templateUrl: 'attendances.component.html',
  styleUrls: ['attendances.component.scss'],
})
export class AttendancesComponent implements OnInit {
  constructor(
    public lessonService: LessonService,
    public studentService: StudentService,
    private userService: UserService,
    private attendanceService: AttendanceService
  ) {}

  @Input() options = Array<AttendingLesson>()

  form = new FormGroup({
    lesson: new FormControl<string>(''),
    date: new FormControl<Date>(new Date()),
  })
  ngOnInit(): void {
    this.userService.getCurrentUser().subscribe((res) => {
      this.userService.currentUser = res
      this.studentService.getAll().subscribe(() => {})
      this.lessonService.getAll().subscribe(() => {})
      for (let student of this.studentService.students) {
        this.options.push({
          studentId: student.id,
          status: false,
          name: student.name,
        })
      }
    })
  }
  onChange(e: any, student: AttendingLesson) {
    student.status = !student.status
  }

  Submit() {
    const id = this.lessonService.lessons.find(
      (x) => x.name === this.form.controls.lesson.value
    )!.id
    this.attendanceService
      .Create({
        data: this.form.controls.date.value as Date,
        lessonId: id,
        studentAttendances: this.options,
        groupNumber: this.userService.currentUser.groupNumber,
      })
      .subscribe()
  }
}
