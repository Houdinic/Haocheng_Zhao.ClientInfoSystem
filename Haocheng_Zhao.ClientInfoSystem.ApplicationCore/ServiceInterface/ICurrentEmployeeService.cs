using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface
{
    public interface ICurrentEmployeeService
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        string Name { get; }
    }
}
