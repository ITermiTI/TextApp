using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TextApp.Presentation.User;
using TextApp.Web.ViewModels;

namespace TextApp.Web.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IUserPresentationRepository UserPresentationRepository { get; }
        public HomeController(IUserPresentationRepository userPresentationRepository)
        {
            UserPresentationRepository = userPresentationRepository;
        }


        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated) return RedirectToAction("", "User");
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginPageModel loginPageModel)
        {
            if (ModelState.IsValid)
            {
                var result = await UserPresentationRepository.Login(loginPageModel.userDto);
                if (result)
                {
                    return RedirectToAction("", "User");
                }
                ModelState.AddModelError("", "Bad credentials");
            }

            return View(loginPageModel);
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("", "User");
            return View();
        }

        [HttpPost
          ]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterPageModel registerPageModel)
        {
            if (ModelState.IsValid)
            {
                var result = await UserPresentationRepository.Register(registerPageModel.userDto, registerPageModel.ShouldBeAdmin);
                if (result)
                {
                    return Redirect("/Login");
                }
                ModelState.AddModelError("", "Error during register");
            }
            return View(registerPageModel);
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            UserPresentationRepository.Logout();
            return RedirectToAction("");
        }

    }
}
