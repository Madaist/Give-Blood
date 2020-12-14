import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../../api.service';
import Swal from 'sweetalert2';
import { UserDTO } from '../models/user/userDTO';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit{
  @Output() public sidenavToggle = new EventEmitter();

  registerUserForm: FormGroup;
  loginUserForm: FormGroup;
  success: boolean;

  public users: Array<UserDTO> = new Array<UserDTO>();

  

  constructor(public formBuilder: FormBuilder, private api: ApiService) {
  }

  ngOnInit(): void {

    this.registerUserForm = this.formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      email: [null, Validators.compose([Validators.required, Validators.email])],
      phoneNumber: [null, Validators.required],
      password: [null, Validators.required]
    })

    this.loginUserForm = this.formBuilder.group({
      email: [null, Validators.compose([Validators.required, Validators.email])],
      password: [null, Validators.required]
    })

    this.api['getUsers']().subscribe((data: Array<UserDTO>) => {
      this.users = data;
      console.log(this.users);
    })

    console.log(this.users);
  }

  scroll(id) {
    let el = document.getElementById(id);
    el.scrollIntoView();
  }


  //register() {
  //  this.api['register'](this.registerUserForm.value).subscribe(() => {
  //    this.success = true;
  //    setTimeout(() => {
  //      this.success = null;
  //    }, 3000);
  //  },
  //    (error: Error) => {
  //      console.log(error);
  //      this.success = false;
  //      setTimeout(() => {
  //        this.success = null;
  //      }, 3000);
  //    });

  //  Swal.fire({
  //    icon: 'success',
  //    title: 'You signed up successfully',
  //    text: 'We sent you a confirmation mail. Please check it out in order to active your account.',
  //    width: '25vw',
  //    confirmButtonColor: '#dc3545',
  //  })
  //}


  //login() {
  //  this.api['login'](this.loginUserForm.value).subscribe(() => {
  //    this.success = true;
  //    setTimeout(() => {
  //      this.success = null;
  //    }, 3000);
  //  },
  //    (error: Error) => {
  //      console.log(error);
  //      this.success = false;
  //      setTimeout(() => {
  //        this.success = null;
  //      }, 3000);
  //    });
  //}


  //showDonorRequirementsModal() {
  //  this.donorRequirementsModal.initialize();
  //}

  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }

}
