using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Address { get; set; }
        public DateTime? AddedOn { get; set; }
        public IEnumerable<Interactions> Interactions { get; set; }
    }
}
