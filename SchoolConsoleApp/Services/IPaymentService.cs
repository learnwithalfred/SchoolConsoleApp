using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Services
{
    public interface IPaymentService
    {
        void AddPayment(int id, int studentID, decimal amount, int billID);
        decimal CalculateTotalPaymentForStudent(Student student);
        decimal CalculateTotalPaymentAmount();
    }

}
