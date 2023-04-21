import {Injectable} from '@angular/core'
import {Observable, retry, tap} from 'rxjs'
import {HttpClient, HttpParams} from '@angular/common/http'
import {ILessonResponse} from '../types/LessonResponse'

@Injectable({
  providedIn: 'root',
})
export class LessonService {
  constructor(private http: HttpClient) {}

  lessons: ILessonResponse[] = []
  deleteLesson: ILessonResponse

  CreateLesson(name: string): Observable<boolean> {
    return this.http.post<boolean>(`/api/Lesson/Create?nameLesson=${name}`, {})
  }

  DeleteLesson() {
    return this.http.delete(`/api/Lesson/Delete?id=${this.deleteLesson.id}`)
  }

  getAll(): Observable<ILessonResponse[]> {
    return this.http
      .get<ILessonResponse[]>('/api/Lesson/GetAll', {
        params: new HttpParams({
          fromObject: {limit: 10},
        }),
      })
      .pipe(
        retry(2),
        tap((lessons) => (this.lessons = lessons))
      )
  }
}
