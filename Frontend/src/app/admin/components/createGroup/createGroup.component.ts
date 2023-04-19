import {Component, OnInit} from '@angular/core'
import {GroupService} from '../../services/group.service'
import {FormControl, FormGroup} from '@angular/forms'

@Component({
  selector: 'app-create-group',
  templateUrl: 'createGroup.component.html',
  styleUrls: ['createGroup.component.scss'],
})
export class CreateGroupComponent implements OnInit {
  constructor(private groupService: GroupService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    groupNumber: new FormControl<string>(''),
  })

  Submit() {
    this.groupService
      .CreateGroup(this.form.value.groupNumber as string)
      .subscribe(() => {
        this.form.controls.groupNumber.setValue('')
      })
  }
}
