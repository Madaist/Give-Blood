import { Donation } from "../donation/donation";
import { LeagueDTO } from "../league/leagueDTO";
import { BadgeDTO } from "../badge/badgeDTO";

export class UserDTO {
  id: string;
  email: string;
  address: string;
  birthDate: Date;
  firstName: string;
  lastName: string;
  bloodType: string;
  weight: number;
  NumberOfPoints: number;
  NrOfPeopleHelped: number;
  Description: string;
  NrOfDonations: number;
  DonatedBlood: number;
  age: number;
  
  League: LeagueDTO;
  Donations: Donation[];
  Badges: BadgeDTO[];

  constructor(Id?: string, Email?: string, LastName?: string, FirstName?: string, Address?: string, BloodType?: string, Weight?: number, BirthDate?: Date) {
    this.id = Id;
    this.email = Email;
    this.firstName = FirstName;
    this.lastName = LastName;
    this.address = Address;
    this.bloodType = BloodType;
    this.weight = Weight;
    this.birthDate = BirthDate;
  }

}
