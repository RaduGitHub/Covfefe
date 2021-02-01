using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Abstractions
{
    public interface IUser : IRepository<User>
    {
        User getUser(int ID);
        IEnumerable<User> GetAlls();
    }
}
