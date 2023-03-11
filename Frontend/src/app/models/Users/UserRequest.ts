import {UUID} from 'angular2-uuid'

export interface IUserRequest {
  id?: UUID
  email: string
  role: string
  groupNumber?: number | null
}
