using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model
{
    public class ClientRequestModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(64)]
        public string Email { get; set; }
        [StringLength(64)]
        public string Phones { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AddedOn { get; set; }
    }
}
