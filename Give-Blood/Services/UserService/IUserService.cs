using Give_Blood.DTOs;

namespace Give_Blood.Services.UserService
{
    public interface IUserService
    {
        public UserDTO GetUserInfo(string userId);
        public void UpdateUserInfo(UserDTO userDTO);
        public void UpdateLeagueandBadges(string userId);
        public bool NeedsWeightUpdate(string userId);
        public bool PatchUser(string userId, int weight);
        public string CheckNextPossibleDonationDate(string userId);
    }
}
