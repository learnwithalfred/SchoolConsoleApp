using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Bill
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Classroom Classroom { get; set; }

        public Bill(int id, string type, string description, decimal amount, DateTime createdAt, Classroom classroom)
        {
            ID = id;
            Type = type;
            Description = description;
            Amount = amount;
            CreatedAt = createdAt;
            Classroom = classroom;
        }
    }
}
