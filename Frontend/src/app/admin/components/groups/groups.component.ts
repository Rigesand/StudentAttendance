import {Component, OnInit} from '@angular/core'
import {GroupService} from '../../services/group.service'
import {IGroupResponse} from '../../types/GroupResponse'

@Component({
  selector: 'mc-groups',
  templateUrl: 'groups.component.html',
  styleUrls: ['groups.component.scss'],
})
export class GroupsComponent implements OnInit {
  constructor(public groupService: GroupService) {}
  ngOnInit(): void {
    this.groupService.getAll().subscribe(() => {})
  }

  DeleteGroup(group: IGroupResponse) {
    this.groupService.deleteGroup = group
  }
}
