using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Abstractions
{
    public interface IComment : IRepository<Comment>
    {
        Comment getComment(int ID);
    }
}
