import {Component, OnInit} from '@angular/core'
import Chart from 'chart.js/auto'
import {AttendanceService} from '../../../student/services/attendance.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {UserService} from '../../../admin/services/user.service'
import {FormControl, FormGroup} from '@angular/forms'
import {LessonInfoWithDate} from '../../types/lessonInfoWithDate'

@Component({
  selector: 'mc-bar',
  templateUrl: 'bar.component.html',
  styleUrls: ['bar.component.scss'],
})
export class BarComponent implements OnInit {
  title = 'ng-chart'
  chart: any = []
  form = new FormGroup({
    lesson: new FormControl<string>(''),
    BeginDate: new FormControl<Date>(new Date()),
    EndDate: new FormControl<Date>(new Date()),
  })

  data: []

  constructor(
    private attendanceService: AttendanceService,
    public lessonService: LessonService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.lessonService.getAll()
    this.userService.getCurrentUser()
    this.chart = new Chart('bar', {
      type: 'pie',
      data: {
        labels: ['Посетило', 'Отсутствовало'],
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

  lol(attendance: LessonInfoWithDate) {
    return [attendance.date, attendance.visited]
  }

  Submit() {
    this.chart.destroy()
    const groupNumber = this.userService.currentUser.groupNumber
    const id = this.lessonService.lessons.find(
      (x) => x.name === this.form.controls.lesson.value
    )!.id
    this.attendanceService
      .GetLessonsInfo({
        groupNumber: groupNumber,
        lessonId: id,
        beginDate: this.form.controls.BeginDate.value!,
        endDate: this.form.controls.EndDate.value!,
      })
      .subscribe(
        (x) =>
          (this.chart = new Chart('bar', {
            type: 'bar',
            data: {
              labels: ['Посетило', 'Отсутствовало'],
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
          }))
      )
    this.chart.update()
  }
}
