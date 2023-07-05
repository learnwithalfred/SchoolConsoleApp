using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    // Payment.cs

    public class Payment
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public decimal Amount { get; set; }
        public int BillID { get; set; }

        public Payment(int id, int studentID, decimal amount, int billID)
        {
            ID = id;
            StudentID = studentID;
            Amount = amount;
            BillID = billID;
        }
    }

}
