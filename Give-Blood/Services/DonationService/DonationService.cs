using Give_Blood.DTOs;
using Give_Blood.Models;
using Give_Blood.Repositories.DonationInfoRepository;
using Give_Blood.Repositories.DonationRepository;
using Give_Blood.Repositories.UserRepository;
using Give_Blood.Services.UserService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Give_Blood.Services.DonationService
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IDonationInfoRepository _donationInfoRepository;

        public DonationService(IDonationRepository donationRepository, IUserRepository userRepository, IUserService userService, IDonationInfoRepository donationInfoRepository)
        {
            _donationRepository = donationRepository;
            _userRepository = userRepository;
            _userService = userService;
            _donationInfoRepository = donationInfoRepository;
        }

        public bool CreateDonation(string userId, string donationCode)
        {
            bool isCreated = true;
            ApplicationUser user = _userRepository.FindById(userId);

            var allDonationCodes = _donationRepository.GetAll().Select(x => x.QrCode);
            if (allDonationCodes.Contains(donationCode))
            {
                isCreated = false;
                return isCreated;
            }

            string donationType = GetDonationType(donationCode);
            Donation donation = new Donation
            {
                Id = Guid.NewGuid().ToString(),
                Type = donationType,
                UserId = userId,
                Date = DateTime.Now,
                QrCode = donationCode
            };

            _donationRepository.Create(donation);

            user.NrOfPoints += _donationInfoRepository.FindById(donationType).NrOfPoints;

            _userRepository.Update(user);
            _userService.UpdateLeagueandBadges(userId);

            return isCreated;
        }

        private static string GetDonationType(string donationCode)
        {
            string donationType;
            switch (donationCode[0])
            {
                case '1':
                    {
                        donationType = DonationTypes.OrdinaryDonation;
                        break;
                    }
                case '2':
                    {
                        donationType = DonationTypes.SpecialDonation;
                        break;
                    }
                case '3':
                    {
                        donationType = DonationTypes.CovidPlasmaDonation;
                        break;
                    }
                default:
                    {
                        throw new Exception("Cod QR invalid");
                    }
            }

            return donationType;
        }

        public IEnumerable<DonationHistoryDTO> GetDonationsHistory(string userId)
        {
            var userDonations = _donationRepository.FindByUserId(userId);
            ICollection<DonationHistoryDTO> donationsDTO = new List<DonationHistoryDTO>();
            foreach(Donation donation in userDonations)
            {
                DonationHistoryDTO donationDTO = new DonationHistoryDTO
                {
                    QrCode = donation.QrCode,
                    Type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(donation.Type.ToLower()).Replace("_", " "),
                    Date = donation.Date.ToString("dd/M/yyyy", new CultureInfo("en-us"))
                };
                donationsDTO.Add(donationDTO);
            }
            return donationsDTO;
        }
    }
}
