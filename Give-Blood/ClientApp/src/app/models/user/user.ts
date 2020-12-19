import { League } from "../league/league";
import { Donation } from "../donation/donation";
import { UserBadges } from "../userbadges/userbadges";


export class User {
  Id: string;
  UserName: string;
  NormalizedUserName: string;
  Email: string;
  NormalizedEmail: string;
  EmailConfirmed: boolean;
  PasswordHash: string;
  SecurityStamp: string;
  ConcurrencyStamp: string;
  PhoneNumber: string;
  PhoneNumberConfirmed: boolean;
  TwofactorEnabled: boolean;
  LockoutEnd: Date;
  LockoutEnabled: boolean;
  AccessFailedCount: number;
  Address: string;
  BirthDate: Date;
  FirstName: string;
  LastName: string;
  BloodType: string;
  Weight: number;
  NumberOfPoints: number;
  LeagueId: string;
  Description: string;
  Age: number;

  League: League;
  Donations: Donation[];
  UserBadges: UserBadges[];

}
