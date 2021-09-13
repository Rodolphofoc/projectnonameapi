using System;

namespace project.noname.domain.Models
{
    public class User
    {
        public int IdUser { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public int Status { get; set; }

        public string Password { get; set; }
    }
}
