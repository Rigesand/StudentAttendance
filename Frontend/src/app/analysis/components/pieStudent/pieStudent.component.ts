import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {AttendanceService} from '../../../student/services/attendance.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {UserService} from '../../../admin/services/user.service'
import Chart from 'chart.js/auto'
import {StudentService} from '../../../student/services/student.service'

@Component({
  selector: 'mc-pieStudent',
  templateUrl: 'pieStudent.component.html',
  styleUrls: ['pieStudent.component.scss'],
})
export class PieStudentComponent implements OnInit {
  title = 'ng-chart'
  chart: any = []
  form = new FormGroup({
    lesson: new FormControl<string>(''),
    student: new FormControl<string>(''),
  })

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
    this.chart = new Chart('pieStudent', {
      type: 'pie',
      data: {
        labels: ['Посетил', 'Отсутствовал'],
        datasets: [
          {
            data: [],
            borderWidth: 1,
            backgroundColor: ['#04CC69', 'white'],
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    })
  }

  Submit() {
    this.chart.destroy()
    const groupNumber = this.userService.currentUser.groupNumber
    const lessonId = this.lessonService.lessons.find(
      (x) => x.name === this.form.controls.lesson.value
    )!.id
    const studentId = this.studentService.students.find(
      (x) => x.name === this.form.controls.student.value
    )!.id
    this.attendanceService
      .GetAttendanceByStudent({
        lessonId: lessonId,
        studentId: studentId,
        groupNumber: groupNumber,
      })
      .subscribe(
        (x) =>
          (this.chart = new Chart('pieStudent', {
            type: 'pie',
            data: {
              labels: ['Посетил', 'Отсутствовал'],
              datasets: [
                {
                  data: [x.visited, x.absence],
                  borderWidth: 1,
                  backgroundColor: ['#04CC69', 'white'],
                },
              ],
            },
            options: {
              scales: {
                y: {
                  beginAtZero: true,
                },
              },
            },
          }))
      )
    this.chart.update()
  }
}
