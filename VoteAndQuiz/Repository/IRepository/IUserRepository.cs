using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        void Update(User User);
    }
}
