using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Repository.IRepository;

namespace VoteAndQuiz.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IQuizOptionRepository QuizOption { get; private set; }

        public IQuizRepository Quiz { get; private set; }

        public IUserQuizAnswerRepository UserQuizAnswer { get; private set; }

        public IUserRepository User { get; private set; }

        public IUserVoteAnswerRepository UserVoteAnswer { get; private set; }

        public IVoteOptionRepository VoteOption { get; private set; }

        public IVoteRepository Vote { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            QuizOption = new QuizOptionRepository(_db);
            Quiz = new QuizRepository(_db);
            UserQuizAnswer = new UserQuizAnswerRepository(_db);
            User = new UserRepository(_db);
            UserVoteAnswer = new UserVoteAnswerRepository(_db);
            VoteOption = new VoteOptionRepository(_db);
            Vote = new VoteRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
