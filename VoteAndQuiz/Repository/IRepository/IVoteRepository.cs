using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IVoteRepository:IRepository<Vote>
    {
        void Update(Vote obj);
    }
}
   