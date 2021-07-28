using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The passowrd should be minimum of 8 characters", MinimumLength = 8)]
        public string Password { get; set; }
        [StringLength(500)]
        public string Designation { get; set; }
    }
}
