using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreeTalk_Model
{
    public class User
    {
        //EntityFramework code first approach:
        //it uses the models to create the corresponding tables.
        //According to convention for both 
        //the Models the Id property will become the Primary key for that table.


        #region Properties

        //Primary Key
        [Key]
        public int Id { get; set; }

        //User name field
        [Required]
        public string UserName { get; set; }
        //Password fields
        [Required]
        public string Password { get; set; }

        //Member name fields 
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //Navigation Property
        public ICollection<Post> Posts { get; set; }

        //Here we have one to many relationship between Users and their Posts
        //As one user can has many posts while the post has only one user
        #endregion
    }
}
