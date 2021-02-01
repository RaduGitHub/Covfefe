using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Services
{
    public class UserService
    {
        private IUser userRepository;

        public UserService(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public User getUser(int ID)
        {
            return userRepository.getUser(ID);
        }

        public IEnumerable<User> GetAlls()
        {
            var asd = userRepository.GetAlls();
            return asd;
        }

        public void AddUser(User u)
        {
            userRepository.Add(u);
        }
    }
}
