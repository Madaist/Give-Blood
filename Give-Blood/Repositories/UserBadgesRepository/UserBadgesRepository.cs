using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;

namespace Give_Blood.Repositories.UserBadgesRepository
{
    public class UserBadgesRepository : GenericRepository<UserBadges>, IUserBadgesRepository
    {
        public UserBadgesRepository(ApplicationDbContext context) : base(context) 
        { }

        public IEnumerable<UserBadges> FindByUserId(string userId)
        {
            return GetAll().Where(x => x.UserId == userId);
        }
    }
}
