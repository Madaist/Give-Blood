

using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.BagdeRepository
{
    public class BadgeRepository : GenericRepository<Badge>, IBadgeRepository
    {
        public BadgeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
