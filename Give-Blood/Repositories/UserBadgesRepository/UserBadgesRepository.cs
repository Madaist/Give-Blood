using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.UserBadgesRepository
{
    public class UserBadgesRepository : GenericRepository<UserBadges>, IUserBadgesRepository
    {
        public UserBadgesRepository(ApplicationDbContext context) : base(context) 
        { }
    }
}
