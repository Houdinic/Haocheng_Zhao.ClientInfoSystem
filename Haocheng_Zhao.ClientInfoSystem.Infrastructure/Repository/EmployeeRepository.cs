using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Repository
{
    public class EmployeeRepository : EfRepository<Employees>, IEmployeeRepository
    {

        public EmployeeRepository(ClientInfoSystemDbContext dbContext):base(dbContext)
        {

        }
    }
}
