import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";

@Component({
  selector: 'app-deleteuser',
  templateUrl: './deleteuser.component.html',
  styleUrls: ['./deleteuser.component.scss']
})
export class DeleteuserComponent implements OnInit {
  constructor(public userService:UserService) { }
  term: string=""
  ngOnInit(): void {
    this.userService.getAll().subscribe(() => {
    });
  }}
