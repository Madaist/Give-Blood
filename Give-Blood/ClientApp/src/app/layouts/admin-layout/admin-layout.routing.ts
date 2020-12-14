import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { UserProfileComponent } from '../../user-profile/user-profile.component';
import { MyDonationsComponent } from '../../my-donations/my-donations.component';
import { LeaderboardComponent } from '../../leaderboard/leaderboard.component';
import { AdminLayoutComponent } from './admin-layout.component';
import { AuthorizeGuard } from '../../../api-authorization/authorize.guard';
import { QrScannerComponent } from '../../qr-scanner/qr-scanner.component';

export const AdminLayoutRoutes: Routes = [
  {
    path: 'home', component: AdminLayoutComponent, canActivate: [AuthorizeGuard], children: [
        {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
        { path: 'dashboard', component: DashboardComponent },
        { path: 'user-profile', component: UserProfileComponent },
        { path: 'my-donations', component: MyDonationsComponent },
        { path: 'leaderboard', component: LeaderboardComponent },
      { path: 'scan-donation', component: QrScannerComponent },
    ]}
];
