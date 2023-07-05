using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Student : User, IUser
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Parent Parent { get; set; }

        public Student(int id, string name, string email, int age, string gender, string address, DateTime dateOfBirth, Parent parent)
            : base(id, name, email)
        {
            Age = age;
            Gender = gender;
            Address = address;
            DateOfBirth = dateOfBirth;
            Parent = parent;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nAge: {Age}\nGender: {Gender}\nAddress: {Address}\nParent Name: {Parent.Name}";
        }
    }
}
