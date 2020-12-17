import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDTO } from './app/models/user/userDTO';
import { User } from './app/models/user/user';

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
  getUnassignedBagdes() {
    return this.http.get(this.baseUrl + '/Badge/GetUnassigned', { headers: this.header });
  }

  updateUser(user: UserDTO) {
    return this.http.put(this.baseUrl + '/User', user, { headers: this.header });
  }
}
