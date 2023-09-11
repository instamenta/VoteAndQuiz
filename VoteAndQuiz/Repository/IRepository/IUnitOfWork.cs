namespace VoteAndQuiz.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IQuizOptionRepository QuizOptionRepository { get; }
        IQuizRepository QuizRepository { get; }
        IUserQuizAnswerRepository UserQuizAnswerRepository { get; }
        IUserRepository UserRepository { get; }
        IUserVoteAnswerRepository UserVoteAnswerRepository { get; }
        IVoteOptionRepository VoteOptionRepository { get; }
        IVoteRepository voteRepository { get; }
        void Save();
    }
}
