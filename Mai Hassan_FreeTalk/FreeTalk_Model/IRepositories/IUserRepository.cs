using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeTalk_Model
{
    //Here we make the Repository Interface for User
    //To be implemented at the User Repository Class
    //According to the Repository Design Pattern
    public interface IUserRepository
    {
        //For Login Taking UserName and Password and return UserId
        int LoginUser(string userName, string password);

        //Interface function that allow the selection of user by ID
      //  User GetUser(int id);
        //Interface function that allow the selection of List of users
        List<User> GetUsers();

    }
}
