using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.DonationRepository
{
    public class DonationRepository: GenericRepository<Donation>, IDonationRepository
    {
        public DonationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
