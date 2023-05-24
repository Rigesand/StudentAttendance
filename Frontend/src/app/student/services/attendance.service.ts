import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {Attendance} from '../types/Attendance'
import {LessonAttendanceInfo} from '../../analysis/types/lessonAttendanceInfo'
import {UUID} from 'angular2-uuid'

@Injectable({
  providedIn: 'root',
})
export class AttendanceService {
  constructor(private http: HttpClient) {}

  Create(attendance: Attendance): Observable<boolean> {
    return this.http.post<boolean>('/api/Attendance/Add', attendance)
  }

  GetAttendance(
    lessonId: UUID,
    groupNumber: string
  ): Observable<LessonAttendanceInfo> {
    return this.http.post<LessonAttendanceInfo>(
      `/api/Attendance/GetAttendance?lessonId=${lessonId}&groupNumber=${groupNumber}`,
      {}
    )
  }
}
