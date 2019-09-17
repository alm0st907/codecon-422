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
        public string passWord { get; set; }
        public int id { get; set; }

        public User()
        {
            username = "";
            email = "";
            passWord = "";
            id = 0;
        }

        public User(string newName, string newEmail, string newPasswd, int newID)
        {
            username = newName;
            email = newEmail;
            passWord = newPasswd;
            id = newID;
        }
    }

}
