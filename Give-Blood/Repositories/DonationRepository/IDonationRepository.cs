using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.DonationRepository
{
    public interface IDonationRepository : IGenericRepository<Donation>
    {
    }
}
