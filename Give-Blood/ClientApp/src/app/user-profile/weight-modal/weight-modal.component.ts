import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApiService } from '../../../api.service';
import Swal from 'sweetalert2';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-weight-modal',
  templateUrl: './weight-modal.component.html',
  styleUrls: ['./weight-modal.component.css']
})
export class WeightModalComponent {

  @ViewChild('weightModal', { static: false }) modal: ModalDirective;
  updateWeightForm: FormGroup;
  weight: number;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();

  constructor(public fb: FormBuilder, private apiService: ApiService) { }

  initialize(): void {
    this.modal.show();
    this.initializeForm();
  }

  initializeForm() {
    this.updateWeightForm = this.fb.group({
      weight: [null, Validators.required],
    });
  }

  updateWeight() {
    this.weight = this.updateWeightForm.value.weight;
    console.log("Weight is");
    console.log(this.weight);
    this.apiService.patchUser(this.weight).subscribe(() => {
      Swal.fire({
        title: 'Your profile was successfully updated.',
        icon: 'success',
        width: '25vw',
        confirmButtonColor: '#f44336',
      });
      this.change.emit('weightUpdated');
      this.modal.hide();
    },
      (error: HttpErrorResponse) => {
        Swal.fire({
          icon: 'error',
          title: 'Something went wrong',
          text: error.error,
          confirmButtonColor: '#f44336',
          width: '30vw',
        });
      });
  }

}
