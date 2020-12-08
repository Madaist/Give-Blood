import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  public user: UserDTO = new UserDTO()

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api['getUser']().subscribe((data: UserDTO) => {
      this.user = data;
      console.log(this.user);
    })
  }

}
