using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public interface IUserRepository
    {
        public User login(string username, string password);
        public User signUp(User user);
        public User updatePassword(User user);
    }
}
