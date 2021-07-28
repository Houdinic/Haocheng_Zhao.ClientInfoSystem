using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haocheng_Zhao.ClientInfoSystem.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _employeeService.GetEmployeeById(id));
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _employeeService.AddNewEmployee(model);
            return LocalRedirect("~/");
        }
    }
}
