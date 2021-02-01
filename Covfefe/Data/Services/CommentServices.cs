using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Services
{
    public class CommentServices
    {
        private IComment commentRepository;

        public CommentServices(IComment commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public Comment GetComment(int ID)
        {
            return commentRepository.getComment(ID);
        }

        public IEnumerable<Comment> GetAll()
        {
            return commentRepository.GetAll();
        }

        public void AddComment(Comment c)
        {
            commentRepository.Add(c);
        }
    }
}
