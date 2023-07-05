using SchoolConsoleApp.Entiteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Services
{
    public class BillService
    {
        private readonly List<Bill> bills;

        public BillService()
        {
            bills = new List<Bill>();
        }

        public void CreateBill(int id, string type, string description, decimal amount, DateTime createdAt, Classroom classroom)
        {
            Bill bill = new(id, type, description, amount, createdAt, classroom);
            bills.Add(bill);
        }

        public void AssignBillsToClassroomStudents(Classroom classroom)
        {
            List<Student> students = classroom.Students;
            foreach (Student student in students)
            {
                Bill bill = GetBillByClassroom(classroom);
                student.Bills.Add(bill);
            }
        }

        public decimal CalculateTotalBillAmount()
        {
            return bills.Sum(bill => bill.Amount);
        }

        public decimal CalculateTotalBillAmountByType(string type)
        {
            return bills.Where(bill => bill.Type == type).Sum(bill => bill.Amount);
        }

        private Bill GetBillByClassroom(Classroom classroom)
        {
            return bills.FirstOrDefault(bill => bill.Classroom == classroom);
        }
    }

}
