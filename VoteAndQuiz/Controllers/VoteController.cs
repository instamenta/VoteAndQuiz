using Microsoft.AspNetCore.Mvc;

namespace VoteAndQuiz.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
