import {UUID} from 'angular2-uuid'

export interface FilterTimeSpan {
  lessonId: UUID
  groupNumber: string
  beginDate: Date
  endDate: Date
}
