using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPIRepository
{

    public class DemoRepository
    {
        private readonly DemoDBEntities _demoDBEntities = null;

        public DemoRepository()
        {
            _demoDBEntities = new DemoDBEntities();
        }

        public string GetUserName()
        {
            return _demoDBEntities.Users.Select(o => o.UserName).FirstOrDefault();
        }

        public IEnumerable<string> GetAllUsers()
        {
            return _demoDBEntities.Users.Select(o => o.UserName).ToList();
        }

        public IEnumerable<User> GetAllUsersDetails()
        {
            return _demoDBEntities.Users;
        }

        public bool CreateUser(User user)
        {
            try
            {
                _demoDBEntities.Users.Add(user);
                _demoDBEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(int userId,string username)
        {
            try
            {
                var user = _demoDBEntities.Users.FirstOrDefault(o => o.Id == userId);
                user.UserName = username;
                _demoDBEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
