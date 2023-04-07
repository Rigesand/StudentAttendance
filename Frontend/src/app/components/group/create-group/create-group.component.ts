import {Component, OnInit} from '@angular/core'
import {FormControl, FormGroup} from '@angular/forms'
import {GroupService} from '../../../services/group.service'

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.scss'],
})
export class CreateGroupComponent implements OnInit {
  constructor(private groupService: GroupService) {}

  ngOnInit(): void {}

  form = new FormGroup({
    groupNumber: new FormControl<string>(''),
  })

  CreateGroup() {
    this.groupService
      .CreateGroup(this.form.value.groupNumber as string)
      .subscribe(() => {
        this.form.controls.groupNumber.setValue('')
      })
  }
}
