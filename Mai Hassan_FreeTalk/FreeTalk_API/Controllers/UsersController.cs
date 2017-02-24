using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FreeTalk_Model;
using System.Web.Http.Cors;

namespace FreeTalk_API.Controllers
{
    [EnableCorsAttribute("http://localhost:60525", "*", "*")]
    public class UsersController : ApiController
    {
        private FreeTalkContext db = new FreeTalkContext();

        //Return userId for Login
        [HttpGet]
        [Route("api/Users/{userName}/{password}")]
        public IHttpActionResult LoginUser(string userName, string password)
        {
            //Return validation message if the user try to login with empty data
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Please enter username and password");
            }
            else
            {
                try
                {
                    var userRepository = new UserRepository();
                    int userID = userRepository.LoginUser(userName, password);
                    if (userID == 0)
                    {//Validation message if the entered username or password was not valid
                        return BadRequest("Invalid user name or password");
                    }
                    else
                    {//Successful registration and Return userID for authorization
                        return Ok(userID);
                    }
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }

            }
        }


        // GET: api/Users
        [HttpGet]
        [Route("api/Users")]
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}