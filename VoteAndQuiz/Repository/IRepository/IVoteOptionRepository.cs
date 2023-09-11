using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IVoteOptionRepository: IRepository<VoteOption>
    {
        void Update(VoteOption obj);
    }
}
