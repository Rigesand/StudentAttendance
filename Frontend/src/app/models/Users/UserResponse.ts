import {UUID} from 'angular2-uuid'

export interface IUserResponse {
  id: UUID
  name?: string
  email: string
  role: string
  groupNumber?: number
}
