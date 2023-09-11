using Microsoft.AspNetCore.Mvc;

namespace VoteAndQuiz.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

    }
}
