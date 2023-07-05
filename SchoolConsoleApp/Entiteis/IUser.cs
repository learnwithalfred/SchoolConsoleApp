using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolConsoleApp.Entiteis
{
    public interface IUser
    {
        int ID { get;}
        string Name { get; set; }
        string Email { get; set; }
    }
}
