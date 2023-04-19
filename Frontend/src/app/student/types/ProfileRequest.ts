import {UUID} from 'angular2-uuid'

export interface IProfileRequest {
  id: UUID
  name: string
  email: string
  password: string
}
