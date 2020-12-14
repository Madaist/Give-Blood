import { Component, OnInit } from '@angular/core';
import * as $ from "jquery";

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: 'dashboard', title: 'Home', icon: 'dashboard', class: '' },
  { path: 'user-profile', title: 'My Profile', icon: 'person', class: '' },
  { path: 'my-donations', title: 'My Donations', icon: 'content_paste', class: '' },
  { path: 'leaderboard', title: 'Leaderboard', icon: 'library_books', class: '' },
  { path: 'scan-donation', title: 'Scan donation', icon: 'library_books', class: '' },
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
