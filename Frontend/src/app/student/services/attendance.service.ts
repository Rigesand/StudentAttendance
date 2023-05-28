import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {Attendance} from '../types/Attendance'
import {LessonAttendanceInfo} from '../../analysis/types/lessonAttendanceInfo'
import {UUID} from 'angular2-uuid'
import {AttendanceStudent} from '../../analysis/types/attendanceStudent'
import {FilterTimeSpan} from '../../analysis/types/FilterTimeSpan'
import {LessonInfoWithDate} from '../../analysis/types/lessonInfoWithDate'

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

  GetAttendanceByStudent(
    attendanceStudent: AttendanceStudent
  ): Observable<LessonAttendanceInfo> {
    return this.http.post<LessonAttendanceInfo>(
      `/api/Attendance/GetAttendanceByStudent`,
      attendanceStudent
    )
  }

  GetLessonsInfo(filter: FilterTimeSpan): Observable<LessonInfoWithDate[]> {
    return this.http.post<LessonInfoWithDate[]>(
      `/api/Attendance/GetLessonsInfo`,
      filter
    )
  }
}
