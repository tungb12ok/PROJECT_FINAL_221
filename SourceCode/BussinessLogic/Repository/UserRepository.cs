using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Repository
{
    public class UserRepository : IUserRepository
    {
        public User login(string username, string password) => UserDAO.Instance.login(username, password);

        public User signUp(User user) => UserDAO.Instance.signUp(user);

        public User updatePassword(User user) => UserDAO.Instance.updatePassword(user);
    }
}
