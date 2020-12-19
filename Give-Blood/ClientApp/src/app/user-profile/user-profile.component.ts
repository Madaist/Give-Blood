import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  public user: UserDTO = new UserDTO();
  updateUserForm: FormGroup;

  constructor(public fb: FormBuilder, private api: ApiService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.api['getUser']().subscribe((data: UserDTO) => {
      this.user = data;
      this.initializeForm(this.user);
      console.log(this.user);
    })
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 50000,
      panelClass: ['red-snackbar', 'mat-danger']
    });
  }


  initializeForm(user: UserDTO) {
    this.updateUserForm = this.fb.group({
      email: [user.email, Validators.required],
      address: [user.address, Validators.required],
      firstName: [user.firstName, Validators.required],
      lastName: [user.lastName, Validators.required],
      weight: [user.weight, Validators.required],
      bloodType: [user.bloodType, Validators.required],
      age: [user.age, Validators.required]
    });
  }

  updateUser() {

    const editedUser = new UserDTO(
      this.user.id,
      this.user.email,
      this.updateUserForm.value.lastName,
      this.updateUserForm.value.firstName,
      this.updateUserForm.value.address,
      this.updateUserForm.value.bloodType,
      this.updateUserForm.value.weight,
      this.updateUserForm.value.age
    );

    this.api.updateUser(editedUser)
      .subscribe(() => {
        this.change.emit('user');
        this.openSnackBar("Changes were saved", "Ok");
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

}
