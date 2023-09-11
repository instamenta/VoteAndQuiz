using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IUserQuizAnswerRepository:IRepository<UserQuizAnswer>
    {
        void Update(UserQuizAnswer obj);
    }
}
