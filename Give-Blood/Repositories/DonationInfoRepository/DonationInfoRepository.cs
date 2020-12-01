
using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.DonationInfoRepository
{
    public class DonationInfoRepository : GenericRepository<DonationInfo>, IDonationInfoRepository
    {
        public DonationInfoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
