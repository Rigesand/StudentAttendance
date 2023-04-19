import {HttpClient, HttpParams} from '@angular/common/http'
import {Injectable} from '@angular/core'
import {Observable, retry, tap} from 'rxjs'
import {IGroupResponse} from '../types/GroupResponse'

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  constructor(private http: HttpClient) {}

  groups: IGroupResponse[] = []
  deleteGroup: IGroupResponse

  CreateGroup(groupNumber: string): Observable<boolean> {
    return this.http.post<boolean>(
      `/api/Group/CreateGroup?groupNumber=${groupNumber}`,
      {}
    )
  }

  getAll(): Observable<IGroupResponse[]> {
    return this.http
      .get<IGroupResponse[]>('/api/Group/GetAllGroups', {
        params: new HttpParams({
          fromObject: {limit: 10},
        }),
      })
      .pipe(
        retry(2),
        tap((groups) => (this.groups = groups))
      )
  }
}
