using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeTalk_Model;

namespace FreeTalk_API
{
    //Implementing IPostRepository Interface
    public class UserRepository : IUserRepository
    {
        //For Login Taking UserName and Password and return Id
        public int LoginUser(string userName, string password)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                int userID = db.Users.Where(u => u.UserName == userName && u.Password == password)
                   .Select(x => x.Id).SingleOrDefault();
                return userID;
            }

        }
        //Get User by ID
        public User GetUser(int id)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                return db.Users.Where(u => u.Id == id).SingleOrDefault();
            }
        }

        //Get all Users
        public List<User> GetUsers()
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                return db.Users.ToList();

            }
        }
    }
}