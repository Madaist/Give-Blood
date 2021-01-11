import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';
import { BadgeDTO } from '../models/badge/badgeDTO';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public user: UserDTO = new UserDTO();
  public unassignedBadges: Array<BadgeDTO> = new Array<BadgeDTO>();
  public message: string;
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  constructor(private api: ApiService, private snackBar: MatSnackBar) {
  }

  openSnackBar(message: string, action: string) {
    this.snackBar.open(message, action, {
      duration: 10000,
      panelClass: ['red-snackbar'],
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  }

   ngOnInit() {
    this.api.getUser().subscribe((data: UserDTO) => {
      this.user = data;
      console.log(this.user);
    })

     this.api.getUnassignedBagdes().subscribe((data: Array<BadgeDTO>) => {
       this.unassignedBadges = data;
       console.log(this.unassignedBadges);
     })

     this.api.checkDonationNotification().subscribe((data: any) => {
       this.message = data.text;
       if (this.message != null) {
         this.openSnackBar(this.message, "Ok");
       }
     })

  }


}

