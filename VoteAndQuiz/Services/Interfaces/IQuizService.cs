using VoteAndQuiz.Models;

namespace VoteAndQuiz.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> CreateQuizAsync(Quiz quiz);
        Task<Quiz> GetQuizByIdAsync(int quizId);
        Task<List<Quiz>> GetAllQuizzesAsync();
        Task<QuizOption> CheckQuizAnswerAsync(int quizId, string userAnswer);
        Task<bool> DeleteQuizAsync(int quizId);
    }
}
