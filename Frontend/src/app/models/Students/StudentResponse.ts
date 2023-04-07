import {UUID} from 'angular2-uuid'

export interface IStudentResponse {
  id: UUID | null
  name: string
  email: string
  groupNumber: string
}
