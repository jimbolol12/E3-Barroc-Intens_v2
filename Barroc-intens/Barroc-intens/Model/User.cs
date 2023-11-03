using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSantaApp.Model
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public int? PickedUserId { get; set; }

        public User(string username)
        {
            this.Username = username;
            this.IsAdmin = false;
            this.PickedUserId = null;
        }
    }
}
