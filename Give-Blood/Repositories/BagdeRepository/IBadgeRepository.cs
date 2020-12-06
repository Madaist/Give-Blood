using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.BagdeRepository
{
    public interface IBadgeRepository: IGenericRepository<Badge>
    {
        public Badge FindByName(string name);
    }
}
