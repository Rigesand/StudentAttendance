import {Component, OnInit} from '@angular/core'
import {StudentService} from '../../services/student.service'
import {UserService} from '../../../admin/services/user.service'

@Component({
  selector: 'mc-attendance',
  templateUrl: 'attendances.component.html',
  styleUrls: ['attendances.component.scss'],
})
export class AttendancesComponent implements OnInit {
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
}
