using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using School.ViewModel;
using Microsoft.AspNet.Identity;
using School.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<WorldUser> _signInManager;

        public AuthController(SignInManager<WorldUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login","Auth");      
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm,string returnUrl)
        {

            ViewBag.VM = vm;
            ViewBag.ModelState = ModelState;

            if (ModelState.IsValid)
            {                
                var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, true, false);
                if (result.Succeeded)
                {
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Trips", "App");
                    }
                    else {
                        return Redirect(returnUrl);
                    }

                }
                else {
                    ModelState.AddModelError("ERRLOGIN", String.Format("Login failed for user {0}", vm.UserName));
                }
               
            }

            return View();
        }
    }
}
