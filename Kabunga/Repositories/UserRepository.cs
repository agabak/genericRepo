using Kabunga.Data;
using Kabunga.Models;

namespace Kabunga.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DataContext dataContext): base(dataContext)
        { }
    }
}
