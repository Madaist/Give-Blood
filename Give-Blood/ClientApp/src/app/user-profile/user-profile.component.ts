import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';
import { MatSnackBar } from '@angular/material/snack-bar';
import { formatDate } from '@angular/common';
import { WeightModalComponent } from './weight-modal/weight-modal.component';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  @ViewChild('weightModal', { static: false }) weightModal: WeightModalComponent;
  public user: UserDTO = new UserDTO();
  public donorStatus: string;
  public birthDate: string;
  updateUserForm: FormGroup;
  public needsWeightUpdate: boolean;

  constructor(public fb: FormBuilder, private api: ApiService, private snackBar: MatSnackBar) { }

  ngOnInit() {

    this.getUser();

    this.api.checkWeightUpdateNeed().subscribe((response: boolean) => {
      this.needsWeightUpdate = response;
      if (this.needsWeightUpdate === true) {
        this.weightModal.initialize();
      }
    });
  }

  getUser() {
    this.api['getUser']().subscribe((data: UserDTO) => {
      this.user = data;
      this.birthDate = formatDate(new Date(this.user.birthDate), 'yyyy-MM-dd', 'en_US');

      if (this.user.age >= 18 && this.user.age <= 65 && this.user.weight >= 50) {
        this.donorStatus = 'Eligibil pentru donare';
      }
      else {
        this.donorStatus = 'Neeligibil pentru donare';
      }
      this.initializeForm(this.user);
      console.log(this.user);
    });
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 1000,
      panelClass: ['red-snackbar']
    });
  }

  onEditFinished(event: string) {
    this.getUser();
  }


  initializeForm(user: UserDTO) {
    this.updateUserForm = this.fb.group({
      status: [this.donorStatus],
      email: [user.email, Validators.required],
      address: [user.address, Validators.required],
      firstName: [user.firstName, Validators.required],
      lastName: [user.lastName, Validators.required],
      weight: [user.weight, Validators.required],
      bloodType: [user.bloodType, Validators.required],
      birthDate: [user.birthDate, Validators.required],
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
      this.updateUserForm.value.birthDate
    );

    var diff = Math.abs(Date.now().valueOf() - new Date(editedUser.birthDate).getTime());
    var day = 1000 * 60 * 60 * 24;
    var days = Math.floor(diff / day);
    var months = Math.floor(days / 31);
    var years = Math.floor(months / 12);

    this.api.updateUser(editedUser)
      .subscribe(() => {
        this.openSnackBar("Modificările au fost salvate", "Ok");

        editedUser.age = years;
        this.user.age = years;
        if (editedUser.age >= 18 && editedUser.age <= 65 && editedUser.weight >= 50) {
          this.donorStatus = 'Eligibil pentru donare';
        }
        else {
          this.donorStatus = 'Neeligibil pentru donare';
        }
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

}
