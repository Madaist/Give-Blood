import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @ViewChild('popUp', { static: false }) modal: ModalDirective;

  constructor() { }

  initialize(): void {
    this.modal.show();
  }
}
