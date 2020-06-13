using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TextApp.Presentation.Text;

namespace TextApp.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ITextPresentationRepository TextPresentationRepository { get; }

        public UserController(ITextPresentationRepository textPresentationRepository)
        {
            TextPresentationRepository = textPresentationRepository;
        }
        public async Task<IActionResult> Index()
        {

            string name = User.Identity.Name;
            IEnumerable<TextDto> userTexts = await TextPresentationRepository.GetAllUsersText(HttpContext.User);
            return View("UsersText", userTexts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("AddText");
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TextDto textDto)

        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                await TextPresentationRepository.AddText(textDto, user);
                ModelState.Clear();
                return View("AddText");
            }
            return View("AddText", textDto);
        }

        public IActionResult Delete(IEnumerable<TextDto> userTexts, int ID)
        {
            TextPresentationRepository.DeleteText(ID);
            return RedirectToAction("");
        }
    }
}
