import {UUID} from 'angular2-uuid'

export interface IStudentRequest {
  id: UUID | null
  name: string
  email: string
  groupNumber: string
}
