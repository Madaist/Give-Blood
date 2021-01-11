import { Component, OnInit } from '@angular/core';
import * as $ from "jquery";

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: 'dashboard', title: 'Acasă', icon: 'dashboard', class: '' },
  { path: 'user-profile', title: 'Profilul meu', icon: 'person', class: '' },
  { path: 'my-donations', title: 'Donările mele', icon: 'medical_services', class: '' },
  { path: 'leaderboard', title: 'Clasament', icon: 'leaderboard', class: '' },
  { path: 'scan-donation', title: 'Scanează o donare', icon: 'qr_code_scanner', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  };
}
