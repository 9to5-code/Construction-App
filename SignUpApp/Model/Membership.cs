using System;

using System.ComponentModel.DataAnnotations.Schema;
namespace SignUpApp.Model
{
    public class Membership
    {
        public int Id { get; set; }
        public int Role { get; set; }
        [ForeignKey("UserId")]

        public int UserId {get;set;}
        public User User { get; set; }

    }


    enum role {
     Owner =0,
      Admin,

      User

    }
}
