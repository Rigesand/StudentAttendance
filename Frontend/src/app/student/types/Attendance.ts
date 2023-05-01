import {UUID} from 'angular2-uuid'
import {AttendingLesson} from './AttendingLesson'

export interface Attendance {
  data: Date
  lessonId: UUID
  studentAttendances: AttendingLesson[]
}
