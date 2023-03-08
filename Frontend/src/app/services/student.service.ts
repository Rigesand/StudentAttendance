import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {ICreateStudent} from '../models/Students/CreateStudent'

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  constructor(private http: HttpClient) {}

  CreateStudent(createStudent: ICreateStudent): Observable<boolean> {
    return this.http.post<boolean>('/api/Student/CreateStudent', createStudent)
  }
}
