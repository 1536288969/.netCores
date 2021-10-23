using Common;
using Common.Common;
using Entity;
using Entity.Manage;
using Entity.Manage.FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.IService;
using Service.IService.IManagers;
using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Utility;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerService _imanagerRepository;

        public HomeController(IManagerService imanagerRepository)
        {
          _imanagerRepository = imanagerRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var sjtu = _imanagerRepository.Query().ToList();
            var s = sjtu;
            //if (!ModelState.IsValid)
            //    return Content("失败了");

            return View();
            //return View();
        }
        [HttpPost]
        public ActionResult Index(Manager manager)
        {

            var WebResponseContents = new WebResponseContent();
           // var customer = new Manager();
            //ManagerValidation validationRules = new ManagerValidation();
            ValidationResult result =new ManagerValidation().Validate(manager);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " Error was: " + failure.ErrorMessage);
                }
            }

           // var sjtu = _imanagerRepository.Add(manager);
            return Json(1>0?WebResponseContents.OK("新增成功"):WebResponseContents.Error("新增失败，服务器异常"));
        }
        [HttpGet]
        public IActionResult Privacy()
        {

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
