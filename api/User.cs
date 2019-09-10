using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public int id { get; set; }

        public User()
        {
            username = "";
            email = "";
            id = 0;
        }

        public User(string newName, string newEmail, int newID)
        {
            username = newName;
            email = newEmail;
            id = newID;
        }
    }

}
