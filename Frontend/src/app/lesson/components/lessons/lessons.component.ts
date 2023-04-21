import {Component, OnInit} from '@angular/core'
import {GroupService} from '../../../admin/services/group.service'
import {IGroupResponse} from '../../../admin/types/GroupResponse'
import {LessonService} from '../../services/lesson.service'
import {ILessonResponse} from '../../types/LessonResponse'

@Component({
  selector: 'mc-lessons',
  templateUrl: 'lessons.component.html',
  styleUrls: ['lessons.component.scss'],
})
export class LessonsComponent implements OnInit {
  constructor(public lessonService: LessonService) {}

  ngOnInit(): void {
    this.lessonService.getAll().subscribe(() => {})
  }

  DeleteLesson(lesson: ILessonResponse) {
    this.lessonService.deleteLesson = lesson
  }
}
