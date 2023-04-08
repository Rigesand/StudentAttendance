import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'

@Component({
  selector: 'mc-attendance',
  templateUrl: 'attendances.component.html',
  styleUrls: ['attendances.component.scss'],
})
export class AttendancesComponent implements OnInit {
  constructor(public studentService: StudentService) {}
  ngOnInit(): void {
    this.studentService.getAll().subscribe(() => {})
  }
}
