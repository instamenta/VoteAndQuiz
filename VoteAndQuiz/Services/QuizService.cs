using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Services.Interfaces;

namespace VoteAndQuiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _context;

        public QuizService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Quiz> CreateQuizAsync(Quiz quiz)
        {
            throw new NotImplementedException();
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<QuizOption> CheckQuizAnswerAsync(int quizId, string userAnswer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteQuizAsync(int quizId)
        {
            throw new NotImplementedException();
        }

        // Implement other methods as needed
    }
}
