import { Component, OnInit } from '@angular/core';
import { Donation } from '../models/donation/donation';
import { ApiService } from '../../api.service';
import { DonationHistoryDTO } from '../models/donationhistory/donation-history-dto';

@Component({
  selector: 'app-my-donations',
  templateUrl: './my-donations.component.html',
  styleUrls: ['./my-donations.component.css']
})
export class MyDonationsComponent implements OnInit {

  public donations: Array<DonationHistoryDTO> = new Array<DonationHistoryDTO>();
  constructor(private api: ApiService) { }

  ngOnInit(): void {

    this.api['getDonationsHistory']().subscribe((data: Array<DonationHistoryDTO>) => {
      this.donations = data;
      console.log(data);

    })
  }

}
