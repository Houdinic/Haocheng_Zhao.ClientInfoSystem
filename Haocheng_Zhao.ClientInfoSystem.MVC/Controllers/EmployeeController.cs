using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployeeLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _employeeService.Login(name: model.Name, model.Password);

            if (user == null)
            {
                // wrong password
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // identity object

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create the cookie
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/");
        }
    }
}
