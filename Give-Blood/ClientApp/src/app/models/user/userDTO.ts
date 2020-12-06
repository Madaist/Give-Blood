import { Donation } from "../donation/donation";
import { LeagueDTO } from "../league/leagueDTO";
import { BadgeDTO } from "../badge/badgeDTO";

export class UserDTO {
  Email: string;
  Address: string;
  BirthDate: Date;
  FirstName: string;
  LastName: string;
  BloodType: string;
  Weight: number;
  NumberOfPoints: number;
  NrOfPeopleHelped: number;
  Description: string;
  NrOfDonations: number;
  DonatedBlood: number;

  League: LeagueDTO;
  Donations: Donation[];
  Badges: BadgeDTO[];

}
