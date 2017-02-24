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
    //Valid Origin to allow access by our Angular application
    [EnableCorsAttribute("http://localhost:60525", "*", "*")]
    public class PostsController : ApiController
    {

        //At the PostController we will Call the Methods that we Create at the Repository
        private FreeTalkContext db = new FreeTalkContext();

        // GET: api/Posts
        [HttpGet]
        [Route("api/Posts")]
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPosts()
        {//Exception handling
            try
            {
                var postRepository = new PostRepository();
                return Ok(postRepository.GetMainPosts().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }//End Get Posts

        //Get all Comments Related to Main Post
        [HttpGet]
        [Route("api/Posts/{id}")]
        public IHttpActionResult GetComments(int id)
        {
            try
            {
                var postRepository = new PostRepository();
                return Ok(postRepository.GetComments(id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }//End Get Comments

        //GET Post by ID
        // GET: api/Posts/5
        //[ResponseType(typeof(Post))]
        //public IHttpActionResult GetPost(int id)
        //{
        //    Post post = db.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(post);
        //}


        //Filter Posts by User

        [HttpGet]
        [Route("api/Posts/user/{userId}")]
        public IHttpActionResult FilterByUser(int userID)
        {
            if (userID == 0)
            {
                return GetPosts();
            }
            else
            {
                try
                {
                    var postRepository = new PostRepository();
                    return Ok(postRepository.filterByUser(userID));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
 
        }//End Filter By User


        //Filter by user and Type
        [HttpGet]
        [Route("api/Posts/{type}/{userID}")]
        public IHttpActionResult FilterByUser_Type(int userID, string Type)
        {
            if (userID == 0 && Type=="All")
            {
                return GetPosts();
            }
            else if (userID==0)
            {
                return FilterByType(Type);
            }else if(Type=="All")
            {
                
                return FilterByUser(userID);
            }else
            {
            try
                {
                    var postRepository = new PostRepository();
                    return Ok(postRepository.filterUser_Type(userID,Type));
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }

        }//End Filter By User and Type



        //Filter Posts By Type
        [HttpGet]
        [Route("api/Posts/filter/{Type}")]
        public IHttpActionResult FilterByType(string type)
        {

            if (type == "All")
            {
                return GetPosts();
            }
            else
            {
                try
                {
                    var postRepository = new PostRepository();
                    return Ok(postRepository.filterByType(type));
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }

            }
        }//End Filter By Type

        //Update post
        // PUT: api/Posts/5
        [Route("api/Posts/edit/{id}")]
        [HttpPost]
        public IHttpActionResult PutPost(int id, [FromBody]Post post)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }
            post.UpdateDate = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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
        //End Update



        // POST: api/Posts
        [Route("api/Posts/add")]
        [ResponseType(typeof(Post))]
        [HttpPost]
        public HttpResponseMessage AddPost(Post post)
        {
            //Return error message if user tried to create empty post
            if (string.IsNullOrWhiteSpace(post.PostContent))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Post cannot be empty");
            }
            else
            {//Return post location after creating post successfully
                try
                {
                    var postRepository = new PostRepository();
                    postRepository.Create(post);
                    var msg = Request.CreateResponse(HttpStatusCode.Created);
                    msg.Headers.Location = new Uri(Request.RequestUri + post.Id.ToString());
                    return msg;
                }
                catch (Exception)
                {

                    throw new Exception("error!!");
                }

            }

        }//End Create Posts


        // DELETE: api/Posts/delete/5
        [Route("api/Posts/delete/{id}/{userId}")]
        [HttpDelete]
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id, int userID)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    var postRepository = new PostRepository();
                    postRepository.Delete(id, userID);
                    return Ok(post);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }

            }
        }//End Delete Post

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}