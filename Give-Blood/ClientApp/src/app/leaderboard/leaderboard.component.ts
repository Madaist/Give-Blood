import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ApiService } from '../../api.service';
import { UserDTO } from '../models/user/userDTO';


@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {
  

  public users: Array<UserDTO> = new Array<UserDTO>();

  constructor(public formBuilder: FormBuilder, private api: ApiService) { }

  ngOnInit(): void {

    this.api['getLeagueUsers']().subscribe((data: Array<UserDTO>) => {
      this.users = data;
      console.log(this.users);
    })
}
}


