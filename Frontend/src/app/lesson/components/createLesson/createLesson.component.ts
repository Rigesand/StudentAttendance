import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {LessonService} from '../../services/lesson.service'

@Component({
  selector: 'mc-createLesson',
  templateUrl: 'createLesson.component.html',
  styleUrls: ['createLesson.component.scss'],
})
export class CreateLessonComponent implements OnInit {
  constructor(private lessonService: LessonService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    name: new FormControl<string>(''),
  })

  Submit() {
    this.lessonService
      .CreateLesson(this.form.value.name as string)
      .subscribe(() => {
        this.form.controls.name.setValue('')
      })
  }
}
