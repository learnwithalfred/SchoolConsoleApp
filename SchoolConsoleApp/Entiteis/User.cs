using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public abstract class User : IUser
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
    }
}
