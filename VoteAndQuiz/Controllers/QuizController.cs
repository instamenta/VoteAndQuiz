using Microsoft.AspNetCore.Mvc;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository;
using VoteAndQuiz.Repository.IRepository;
using VoteAndQuiz.Services;
using VoteAndQuiz.Services.Interfaces;
//using VoteAndQuiz.Services.QuizService;
namespace VoteAndQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IQuizService _quizService;
        public QuizController(IUnitOfWork unitOfWork , IQuizService quizService,ILogger<VoteService> logger)
        {
            _unitOfWork = unitOfWork;
            _quizService = quizService;
            _logger = logger;
        }
        public IActionResult Index()//Lists all quizzes on the main quiz page
        {
            List<Quiz> quizzesList =  _unitOfWork.Quiz.GetAll().ToList();
            return View(quizzesList);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            // Use the Get method from your repository to retrieve the quiz by its ID
            var quiz = _unitOfWork.Quiz.Get(q => q.Id == id);

            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }
   



        public IActionResult Create()//This is the view of creation of a new quiz
        {

            return View();
        }
        [HttpPost,ActionName("Create")]
        public async Task<IActionResult> CreateAsync(Quiz obj)//this is the post method for creating a new quiz
        {
            var createdQuiz = await _quizService.CreateQuizAsync(obj);

            if (createdQuiz != null)
            {
                // Handle successful quiz creation, e.g., redirect to a success page or return a JSON response.
                return RedirectToAction("Index"); // Example: Redirect to the quiz list page
            }
            else
            {
                // Handle the case where quiz creation failed, e.g., show an error message.
                ModelState.AddModelError("", "Quiz creation failed."); // Add a model error
                _logger.LogError( "An error occurred while creating a quiz (in the controller).");
                return View("Create"); // Return to the create view with the error
            }
        }


        //Deleting a quiz
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Quiz? quizFromDb = _unitOfWork.Quiz.Get(u => u.Id == id);

            if (quizFromDb == null)
            {
                return NotFound();
            }
            return View(quizFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(int? id, int? userId)
        {
            //TODO: Deleting the quiz (only the person that has created the quiz can delete it)!!!!!!!!!!!!!

            // Check for missing parameters
            if (id == null || userId == null)
            {
                return BadRequest();
            }

            // Retrieve the quiz by ID
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id);

            // Check if the quiz exists
            if (quiz == null)
            {
                return NotFound();
            }

            // Ensure that your authentication logic correctly retrieves the logged-in user's information, including their user ID
            var loggedInUser = _unitOfWork.User.Get(u => u.AuthId == userId.ToString());

            if (loggedInUser == null)
            {
                return NotFound(); // Handle the case where the logged-in user doesn't exist
            }

            // Check if the logged-in user is the creator of the quiz
            if (quiz.CreatorId.ToString() != loggedInUser.AuthId)
            {
                return Forbid(); // Return a 403 Forbidden status code (or handle unauthorized deletion)
            }

            // Delete the quiz
            var deleted = await _quizService.DeleteQuizAsync((int)id);

            if (deleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle deletion failure if needed
                return View("Error"); // You can create an error view to display a message
            }


        }



        //Update (add one more vote for the quiz,) 
        [HttpPost]
        public async Task<IActionResult> Update(int? id, int? userId)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var quiz = _unitOfWork.Quiz.Get(u => u.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            var loggedInUser = _unitOfWork.User.Get(u => u.AuthId == userId.ToString());

            if (loggedInUser == null)
            {
                return NotFound(); // Handle the case where the logged-in user doesn't exist
            }
            var update = await _quizService.UpdateQuizAsync((int)id);
            

            if (update)
            {
                return RedirectToAction("Index");
            }
            else
            {
                
                return View("Error"); // You can create an error view to display a message
            }
        }


        //Finish the quiz
        [HttpPost]
        public async Task<IActionResult> Finish(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            // Call the FinishQuizAsync method to finish the quiz
            var finished = await _quizService.FinishQuizAsync(id.Value);

            if (finished)
            {
                // Quiz was successfully finished
                return RedirectToAction("Index"); // Redirect to the quiz list page
            }
            else
            {
                // Handle the case where finishing the quiz failed
                ModelState.AddModelError("", "Finishing the quiz failed."); // Add a model error
                _logger.LogError("An error occurred while finishing the quiz.");
                return View("Error"); // Redirect to the quiz list page with an error message
            }
        }








    }
        
        


 }

//_unitOfWork.Quiz.Add(obj);
//_unitOfWork.Save();
// return RedirectToAction("Index");