using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface
{
    public interface IClientService
    {
        Task<List<ClientResponseModel>> AllClients();
        Task<ClientResponseModel> GetClientById(int id);
        Task<Clients> AddNewClient(ClientRequestModel model);
        Task<Clients> UpdateNewClient(ClientRequestModel model);
        Task<Clients> DeleteClient(ClientRequestModel model);
    }
}
