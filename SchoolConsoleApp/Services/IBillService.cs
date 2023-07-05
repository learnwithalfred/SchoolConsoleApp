using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Services
{
    public interface IBillService
    {
        void CreateBill(int id, string type, string description, decimal amount, DateTime createdAt, Classroom classroom);
        void AssignBillsToClassroomStudents(Classroom classroom);
        decimal CalculateTotalBillAmount();
        decimal CalculateTotalBillAmountByType(string type);
    }

}
