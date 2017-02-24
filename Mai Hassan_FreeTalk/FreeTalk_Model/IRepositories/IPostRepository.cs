using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeTalk_Model
{
    //Here we make the Repository Interface for Posts
    //To be implemented at the Post Repository Class
    //According to the Repository Design Pattern
    public interface IPostRepository
    {
        //Interface Functions..
        //Adding post
        void Create(Post post);
        //Update on Post
        void Update(Post post);
        //Deleting post
        void Delete(int id,int userID);
        //Select all posts
        List<PostsReturn> GetMainPosts();
        // Selection List of posts with the same ID
        //i.e posts with parentID null will select all the main posts
        //and posts with a specific parent ID will select
        //all the Comments on a specific main post
        List<PostsReturn> GetComments(int id);

        //Filter Posts by Type
        List<PostsReturn> filterByType(string type);

        //Filter Posts by User
        List<PostsReturn> filterByUser(int userID);
    }
}
