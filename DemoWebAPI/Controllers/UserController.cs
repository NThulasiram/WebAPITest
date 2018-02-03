using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DemoAPIRepository;

namespace DemoWebAPI.Controllers
{
    //[System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: User
       
        public string GetFirstUserName()
        {
            DemoRepository repository = new DemoRepository();
            return repository.GetUserName();
        }
        [System.Web.Http.Route("GetAllUsers")]
        public IEnumerable<string> GetAllUsers()
        {
            DemoRepository repository = new DemoRepository();
            return repository.GetAllUsers();
        }
        [System.Web.Http.Route("GetAllUsersDetails")]
        public IEnumerable<User> GetAllUsersDetails()
        {
            DemoRepository repository = new DemoRepository();
            return repository.GetAllUsersDetails();
        }
        public bool PostUser(string userName,bool isAdmin,string password)
        {
            DemoRepository repository = new DemoRepository();
            User user = new User
            {
                UserName = userName,
                IsAdmin = isAdmin,
                Password = password
            };
            return repository.CreateUser(user);
        }
        public bool PutUser(int userId,string userName)
        {
            DemoRepository repository = new DemoRepository();
          
            return repository.UpdateUser(userId, userName);
        }
    }
}