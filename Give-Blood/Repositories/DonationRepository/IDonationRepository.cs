using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Collections.Generic;

namespace Give_Blood.Repositories.DonationRepository
{
    public interface IDonationRepository : IGenericRepository<Donation>
    {
        public IEnumerable<Donation> FindByUserId(string id);
    }
}
