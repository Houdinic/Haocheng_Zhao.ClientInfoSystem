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
    public class InteractionService:IInteractionService
    {
        private readonly IAsyncRepository<Interactions> _interactionRepo;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IClientRepository _clientRepository;
        public InteractionService(IAsyncRepository<Interactions> interactionRepo, IEmployeeRepository employeeRepository, IClientRepository clientRepository)
        {
            _interactionRepo = interactionRepo;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Interactions> AddNewInteraction(InteractionRequestModel model)
        {
            var  client=await _clientRepository.GetByIdAsync(model.ClientId);
            var emp=await _employeeRepository.GetByIdAsync(model.EmpId);
            if (client==null || emp==null)
            {
                throw new Exception("Cannot find the client or employee associated with this interaction");
            }
            var interact = new Interactions()
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntDate = model.IntDate,
                IntType = model.IntType,
                Remarks = model.Remarks,

            };
            await _interactionRepo.AddAsync(interact);
            return interact;
        }

        public async Task<List<InteractionResponseModel>> AllInteractions()
        {
            var interactions = await _interactionRepo.ListAllAsync();
            var models = new List<InteractionResponseModel>();
            foreach (var interact in interactions)
            {
                models.Add(new InteractionResponseModel() {
                Id=interact.Id,
                EmpId=interact.EmpId,
                ClientId=interact.ClientId,
                IntDate=interact.IntDate,
                IntType=interact.IntType,
                Remarks=interact.Remarks,
                });
            }
            return models;
        }

        public Task<InteractionResponseModel> GetInteractionById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Interactions> IInteractionService.DeleteInteraction(InteractionRequestModel model)
        {
            throw new NotImplementedException();
        }

        Task<Interactions> IInteractionService.UpdateInteraction(InteractionRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
