using Minesweeper.Models;
using System.Web.Mvc;

namespace Minesweeper.Services.Business
{
    public class UserService
    {


        public bool loggedIn(Controller c)
        {
            return c.Session["user"] != null;
        }

        public UserModel loadUser()
        {
            //UserDAO userDAO = new UserDAO();

            return new UserModel();
        }



    }
}