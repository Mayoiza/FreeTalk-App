using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreeTalk_Model
{
    public class Post
    {
        #region Properties
        //PK Identity field 
        [Key]
        public int Id { get; set; }

        //FK Field 
        public int UserId { get; set; }

        //Post Field
        [Required]
        public string PostContent { get; set; }

        //Post Type
        [Required]
        public string PostType { get; set; }

        //Creation Date Field
        [Required]
        public DateTime CreateDate { get; set; }

        //Update Date Field
        //Nullable field
        public DateTime? UpdateDate { get; set; }

        //Parent ID for recursive relationship between the main post and the comments
        public int? ParentID { get; set; }

        //Navigation Property
        public User Users { get; set; }
        #endregion
    }
}
