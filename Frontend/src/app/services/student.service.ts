import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable, retry, tap} from 'rxjs'
import {IStudentRequest} from '../models/Students/StudentRequest'
import {IStudentResponse} from '../models/Students/StudentResponse'
import {UserService} from './user.service'

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  constructor(private http: HttpClient, private userService: UserService) {}

  students: IStudentResponse[]
  editStudent: IStudentResponse
  deleteStudent: IStudentResponse

  CreateStudent(createStudent: IStudentRequest): Observable<boolean> {
    return this.http.post<boolean>('/api/Student/CreateStudent', createStudent)
  }
  UpdateStudent(updateStudent: IStudentRequest) {
    updateStudent.groupNumber = this.userService.currentUser
      .groupNumber as string
    return this.http.put('/api/Student/UpdateStudent', updateStudent)
  }

  DeleteStudent(deleteStudent: IStudentRequest) {
    return this.http.post('/api/Student/DeleteStudent', deleteStudent)
  }

  getAll(): Observable<IStudentResponse[]> {
    const groupNumber = this.userService.currentUser.groupNumber
    return this.http
      .get<IStudentResponse[]>(
        `api/Student/GetStudentsByGroup?groupNumber=${groupNumber}`
      )
      .pipe(
        retry(2),
        tap((students) => (this.students = students))
      )
  }
}
