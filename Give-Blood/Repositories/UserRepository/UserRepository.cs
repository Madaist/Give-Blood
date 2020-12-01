using Give_Blood.Data;
using Give_Blood.Models;
using Give_Blood.Repositories.GenericRepository;
using System.Linq;

namespace Give_Blood.Repositories.UserRepository
{

    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationUser GetByUsernameAndPassword(string username, string password)
        {
            return _table.Where(x => x.UserName == username && x.PasswordHash == password).FirstOrDefault();
        }
    }

}
