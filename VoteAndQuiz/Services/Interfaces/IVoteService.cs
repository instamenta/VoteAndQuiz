using VoteAndQuiz.Models;

namespace VoteAndQuiz.Services.Interfaces
{
    public interface IVoteService
    {
        Task<bool> CreateVoteAsync(User creator, DateTime voteEndDate, ICollection<VoteOption> options);
        Task<Vote> GetVoteByIdAsync(int voteId);
        Task<List<Vote>> GetAllVotesAsync();
        Task<VoteOption> GetVoteResultAsync(int voteId);
        Task<bool> DeleteVoteAsync(int voteId);
    }
}
