using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Services.Interfaces;

namespace VoteAndQuiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;


        public QuizService(ApplicationDbContext context,ILogger<QuizService> logger)
        {
            _context = context;
            _logger = logger;

        }
        //public int Id { get; set; }
        //public Guid CreatorId { get; set; }
        //[ForeignKey("CreatorId")]
        //public User Creator { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime QuizEndDate { get; set; }//data do koqto e quiza
        //public long quizVotes { get; set; }
        //public ICollection<QuizOption> Options { get; set; } //iskrataDick.Add('vupros3', 'kolko ti e kosmat')
        //public string CorrectOption { get; set; }
        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            try
            {
                // Check if the quiz creator exists
                var creator = await _context.Users.FirstOrDefaultAsync(u => u.Id == quiz.CreatorId);
                if (creator == null)
                {
                    // In the controller return error 404 or handle it as needed
                    return null;
                }

                // Create a new quiz
                var newQuiz = new Quiz
                {
                    CreatorId = quiz.CreatorId,
                    Name = quiz.Name,
                    CreatedAt = DateTime.Now,
                    QuizEndDate = quiz.QuizEndDate,
                    Options = quiz.Options,
                    CorrectOption = quiz.CorrectOption,
                   IsActive =  quiz.IsActive = true,
                   ShowQuiz = true,
                    quizVotes = 0 // Initialize vote count to 0
                    
                };

                _context.Quizzes.Add(newQuiz);
                await _context.SaveChangesAsync();

                return newQuiz;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                _logger.LogError(ex, "An error occurred while creating a quiz.");
                return null;
            }
        }


      

        public async Task<bool> DeleteQuizAsync(int quizId)
        {
            try
            {
                // Assuming you have a DbSet<Vote> in your DbContext called Votes
                var quiz = await _context.Quizzes.FindAsync(quizId);

                if (quiz == null)
                {
                    // Handle the case where the vote with the specified ID does not exist
                    return false;
                }

                // Mark the vote as deleted (soft delete)
                // You can set a DeletedAt timestamp or a flag to indicate deletion
                quiz.DeletedAt = DateTime.UtcNow;

                // Optionally, you can set IsActive and IsDeleted flags accordingly
                quiz.IsActive = false;
                quiz.IsDeleted = true;

                // Update the vote entity in the database
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // For example, you can log the exception and return false
                _logger.LogError(ex, "An error occurred while deleting the quiz.");
                return false;
            }
        }

        public async Task<bool> UpdateQuizAsync(int quizId)
        {

            try
            {
                var quiz = await _context.Quizzes.FindAsync(quizId);
                quiz.UpdatedAt = DateTime.UtcNow;
                quiz.IsActive = true;
                quiz.quizVotes += 1;
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while updating the quiz.");
                return false;
            }
        }

        public async Task<bool> FinishQuizAsync(int quizId)
        {

            try
            {
                var quiz = await _context.Quizzes.FindAsync(quizId);
                quiz.QuizEndDate = DateTime.UtcNow;
                quiz.IsActive = false;
                quiz.ShowQuiz = false;
                quiz.UpdatedAt = DateTime.UtcNow;
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync();
                return true;
                
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while finishing the quiz.");
                return false;
            }
        }

        // Implement other methods as needed
    }
}







//public async Task<Quiz> GetQuizByIdAsync(int quizId)
//{
//    try
//    {
//        // Assuming you have a DbSet<Vote> in your DbContext called Votes
//        var quiz = await _context.Quizzes.FindAsync(quizId);
//                        // If the vote with the specified ID does not exist, FindAsync returns null
//        return quiz;
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions, log errors, or return appropriate responses
//        // For example, you can log the exception and return null
//        _logger.LogError(ex, "An error occurred while retrieving a quiz by ID.");
//        return null;
//    }
//}

//public async Task<List<Quiz>> GetAllQuizzesAsync()
//{

//    try
//    {
//        // Assuming you have a DbSet<Vote> in your DbContext called Votes
//        var quizzes = await _context.Quizzes.ToListAsync();

//        return quizzes;
//    }
//    catch (Exception ex)
//    {
//        // Handle exceptions, log errors, or return appropriate responses
//        // For example, you can log the exception and return an empty list
//        _logger.LogError(ex, "An error occurred while retrieving all quizzes.");
//        return new List<Quiz>();

//    }
//}