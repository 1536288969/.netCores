using Common.AutofacManager;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Service.IService.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IManagerService _imanagerRepository;
        public LoginController(IManagerService imanagerRepository)
        {
            _imanagerRepository = imanagerRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View
        //}
    }
}
