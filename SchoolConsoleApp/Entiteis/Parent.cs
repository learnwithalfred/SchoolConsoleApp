using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Parent : User, IUser
    {
        public List<Student> Students { get; } = new List<Student>();
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public Parent(int id, string name, string email, string phoneNumber, string address, string gender)
            : base(id, name, email)
        {
            PhoneNumber = phoneNumber;
            Address = address;
            Gender = gender;
        }

        public override string ToString()
        {
            string studentNames = string.Join(", ", Students.Select(s => s.Name));
            return $"Name: {Name}\nEmail: {Email}\nPhone Number: {PhoneNumber}\nAddress: {Address}\nGender: {Gender}\nStudents: {studentNames}";
        }
    }
}
