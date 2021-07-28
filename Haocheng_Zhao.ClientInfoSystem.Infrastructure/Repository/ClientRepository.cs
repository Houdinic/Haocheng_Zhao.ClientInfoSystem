using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Repository
{
    public class ClientRepository:EfRepository<Clients>,IClientRepository
    {
        public ClientRepository(ClientInfoSystemDbContext dbContext):base(dbContext)
        {

        }

        public override async Task<Clients> GetByIdAsync(int id)
        {
            var client= await _dbContext.Clients.Include(c => c.Interactions).FirstOrDefaultAsync(c => c.Id == id);
            return client;
        }
        //public override async Task<Clients> DeleteAsync(Clients entity)
        //{
        //    if (await _dbContext.Interactions.AnyAsync(i=>i.ClientId==entity.Id))
        //    {
        //        throw new Exception($"There are interactions existing for this client, delete interactions first");
        //    }
        //    var cl=await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == entity.Id);
        //    return await base.DeleteAsync(cl);
        //}
    }
}
