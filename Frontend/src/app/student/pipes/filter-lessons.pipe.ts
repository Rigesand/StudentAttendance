import {Pipe, PipeTransform} from '@angular/core'
import {ILessonResponse} from '../../lesson/types/LessonResponse'

@Pipe({
  name: 'filterLessons',
})
export class FilterLessonsPipe implements PipeTransform {
  transform(lessons: ILessonResponse[], search: string): ILessonResponse[] {
    if (search.length === 0) return lessons
    return lessons.filter((p) =>
      p.name.toLowerCase().includes(search.toLowerCase())
    )
  }
}
