using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;

namespace Give_Blood.Repositories.DonationRepository
{
    public class DonationRepository: GenericRepository<Donation>, IDonationRepository
    {
        public DonationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Donation> FindByUserId(string id)
        {
            return GetAll().Where(x => x.UserId == id);
        }
    }
}
