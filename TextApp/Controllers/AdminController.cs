using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TextApp.Presentation.Text;

namespace TextApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller

    {

        public ITextPresentationRepository TextPresentationRepository { get; }
        public AdminController(ITextPresentationRepository textPresentationRepository)
        {
            TextPresentationRepository = textPresentationRepository;
        }


        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<TextDto> texts = await TextPresentationRepository.GetAll();
            return View("AllTexts", texts);
        }

        public IActionResult Delete(IEnumerable<TextDto> userTexts, int ID)
        {
            TextPresentationRepository.DeleteText(ID);
            return RedirectToAction("");
        }
    }
}
