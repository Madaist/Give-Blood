import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
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

  getUsers() {
     return this.http.get(this.baseUrl + '/User/GetAll', { headers: this.header });
  }
  getLeagueUsers() {
    return this.http.get(this.baseUrl + '/User/GetLeagueUsers', { headers: this.header });
  }
}
