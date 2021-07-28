using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string Salt { get; set; }
        public IEnumerable<Interactions> Interactions { get; set; }
    }
}
