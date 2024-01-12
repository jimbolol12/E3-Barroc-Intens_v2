using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public User(int id, string username, string password, string email, JobFunction jobfunction)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            JobFunction = jobfunction
;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public bool IsCompanyAdmin { get; set; }
        public int JobFunctionId { get; set; }
        public int? CompanyId { get; set; }
        public Company Company{ get; set; }
        public JobFunction JobFunction { get; set; }

        public static User LoggedInUser { get; private set; }
    }
}
