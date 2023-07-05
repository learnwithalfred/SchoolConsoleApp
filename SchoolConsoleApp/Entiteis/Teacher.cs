using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Teacher : User, IUser
    {
        public string Specialty { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public Teacher(int id, string name, string email, string specialty, string gender, string phoneNumber)
            : base(id, name, email)
        {
            Specialty = specialty;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}
