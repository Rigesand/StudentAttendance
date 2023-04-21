import {Component, OnInit} from '@angular/core'
import {Router} from '@angular/router'
import {FormControl, FormGroup} from '@angular/forms'
import {GroupService} from '../../services/group.service'

@Component({
  selector: 'mc-deleteGroup',
  templateUrl: 'deleteGroup.component.html',
  styleUrls: ['deleteGroup.component.scss'],
})
export class DeleteGroupComponent implements OnInit {
  constructor(private groupService: GroupService, private router: Router) {}

  ngOnInit(): void {}

  form = new FormGroup({
    groupNumber: new FormControl<string>(
      this.groupService.deleteGroup.groupNumber
    ),
  })

  Submit() {
    this.groupService
      .DeleteGroup(this.groupService.deleteGroup.groupNumber)
      .subscribe(() => {
        this.groupService.getAll()
        this.router.navigate(['admin/groups']).then(() => {})
      })
  }
}
