using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;

namespace Haocheng_Zhao.ClientInfoSystem.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _clientService.GetClientById(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var client = new ClientRequestModel()
            {
                Id = id
            };
            await _clientService.DeleteClient(client);
            return LocalRedirect("~/");
        }
        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(ClientRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _clientService.AddNewClient(model);
            return LocalRedirect("~/");
        }
        [HttpGet]
        public IActionResult UpdateClient(int id, string name, string address, string email, string phones)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["address"] = address;
            ViewData["email"] = email;
            ViewData["phones"] = phones;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _clientService.UpdateNewClient(model);
            return LocalRedirect("~/");
        }
    }
}
