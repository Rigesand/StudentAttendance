import {Component, OnInit} from '@angular/core'
import Chart from 'chart.js/auto'
import {AttendanceService} from '../../../student/services/attendance.service'
import {LessonService} from '../../../lesson/services/lesson.service'
import {UserService} from '../../../admin/services/user.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'mc-pie',
  templateUrl: 'pie.component.html',
  styleUrls: ['pie.component.scss'],
})
export class PieComponent implements OnInit {
  title = 'ng-chart'
  chart: any = []
  form = new FormGroup({
    lesson: new FormControl<string>(''),
  })

  constructor(
    private attendanceService: AttendanceService,
    public lessonService: LessonService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.lessonService.getAll()
    this.userService.getCurrentUser()
    this.chart = new Chart('canvas', {
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

  Submit() {
    this.chart.destroy()
    const groupNumber = this.userService.currentUser.groupNumber
    const id = this.lessonService.lessons.find(
      (x) => x.name === this.form.controls.lesson.value
    )!.id
    this.attendanceService.GetAttendance(id, groupNumber).subscribe(
      (x) =>
        (this.chart = new Chart('canvas', {
          type: 'pie',
          data: {
            labels: ['Посетило', 'Отсутствовало'],
            datasets: [
              {
                data: [
                  (x.visited / (x.absence + x.visited)) * 100,
                  (x.absence / (x.absence + x.visited)) * 100,
                ],
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
