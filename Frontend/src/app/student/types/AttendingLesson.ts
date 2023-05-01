import {UUID} from 'angular2-uuid'

export interface AttendingLesson {
  studentId: UUID | null
  name: string
  status: boolean
}
