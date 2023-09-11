using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class UserVoteAnswerRepository: Repository<UserVoteAnswer>, IUserVoteAnswerRepository
    {
        private ApplicationDbContext _db;
        public UserVoteAnswerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserVoteAnswer obj)
        {
            _db.UserVoteAnswers.Update(obj);
        }
    }
}
