using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;

namespace Give_Blood.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        ApplicationUser GetByUsernameAndPassword(string username, string password);
    }

}
