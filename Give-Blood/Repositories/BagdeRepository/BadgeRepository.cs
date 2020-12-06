

using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Linq;

namespace Give_Blood.Repositories.BagdeRepository
{
    public class BadgeRepository : GenericRepository<Badge>, IBadgeRepository
    {
        public BadgeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Badge FindByName(string name)
        {
            return GetAll().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
