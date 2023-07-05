using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public class Classroom
    {
        public int ID { get; set; }
        public List<Student> Students { get; set; }

        public Classroom(int id)
        {
            ID = id;
            Students = new List<Student>();
        }
    }
}
