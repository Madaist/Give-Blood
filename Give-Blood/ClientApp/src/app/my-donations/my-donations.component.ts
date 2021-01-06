import { Component, OnInit } from '@angular/core';
import { Donation } from '../models/donation/donation';
import { ApiService } from '../../api.service';

@Component({
  selector: 'app-my-donations',
  templateUrl: './my-donations.component.html',
  styleUrls: ['./my-donations.component.css']
})
export class MyDonationsComponent implements OnInit {

  public donations_list: Array<Donation> = new Array<Donation>();
  constructor(private api: ApiService) { }

  ngOnInit(): void {

    this.api['getDonationsHostory']().subscribe((data: Array<Donation>) => {
      this.donations_list = data;

    })
  }

}
