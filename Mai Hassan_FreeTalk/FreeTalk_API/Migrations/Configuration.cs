namespace FreeTalk_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FreeTalk_Model;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<FreeTalkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FreeTalkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Adding data for test purposes
            #region User Data
            var users = new List<User>
            {
            new User(){UserName="Memo",Password="1234",FirstName="Mai",LastName="Hassan"},
            new User(){UserName="koko",Password="2222",FirstName="Khalid",LastName="Zakaria"},
            new User(){UserName="Soso",Password="3636",FirstName="Sara",LastName="Ali"},
            new User(){UserName="Dodo",Password="45852",FirstName="Dalia",LastName="Mohamed"},
            new User(){UserName="Bedo",Password="125388",FirstName="Bahaa",LastName="Ibrahim"},
            new User(){UserName="Omda",Password="@#%@",FirstName="Emad",LastName="Walid"},
            new User(){UserName="Lolla",Password="!!!#",FirstName="Hala",LastName="Abdullah"},
            new User(){UserName="Nevo",Password="88852",FirstName="Neveen",LastName="Gamal"},
            new User(){UserName="Juju",Password="2463",FirstName="Jehan",LastName="Yahia"},
            new User(){UserName="Lika",Password="der5d4a",FirstName="Malia",LastName="Karim"},

            };
            //Lambda expression to add the list of Users to the database
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
            #endregion


            #region Post Data
            var posts = new List<Post>
            {
            new Post(){PostContent="What a lovely day!!",PostType="Social",ParentID=null,
                       CreateDate =new DateTime(2016,2,2),UpdateDate=new DateTime(2016,2,2),UserId=1},

            new Post(){PostContent="Let's have party at my place tomorrow",PostType="Social",
                       CreateDate =new DateTime(2016,2,3),UpdateDate=null,ParentID=null,UserId=3},
            new Post(){PostContent="Yaaaaay, I'm coming",PostType="Social",
                       CreateDate =new DateTime(2016,2,3),UpdateDate=null,ParentID=2,UserId=2},
            new Post(){PostContent="I have Exame Tomorrow :(",PostType="Social",
                       CreateDate =new DateTime(2016,2,3),ParentID=2,UpdateDate=null,UserId=1},
            new Post(){PostContent="Count me in",PostType="Social",
                       CreateDate =new DateTime(2016,2,3),UpdateDate=null,ParentID=2,UserId=4},
            new Post(){PostContent="I'm Engaged",PostType="Social",
                       CreateDate =new DateTime(2016,2,5),UpdateDate=null,ParentID=null,UserId=5},
            new Post(){PostContent="Congratss",PostType="Social",
                       CreateDate =new DateTime(2016,2,5),ParentID=6,UpdateDate=null,UserId=1},
            new Post(){PostContent="Congratulationss, may god bless u",PostType="Social",
                       CreateDate =new DateTime(2016,2,5),ParentID=6,UpdateDate=null,UserId=4},
            new Post(){PostContent="Bad Headech",PostType="Health",
                       CreateDate =new DateTime(2016,2,6),UpdateDate=null,ParentID=null,UserId=8},
            new Post(){PostContent="How can we solve this problem?",PostType="Science",
                       CreateDate =new DateTime(2016,2,10),UpdateDate=null,ParentID=null,UserId=7},
            new Post(){PostContent="What is the best Diet?",PostType="Health",
                       CreateDate =new DateTime(2016,2,2),UpdateDate=new DateTime(2016,2,2),ParentID=null,UserId=1},
            new Post(){PostContent="Best Algorithm for Sorting",PostType="Science",
                       CreateDate =new DateTime(2016,2,12),UpdateDate=null,ParentID=null,UserId=4},
            new Post(){PostContent="Finally Graduated :D",PostType="Social",
                       CreateDate =new DateTime(2016,5,2),UpdateDate=null,ParentID=null,UserId=3},
            new Post(){PostContent="Congraaats",PostType="Social",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=12,UserId=9},
            new Post(){PostContent="Working on my new AI Project",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=null,UserId=6},
            new Post(){PostContent="Serving at the Red cross",PostType="Health",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=null,UserId=2},
            new Post(){PostContent="Let's go for walking",PostType="Social",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=1,UserId=5},
                       new Post(){PostContent="Take some medicine",PostType="Health",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=9,UserId=2},
                       new Post(){PostContent="I solved it with some help from Google ;)",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=10,UserId=6},
                       new Post(){PostContent="Don't eat Carbs",PostType="Health",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=11,UserId=9},
                       new Post(){PostContent="Yes it is",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=12,UserId=7},
                       new Post(){PostContent="I'm here for help",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=15,UserId=10},
                       new Post(){PostContent="Good Job!!",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=16,UserId=7},
                       new Post(){PostContent="Congratulationss",PostType="Science",
                       CreateDate =new DateTime(2016,5,3),UpdateDate=null,ParentID=13,UserId=4},


            };
            //Lambda Expression to add list of Posts to the data base
            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

            #endregion

        }
    }
}
