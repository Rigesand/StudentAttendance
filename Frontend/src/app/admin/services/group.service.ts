import {HttpClient} from '@angular/common/http'
import {Injectable} from '@angular/core'
import {Observable} from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  constructor(private http: HttpClient) {}

  CreateGroup(groupNumber: string): Observable<boolean> {
    return this.http.post<boolean>(
      `/api/Group/CreateGroup?groupNumber=${groupNumber}`,
      {}
    )
  }
}
