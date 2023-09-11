using VoteAndQuiz.Models;

namespace VoteAndQuiz.Repository.IRepository
{
    public interface IUserVoteAnswerRepository: IRepository<UserVoteAnswer>
    {
        void Update(UserVoteAnswer obj);
    }
}
