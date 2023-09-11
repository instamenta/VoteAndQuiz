using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private ApplicationDbContext _db;
        public QuizRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Quiz obj)
        {
            _db.Quizzes.Update(obj);
        }
    }
}
