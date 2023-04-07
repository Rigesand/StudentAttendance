import {UUID} from 'angular2-uuid'

export interface IUserRequest {
  id: UUID | null
  email: string
  groupNumber: number
}
