using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;


namespace Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseModel>> AllEmployees();
        Task<EmployeeResponseModel> GetEmployeeById(int id);
        Task<Employees> AddNewEmployee(EmployeeRequestModel model);
        Task<Employees> UpdateEmployee(EmployeeRequestModel model);
        Task<Employees> DeleteEmployee(EmployeeRequestModel model);
        Task<EmployeeResponseModel> Login(string name, string password);
    }
}
