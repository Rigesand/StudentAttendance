import {UUID} from 'angular2-uuid'

export interface AttendanceStudent {
  studentId: UUID
  lessonId: UUID
  groupNumber: string
}
