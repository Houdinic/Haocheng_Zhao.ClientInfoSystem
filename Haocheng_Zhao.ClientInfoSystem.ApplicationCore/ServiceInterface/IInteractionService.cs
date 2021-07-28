using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;

namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface
{
    public interface IInteractionService
    {
        Task<List<InteractionResponseModel>> AllInteractions();
        Task<InteractionResponseModel> GetInteractionById(int id);
        Task<Interactions> AddNewInteraction(InteractionRequestModel model);
        Task<Interactions> UpdateInteraction(InteractionRequestModel model);
        Task<Interactions> DeleteInteraction(InteractionRequestModel model);
    } 
}
