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


        [HttpGet]
        public IActionResult UpdateEmployee(int id, string name, string designation)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["designation"] = designation;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _employeeService.UpdateEmployee(model);
            return LocalRedirect("~/");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = new EmployeeRequestModel()
            {
                Id = id
            };
            await _employeeService.DeleteEmployee(employee);
            return LocalRedirect("~/");
        }

    }
}
