import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminLayoutRoutes } from './admin-layout.routing';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { MyDonationsComponent } from '../../my-donations/my-donations.component';
import { LeaderboardComponent } from '../../leaderboard/leaderboard.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { QrScannerComponent } from '../../qr-scanner/qr-scanner.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { WeightModalComponent } from '../../user-profile/weight-modal/weight-modal.component';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    ZXingScannerModule,
    MatSnackBarModule,
    ModalModule.forRoot()
  ],
  declarations: [
    DashboardComponent,
    UserProfileComponent,
    MyDonationsComponent,
    LeaderboardComponent,
    QrScannerComponent,
    WeightModalComponent
  ]
})

export class AdminLayoutModule { }
