using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeTalk_Model;


namespace FreeTalk_API
{
    //Implementing IPostRepository Interface
    public class PostRepository : IPostRepository
    {


        //Function to Create new Posts
        public void Create(Post post)
        {
            if (post == null)
            {
                throw new NotImplementedException("Post not intialized");
            }
            else
            {
                using (FreeTalkContext db = new FreeTalkContext())
                {
                    post.CreateDate = DateTime.Now;
                    db.Posts.Add(post);
                    db.SaveChanges();
                }
            }
        }//End Create



        //Function for Deleting Main Post and It's related comments
        public void Delete(int id, int userID)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                //Deleting the Related Comments
                var postComment = db.Posts.Where(p => p.ParentID == id).ToList();
                if (postComment != null)
                {
                    for (int i = 0; i < postComment.Count; i++)
                    {
                        db.Posts.Remove(postComment[i]);
                    }
                    
                }
                db.SaveChanges();
                
                //Deleting Main Post
                var postEntity = db.Posts.Where(p => p.Id == id && p.UserId == userID).SingleOrDefault();
                db.Posts.Remove(postEntity);
                db.SaveChanges();
                
            }
        }//End Delete


        //Function for Retrieving all the Main Posts
        public List<PostsReturn> GetMainPosts()
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                var mainPosts = from u in db.Users
                                join p in db.Posts on u.Id equals p.UserId
                                where p.ParentID == null
                                select new PostsReturn
                                {
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    UserName = u.UserName,
                                    Password = u.Password,
                                    PostContent = p.PostContent,
                                    PostType = p.PostType,
                                    CreateDate = p.CreateDate,
                                    UpdateDate = p.UpdateDate,
                                    UserId = p.UserId,
                                    Id = p.Id,

                                };
                return mainPosts.ToList();

            }
        }//End Retrieving main Posts 

        //Function for Retrieving all the Comments for a specific Post
        public List<PostsReturn> GetComments(int id)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                var comments = from u in db.Users
                               join p in db.Posts on u.Id equals p.UserId
                               where p.ParentID == id
                               select new PostsReturn
                               {
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   UserName = u.UserName,
                                   Password = u.Password,
                                   PostContent = p.PostContent,
                                   PostType = p.PostType,
                                   CreateDate = p.CreateDate,
                                   UpdateDate = p.UpdateDate,
                                   UserId = p.UserId,
                                   Id = p.Id,
                               };
                return comments.ToList();
            }
        }//End Retrieving Comments

        //Filtration of Posts by Type and User
        public List<PostsReturn> filterUser_Type(int userId, string type)
        {
        using(FreeTalkContext db = new FreeTalkContext())
        {
            var mainPosts = from u in db.Users
                           join p in db.Posts on u.Id equals p.UserId
                           where p.PostType == type && p.ParentID == null
                           && p.UserId ==userId
                           select new PostsReturn
                           {
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               UserName = u.UserName,
                               Password = u.Password,
                               PostContent = p.PostContent,
                               PostType = p.PostType,
                               CreateDate = p.CreateDate,
                               UpdateDate = p.UpdateDate,
                               UserId = p.UserId,
                               Id = p.Id,

                           };
            return mainPosts.ToList();

        
        }
        }//End Filter by User and Type

        //Filtration of Posts By Type
        public List<PostsReturn> filterByType(string type)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                var mainPosts = from u in db.Users
                                join p in db.Posts on u.Id equals p.UserId
                                where p.PostType == type && p.ParentID == null
                                select new PostsReturn
                                {
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    UserName = u.UserName,
                                    Password = u.Password,
                                    PostContent = p.PostContent,
                                    PostType = p.PostType,
                                    CreateDate = p.CreateDate,
                                    UpdateDate = p.UpdateDate,
                                    UserId = p.UserId,
                                    Id = p.Id,

                                };
                return mainPosts.ToList();

            }
        }//End Retrieving Posts by type



        //Filtration of Posts By User
        public List<PostsReturn> filterByUser(int userID)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                var mainPosts = from u in db.Users
                                join p in db.Posts on u.Id equals p.UserId
                                where p.UserId == userID && p.ParentID == null
                                select new PostsReturn
                                {
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    UserName = u.UserName,
                                    Password = u.Password,
                                    PostContent = p.PostContent,
                                    PostType = p.PostType,
                                    CreateDate = p.CreateDate,
                                    UpdateDate = p.UpdateDate,
                                    UserId = p.UserId,
                                    Id = p.Id,

                                };
                return mainPosts.ToList();

            }
        }//End Retrieving Posts by User



        //Updating Existed Post
        public void Update(Post post)
        {
            using (FreeTalkContext db = new FreeTalkContext())
            {
                var postEntity = db.Posts.Where(p => p.Id == post.Id).SingleOrDefault();
                if (postEntity == null)
                {
                    throw new NotImplementedException("Post not intialized");

                }
                else
                {
                    post.UpdateDate = DateTime.Now;
                    db.Entry(postEntity).CurrentValues.SetValues(post);
                    db.SaveChanges();
                }

            }
        }//End Updating Post

    }
}