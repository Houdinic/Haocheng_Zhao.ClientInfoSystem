using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model
{
    public class InteractionRequestModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmpId { get; set; }
        [MaxLength(1)]
        public string IntType { get; set; }
        [DataType(DataType.Date)]
        public DateTime? IntDate { get; set; }
        [MaxLength(500)]
        public string Remarks { get; set; }
    }
}
