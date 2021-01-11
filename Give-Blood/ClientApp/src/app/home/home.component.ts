import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit{
  @Output() public sidenavToggle = new EventEmitter();

  //registerUserForm: FormGroup;
  //loginUserForm: FormGroup;
  success: boolean;

  public users: Array<UserDTO> = new Array<UserDTO>();

  constructor(public formBuilder: FormBuilder, private api: ApiService) {
  }

  ngOnInit(): void {
    this.api['getTopThree']().subscribe((data: Array<UserDTO>) => {
      this.users = data;
      console.log(this.users);
    })

  }


  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

}
