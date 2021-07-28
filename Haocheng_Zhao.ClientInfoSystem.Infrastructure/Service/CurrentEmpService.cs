using System;
using System.Linq;
using System.Security.Claims;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;

namespace Haocheng_Zhao.ClientInfoSystem.Infrastructure.Service
{
    public class CurrentEmpService: ICurrentEmployeeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentEmpService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Name => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

    }
}
