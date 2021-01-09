import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserDTO } from './app/models/user/userDTO';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  header = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  });
  baseUrl = 'https://localhost:44362/api';

  getUser()  {
    return this.http.get(this.baseUrl + '/User', { headers: this.header });
  }

  updateUser(user: UserDTO) {
    return this.http.put(this.baseUrl + '/User', user, { headers: this.header });
  }

  patchUser(weight: number) {
    return this.http.patch(this.baseUrl + '/User', weight, { headers: this.header });
  }

  checkWeightUpdateNeed() {
    return this.http.get(this.baseUrl + '/User/WeightUpdateNeed', { headers: this.header });
  }

  checkDonationNotification() {
    return this.http.get(this.baseUrl + '/User/CheckDonationNotification', { headers: this.header });
  }

  postDonation(qrCode: string) {
    return this.http.post(this.baseUrl + '/Donation', qrCode, { headers: this.header });
  }

  getTopThree() {
     return this.http.get(this.baseUrl + '/Leaderboard/TopThree', { headers: this.header });
  }
  getEntireTop() {
    return this.http.get(this.baseUrl + '/Leaderboard/All', { headers: this.header });
  }
  getUnassignedBagdes() {
    return this.http.get(this.baseUrl + '/Badge/GetUnassigned', { headers: this.header });
  }

  
}
