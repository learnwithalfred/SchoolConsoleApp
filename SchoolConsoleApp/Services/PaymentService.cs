using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly List<Payment> payments;

        public PaymentService()
        {
            payments = new List<Payment>();
        }

        public void AddPayment(int id, int studentID, decimal amount, int billID)
        {
            Payment payment = new Payment(id, studentID, amount, billID);
            payments.Add(payment);
        }

        public decimal CalculateTotalPaymentForStudent(Student student)
        {
            return payments.Where(payment => payment.StudentID == student.ID).Sum(payment => payment.Amount);
        }


        public static decimal CalculateTotalBillAmount(List<Student> students)
        {
            var totalAmount = 0m;

            foreach (var student in students)
            {
                foreach (var bill in student.Bills)
                {
                    totalAmount += bill.Amount;
                }
            }

            return totalAmount;
        }



        public decimal CalculateTotalPaymentAmount()
        {
            return payments.Sum(payment => payment.Amount);
        }

}

}
