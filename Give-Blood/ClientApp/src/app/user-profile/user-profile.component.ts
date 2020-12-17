import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  @ViewChild('updateUserModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  public user: UserDTO = new UserDTO()
  updateUserForm: FormGroup;

  constructor(public fb: FormBuilder ,private api: ApiService) { }

  ngOnInit() {
    this.api['getUser']().subscribe((data: UserDTO) => {
      this.user = data;
      console.log(this.user);
    })
  }

  initialize(id: number): void {
    this.modal.show();
    this.initializeForm(this.user);
  }

  initializeForm(user: UserDTO) {
    this.updateUserForm = this.fb.group({

      email: [user.Email, Validators.required],
      address: [user.Address, Validators.required],
      FirstName: [user.FirstName, Validators.required],
      LastName: [user.LastName, Validators.required],
      Weight: [user.Weight, Validators.required],
      BloodType: [user.BloodType, Validators.required],

    });
  }

  updateUser() {
    this.api['updateUser'](this.user).subscribe((data: any) => console.log(data))
  }

}
