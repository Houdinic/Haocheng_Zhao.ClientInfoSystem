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
        public InteractionService(IAsyncRepository<Interactions> interactionRepo)
        {
            _interactionRepo = interactionRepo;
        }
    }
}
