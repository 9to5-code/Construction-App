using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailId{get;set;}    

        public string Password{get;set;}
    }
}