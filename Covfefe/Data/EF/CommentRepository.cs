using AutoMapper.Configuration;
using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.EF
{
    public class CommentRepository : BaseRepository<Comment>, IComment
    {
        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public Comment getComment(int ID)
        {
            return dbContext.Comment.Where(x => x.CommentID == ID).SingleOrDefault();
        }
    }
}
