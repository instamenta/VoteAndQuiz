using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        private ApplicationDbContext _db;
        public VoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Vote obj)
        {
            _db.Votes.Update(obj);
        }
    }
}
