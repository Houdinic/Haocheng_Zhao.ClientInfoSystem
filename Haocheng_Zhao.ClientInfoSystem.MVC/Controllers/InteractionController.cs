using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Model;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;

namespace Haocheng_Zhao.ClientInfoSystem.MVC.Controllers
{
    public class InteractionController : Controller
    {
        private readonly IInteractionService _interactionService;
        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _interactionService.AllInteractions());
        }

        [HttpGet]
        public IActionResult AddInteraction()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInteraction(InteractionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _interactionService.AddNewInteraction(model);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult UpdateInteraction(int id, int empid, int clientid)
        {
            ViewData["id"] = id;
            ViewData["empid"] = empid;
            ViewData["clientid"] = clientid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInteraction(InteractionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _interactionService.UpdateInteraction(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var interaction = new InteractionRequestModel()
            {
                Id = id
            };
            await _interactionService.DeleteInteraction(interaction);
            return RedirectToAction("Index");
        }
    }
}
