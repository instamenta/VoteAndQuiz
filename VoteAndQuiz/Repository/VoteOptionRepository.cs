using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class VoteOptionRepository : Repository<VoteOption>, IVoteOptionRepository
    {
        private ApplicationDbContext _db;
        public VoteOptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(VoteOption obj)
        {
            _db.VoteOptions.Update(obj);
        }
    }
}
