using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using School.DB;
using School.Services;
using School.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers.Web
{
    public class AppController:Controller
    {
        IMailService _mailService;
        IWorldRepository _repository;

        public AppController(IMailService mailService,IWorldRepository repo)
        {
            _mailService = mailService;
            _repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Trips()
        {
            var trips = _repository.GetAllTripsWithStops(User.Identity.Name);
            return View(trips);
        }


        public IActionResult About()
        {            
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.IsPost = false;
            return View();
        }

        public IActionResult TestPage()
        {
            return View();

        }

        public IActionResult TestTemplate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vm)
        {
            ViewBag.IsPost = true;
            if (ModelState.IsValid)
            {
                string userName = Startup.AppConfiguration["Email:UserName"];
                string password = Startup.AppConfiguration["Email:Password"];

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("MISCFG", "Missing config");
                }
                else
                {
                    Debug.WriteLine("Mail info :" + vm.ToString() + " Account info:" + userName + string.Empty.PadRight(password.Length, '*'));
                    if (_mailService.SendMail(vm.Name, vm.SurName, vm.Email, vm.Message))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Mail Sent !";
                    }
                }
            }
            return View();
        }
    }
}
