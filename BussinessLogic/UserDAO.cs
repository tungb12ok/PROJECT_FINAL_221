using BussinessLogic.Repository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class UserDAO : IUserRepository
    {
        private QuickMarketContext context;
        private static UserDAO instance = null;
        private readonly static Object instanceLock = new Object();


        public UserDAO()
        {
            context = new QuickMarketContext();
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }
        public User login(string username, string password)
        {
            User u = null;
            try
            {
                u = context.Users.FirstOrDefault(x => x.Username.Equals(username) && x.PasswordHash.Equals(password));
            }
            catch (Exception ex)
            {
            }
            return u;
        }

        public User signUp(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User updatePassword(User user)
        {
            User update = context.Users.FirstOrDefault(x => x.UserId == user.UserId);
            try
            {
                update.PasswordHash = user.PasswordHash;
                context.SaveChanges();

            }
            catch (Exception ex)
            {
            }
            return update;
        }
    }
}
