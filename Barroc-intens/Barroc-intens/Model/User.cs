using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Model

{
    public class User
    {
        public User()
        {
        }

        public User(int id, string username, string password, string jobfunction)
        {
            Id = id;
            Username = username;
            Password = password;
            JobFunction = jobfunction;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobFunction { get; set; }
    }
}
