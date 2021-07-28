﻿using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
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
            if (employee == null)
            {
                throw new Exception($"Cannot find client with primary key {id} in DB ");
            }
            return employee;
        }
    }
}
