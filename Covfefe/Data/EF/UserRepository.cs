using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.EF
{
    public class UserRepository : BaseRepository<User>, IUser
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<User> GetAlls()
        {
            return dbContext.User.AsEnumerable();
        }

        public User getUser(int ID)
        {
            return (User)dbContext.User.Where(x => x.Id == ID.ToString()).SingleOrDefault();
        }
    }
}
