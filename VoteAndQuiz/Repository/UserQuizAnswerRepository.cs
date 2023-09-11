using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class UserQuizAnswerRepository : Repository<UserQuizAnswer>, IUserQuizAnswerRepository
    {
        private ApplicationDbContext _db;
        public UserQuizAnswerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserQuizAnswer obj)
        {
            _db.UserQuizAnswers.Update(obj);
        }
    }
}
