using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Factories
{

    public class UserFactory : IUserFactory
    {
        private int nextUserID = 1;

        public Student CreateStudent(string name, string email, int age, string gender, string address, DateTime dateOfBirth, Parent parent)
        {
            int id = GenerateUserID();
            return new Student(id, name, email, age, gender, address, dateOfBirth, parent);
        }

        public Teacher CreateTeacher(string name, string email, string specialty, string gender, string phoneNumber)
        {
            int id = GenerateUserID();
            return new Teacher(id, name, email, specialty, gender, phoneNumber);
        }

        public Parent CreateParent(string name, string email, string phoneNumber, string address, string gender)
        {
            int id = GenerateUserID();
            return new Parent(id, name, email, phoneNumber, address, gender);
        }

        private int GenerateUserID()
        {
            return nextUserID++;
        }
    }

}
