import {UUID} from 'angular2-uuid'

export interface IUserResponse {
  id: UUID
  name: string | null
  email: string
  role: string
  groupNumber: string
}
