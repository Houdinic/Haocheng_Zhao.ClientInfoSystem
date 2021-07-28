using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface
{
    public interface IEmployeeRepository: IAsyncRepository<Employees>
    {
        public Task<Employees> GetByName(string name);
    }
}
