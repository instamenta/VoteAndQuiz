using VoteAndQuiz.Models;

namespace VoteAndQuiz.Services.Interfaces
{
    public interface IQuizService
    {
        Task<Quiz> CreateQuizAsync(Quiz quiz);
        Task<Quiz> GetQuizByIdAsync(int quizId);
        Task<List<Quiz>> GetAllQuizzesAsync();
       
        Task<bool> DeleteQuizAsync(int quizId);
        Task<bool> UpdateQuizAsync(int quizId);
        Task<bool> FinishQuizAsync(int  quizId);
    }
}
