import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import Swal from 'sweetalert2';
import { ApiService } from '../../api.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.css']
})
export class QrScannerComponent implements OnInit {

  private scannerEnabled: boolean = true;
  private information: string = "No QR code detected. Zoom in a code in order to scan it.";
  private qrCode: string;

  constructor(private cd: ChangeDetectorRef, private api: ApiService) {
  }

  ngOnInit() {
  }

  public scanSuccessHandler($event: any) {
    this.scannerEnabled = false;
    this.information = "Extracting the information... ";

    console.log(String($event));
    if (this.validateQrCode(String($event))) {

      this.qrCode = String($event);
      this.api.postDonation(this.qrCode).subscribe((data: any) => {
        Swal.fire(
          'The donation code was successfully sent.',
          'You\'re a hero!',
          'success'
        )
      },
        (error: HttpErrorResponse) => {
          Swal.fire({
            icon: 'error',
            title: 'Invalid QR Code',
            text: error.error,
            confirmButtonColor: 'red',
            width: '30vw',
          });

        });
    }
    else {
      Swal.fire({
        icon: 'error',
        title: 'Invalid QR Code',
        text: 'The code you are trying to scan is not a valid donation code',
        confirmButtonColor: 'red',
        width: '30vw',
      })
    }
    this.cd.markForCheck();
  }

  public enableScanner() {
    this.scannerEnabled = !this.scannerEnabled;
    this.information = "No QR code detected. Zoom in a code in order to scan it.";
  }

  public validateQrCode(qrCode: string) {
    let isNum = /^\d+$/.test(qrCode);
    return (qrCode.length === 8 && isNum === true && ['1', '2', '3'].includes(qrCode.charAt(0)));
  }
}
