using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignUpApp.Model;
namespace SignUpApp.ApplicationLayer.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailId { get; set; }

        public string Role { get; set; }
    }
}