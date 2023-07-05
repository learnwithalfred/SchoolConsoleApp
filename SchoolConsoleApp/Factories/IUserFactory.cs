using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Factories
{

    public interface IUserFactory
    {
        Student CreateStudent(string name, string email, int age, string gender, string address, DateTime dateOfBirth, Parent parent);
        Teacher CreateTeacher(string name, string email, string specialty, string gender, string phoneNumber);
        Parent CreateParent(string name, string email, string phoneNumber, string address, string gender);
    }
}
