using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;


namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Clients> AddNewClient(ClientRequestModel model)
        {
            var client = new Clients() {
                Email = model.Email,
                Phones = model.Phones,
                AddedOn = DateTime.Now,
                Address=model.Address,
                Name=model.Name
            };
            await _clientRepository.AddAsync(client);
            return client;
        }

        public async Task<List<ClientResponseModel>> AllClients()
        {
            var clients = await _clientRepository.ListAllAsync();
            var models = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                models.Add(new ClientResponseModel()
                {
                    Id=client.Id,
                    Name=client.Name,
                    Email=client.Email,
                    Address=client.Address,
                    AddedOn=client.AddedOn,
                    Phones=client.Phones,
                   
                });
            }
            return models;
        }

        public async Task<Clients> DeleteClient(ClientRequestModel model)
        {
            var client = new Clients()
            {
                Id = model.Id
            };
            return await _clientRepository.DeleteAsync(client);
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var model = new ClientResponseModel()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Address = client.Address,
                AddedOn = client.AddedOn,
                Phones = client.Phones,
            };
            var interactModels = new List<InteractionResponseModel>();
            foreach (var interaction in client.Interactions)
            {
                interactModels.Add(new InteractionResponseModel()
                {
                    Id = interaction.Id,
                    EmpId=interaction.EmpId,
                    ClientId=interaction.ClientId,
                    IntDate=interaction.IntDate,
                    IntType=interaction.IntType,
                    Remarks=interaction.Remarks,


                });
            }
            model.InteractionModels = interactModels;
            return model;
        }

        public async Task<Clients> UpdateNewClient(ClientRequestModel model)
        {

            var client = new Clients()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                AddedOn = model.AddedOn,
                Phones = model.Phones,

            };
            return await _clientRepository.UpdateAsync(client);
        }
    }
}
