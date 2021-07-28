using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Repository
{
    public class EmployeeRepository : EfRepository<Employees>, IEmployeeRepository
    {

        public EmployeeRepository(ClientInfoSystemDbContext dbContext):base(dbContext)
        {

        }
        public override async Task<Employees> GetByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.Include(c => c.Interactions).FirstOrDefaultAsync(c => c.Id == id);
            return employee;
        }
        public async Task<Employees> GetByName(string name)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
