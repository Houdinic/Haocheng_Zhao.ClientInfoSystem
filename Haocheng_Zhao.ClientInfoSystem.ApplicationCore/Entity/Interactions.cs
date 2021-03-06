using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity
{
    public class Interactions
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmpId { get; set; }
        public string IntType { get; set; }
        public DateTime? IntDate { get; set; }
        public string Remarks { get; set; }
        public Clients Client { get; set; }
        public Employees Emp { get; set; }
    }
}
