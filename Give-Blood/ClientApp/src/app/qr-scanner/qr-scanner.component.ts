import { Component, OnInit, ChangeDetectorRef, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { ApiService } from '../../api.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ModalComponent } from './modal/modal.component';

@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.css']
})
export class QrScannerComponent implements OnInit {

  private scannerEnabled: boolean = true;
  private information: string = "Niciun cod QR detectat. Apropie un cod pentru a-l scana.";
  private qrCode: string;
  @ViewChild('popUp', { static: false }) modal: ModalComponent;

  constructor(private cd: ChangeDetectorRef, private api: ApiService) {
  }

  ngOnInit() {
  }

  public scanSuccessHandler($event: any) {
    this.scannerEnabled = false;
    this.information = "Se extrage informația.. ";

    console.log(String($event));
    if (this.validateQrCode(String($event))) {

      this.qrCode = String($event);
      this.api.postDonation(this.qrCode).subscribe((data: any) => {
        this.modal.initialize();
        //Swal.fire(
        //  'Codul donării a fost înregistrat cu succes.',
        //  'Ești un erou!',
        //  'success'
        //)
      },
        (error: HttpErrorResponse) => {
          Swal.fire({
            icon: 'error',
            title: 'Cod QR invalid',
            text: error.error,
            confirmButtonColor: 'red',
            width: '30vw',
          });

        });
    }
    else {
      Swal.fire({
        icon: 'error',
        title: 'Cod QR invalid',
        text: 'Codul pe care ai încercat să îl scanezi nu este un cod de donare valid',
        confirmButtonColor: 'red',
        width: '30vw',
      })
    }
    this.cd.markForCheck();
  }

  public enableScanner() {
    this.scannerEnabled = !this.scannerEnabled;
    this.information = "Niciun cod QR detectat. Apropie un cod pentru a-l scana.";
  }

  public validateQrCode(qrCode: string) {
    let isNum = /^\d+$/.test(qrCode);
    return (qrCode.length === 8 && isNum === true && ['1', '2', '3'].includes(qrCode.charAt(0)));
  }
}
