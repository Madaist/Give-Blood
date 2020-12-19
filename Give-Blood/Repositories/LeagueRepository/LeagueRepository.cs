using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.LeagueRepository
{
    public class LeagueRepository : GenericRepository<League>, ILeagueRepository
    {
        public LeagueRepository(ApplicationDbContext context) : base(context)
        {   

        }

        
    }
}
