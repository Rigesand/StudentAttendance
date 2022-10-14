import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";

@Component({
  selector: 'app-updateuser',
  templateUrl: './updateuser.component.html',
  styleUrls: ['./updateuser.component.scss']
})
export class UpdateuserComponent implements OnInit {

  constructor(public userService:UserService) { }

  term=""
  ngOnInit(): void {
    this.userService.getAll().subscribe(()=>
    {
    });
  }
}
