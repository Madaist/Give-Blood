using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.DonationInfoRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.LeagueRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.BadgeService;
using Give_Blood.Services.EmailSender;
using System;
using System.Linq;

namespace Give_Blood.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBadgeService _badgeService;
        private readonly ILeagueRepository _leagueRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationInfoRepository _donationInfoRepository;
        private readonly IEmailSender _emailSender;

        public UserService(IUserRepository userRepository, ILeagueRepository leagueRepository, IBadgeService badgeService, IDonationRepository donationRepository, IDonationInfoRepository donationInfoRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _leagueRepository = leagueRepository;
            _badgeService = badgeService;
            _donationRepository = donationRepository;
            _donationInfoRepository = donationInfoRepository;
            _emailSender = emailSender;
        }

        public UserDTO GetUserInfo(string userId)
        {
            ApplicationUser user = _userRepository.FindById(userId);
            UpdateLeagueandBadges(userId);

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Weight = user.Weight,
                Address = user.Address,
                BloodType = user.BloodType,
                Badges = _badgeService.GetAssignedBadgesDTO(user),
                Donations = user.Donations,
                NumberOfPoints = user.NrOfPoints,
                BirthDate = user.BirthDate,
                Age = (int)((DateTime.Now - user.BirthDate).TotalDays / 365)
        };

            League league = _leagueRepository.FindById(user.LeagueId);
            LeagueDTO leagueDTO = new LeagueDTO { Name = league.Name, Icon = league.Icon };
            userDTO.League = leagueDTO;

            int nrOfPeopleHelped = 0;
            int nrOfDonations = 0;

            var userDonations = _donationRepository.FindByUserId(userId);
            if (userDonations != null && userDonations.Any())
            {
                foreach (Donation donation in userDonations)
                {
                    nrOfPeopleHelped += _donationInfoRepository.FindById(donation.Type).NrOfPeopleHelped;
                    nrOfDonations++;
                }
            }
            userDTO.NrOfPeopleHelped = nrOfPeopleHelped;
            userDTO.NrOfDonations = nrOfDonations;
            userDTO.DonatedBlood = nrOfDonations * 450 / 1000.0;

            return userDTO;
        }

       public void UpdateUserInfo(UserDTO userDTO)
        {
            ApplicationUser user = _userRepository.FindById(userDTO.Id);
            var oldWeight = user.Weight;
            user.LastName = userDTO.LastName;
            user.FirstName = userDTO.FirstName;
            user.Address = userDTO.Address;
            user.BloodType = userDTO.BloodType;
            user.Weight = userDTO.Weight;
            user.BirthDate = userDTO.BirthDate;
            user.Age = (int)((DateTime.Now - userDTO.BirthDate).TotalDays / 365);
            if(oldWeight != userDTO.Weight)
                user.LastWeightUpdate = DateTime.Now;

            _userRepository.Update(user);
        }
 
        public void UpdateLeagueandBadges(string userId)
        {
            ApplicationUser user = _userRepository.FindById(userId);
            _badgeService.AssignBadges(user);
            if (user.NrOfPoints >= 0 && user.NrOfPoints <= 35) user.LeagueId = "1";
            if (user.NrOfPoints > 35 && user.NrOfPoints <= 70) user.LeagueId = "2";
            if (user.NrOfPoints > 70 && user.NrOfPoints <= 120) user.LeagueId = "3";
            if (user.NrOfPoints > 120 && user.NrOfPoints <= 160) user.LeagueId = "4";
            if (user.NrOfPoints > 160 && user.NrOfPoints <= 200) user.LeagueId = "5";
            if (user.NrOfPoints > 200 && user.NrOfPoints <= 250) user.LeagueId = "6";
            if (user.NrOfPoints > 250 && user.NrOfPoints <= 290) user.LeagueId = "7";
            if (user.NrOfPoints > 290 && user.NrOfPoints <= 400) user.LeagueId = "8";
            if (user.NrOfPoints > 400) user.LeagueId = "9";

            _userRepository.Update(user);
        }

        public bool NeedsWeightUpdate(string userId)
        {
            var user = _userRepository.FindById(userId);
            var currentDate = DateTime.Now;
            if (currentDate.Subtract(user.LastWeightUpdate).TotalDays >= 30)
                return true;
            return false;
        }

        public string CheckNextPossibleDonationDate(string userId)
        {
            var userDonations = _donationRepository.FindByUserId(userId).OrderByDescending(x => x.Date);
            if(userDonations != null && userDonations.Count() > 0)
            {
                var mostRecentDonationDate = userDonations.ElementAt(0).Date;
                var nearestPossibleDonationDate = mostRecentDonationDate.AddDays(90);
                if(DateTime.Now < nearestPossibleDonationDate)
                {
                    var dateDifference = nearestPossibleDonationDate.Subtract(DateTime.Now).TotalDays;
                    if (dateDifference <= 7)
                    {
                        var formattedDate = nearestPossibleDonationDate.ToString("dd/M/yyyy");
                        var message = "Poti dona din nou, incepand cu data de " + formattedDate;
                        if (dateDifference < 2)
                        {
                            SendMail(userId, formattedDate);
                        }
                        return message;
                    }
                }
                else
                {
                    return "Au trecut deja 3 luni de la ultima donatie. Poti dona din nou!";
                }
            }
            return null;
        }

        public void SendMail(string userId, string date)
        {
            var user = _userRepository.FindById(userId);
            var subject = "Vesti bune: poti dona din nou!";
            var message = "Salut " + user.FirstName + ",<br /><br />"
                + "Te anuntam ca incepand cu data de " + date
                + " poti dona din nou! Te asteptam in centrele de transfuzii pentru a darui viata."
                + "<br /><br /> P.S.: Nu amana! Pacientii au nevoie de tine acum.<br />"
                + "Echipa Give Blood";

            _emailSender.SendEmailAsync(user.Email, subject, message);
        }

        public bool PatchUser(string userId, int weight)
        {
            var user = _userRepository.FindById(userId);
            if(user == null)
            {
                return false;
            }
            user.Weight = weight;
            user.LastWeightUpdate = DateTime.Now;
            _userRepository.Update(user);
            return true;
        }

    }
}
