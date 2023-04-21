import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'
import {HttpClient} from '@angular/common/http'

@Injectable({
  providedIn: 'root',
})
export class LessonService {
  constructor(private http: HttpClient) {}

  CreateLesson(name: string): Observable<boolean> {
    return this.http.post<boolean>(`/api/Lesson/Create?nameLesson=${name}`, {})
  }
}
