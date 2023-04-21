import {Component, OnInit} from '@angular/core'
import {Router} from '@angular/router'
import {FormControl, FormGroup} from '@angular/forms'
import {LessonService} from '../../services/lesson.service'

@Component({
  selector: 'mc-deleteLesson',
  templateUrl: 'deleteLesson.component.html',
  styleUrls: ['deleteLesson.component.scss'],
})
export class DeleteLessonComponent implements OnInit {
  constructor(private lessonService: LessonService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    name: new FormControl<string>(this.lessonService.deleteLesson.name),
  })

  Submit() {
    this.lessonService.DeleteLesson().subscribe(() => {
      this.router.navigate(['admin/lessons']).then(() => {})
    })
  }
}
