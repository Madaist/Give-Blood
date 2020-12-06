using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Collections.Generic;

namespace Give_Blood.Repositories.UserBadgesRepository
{
    public interface IUserBadgesRepository : IGenericRepository<UserBadges>
    {
        public IEnumerable<UserBadges> FindByUserId(string userId);
    }
}
