using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IQuizRepository :IRepository<Quiz>
    {
        void Update(Quiz obj);
    }
}
