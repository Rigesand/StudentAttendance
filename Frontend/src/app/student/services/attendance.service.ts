import {Injectable} from '@angular/core'
import {HttpClient} from '@angular/common/http'
import {Observable} from 'rxjs'
import {Attendance} from '../types/Attendance'

@Injectable({
  providedIn: 'root',
})
export class AttendanceService {
  constructor(private http: HttpClient) {}

  Create(attendance: Attendance): Observable<boolean> {
    return this.http.post<boolean>('/api/Attendance/Add', attendance)
  }
}