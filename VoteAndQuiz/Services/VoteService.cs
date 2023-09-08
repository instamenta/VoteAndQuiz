using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using VoteAndQuiz.Data;
using VoteAndQuiz.Models;
using VoteAndQuiz.Services.Interfaces;

namespace VoteAndQuiz.Services
{
    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public VoteService(ApplicationDbContext context, ILogger<VoteService> logger)
        {
            _context = context;
            _logger = logger;
        }
        //public int Id { get; set; }
        //public Guid CreatorId { get; set; }
        //[ForeignKey("CreatorId")]
        //public User Creator { get; set; }

        //public DateTime? UpdatedAt { get; set; } //TODO: Implement logic
        //public DateTime? DeletedAt { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime VoteEndDate { get; set; }//data do koqto e vote-a, data sled koqto slagash pechelivshi i zagubili

        //public int VoteOptionId { get; set; }
        //[ForeignKey("OptionId")]
        //public ICollection<VoteOption> Options { get; set; } //iskrataDick.Add('vupros3', 'kolko ti e kosmat')

        //public long voteVotes { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsDeleted { get; set; }
        public async Task<bool> CreateVoteAsync(User? creator, DateTime voteEndDate, ICollection<VoteOption> options)
        {
            try
            {

                
                //var creator = await _context.Users.FirstOrDefaultAsync(u => u.Id == creator.Id);

                if (creator == null)
                {
                    // In the controller return error 404

                    return false;
                }

                var newVote = new Vote
                {
                    CreatorId = creator.Id,
                    CreatedAt = DateTime.Now,
                    VoteEndDate = voteEndDate,
                    Options = options,
                    voteVotes = 0,
                    IsActive = true,
                    IsDeleted = false
                };

                _context.Votes.Add(newVote);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                _logger.LogError(ex, "An error occurred while creating a vote.");
                return false;
            }
        }

        public async Task<Vote> GetVoteByIdAsync(int voteId)
        {
            try
            {
                // Assuming you have a DbSet<Vote> in your DbContext called Votes
                var vote = await _context.Votes.FindAsync(voteId);

                // If the vote with the specified ID does not exist, FindAsync returns null
                return vote;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // For example, you can log the exception and return null
                _logger.LogError(ex, "An error occurred while retrieving a vote by ID.");
                return null;
            }
        }





        public async Task<List<Vote>> GetAllVotesAsync()
        {
            try
            {
                // Assuming you have a DbSet<Vote> in your DbContext called Votes
                var votes = await _context.Votes.ToListAsync();

                return votes;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // For example, you can log the exception and return an empty list
                _logger.LogError(ex, "An error occurred while retrieving all votes.");
                return new List<Vote>();
            }
        }

        public async Task<VoteOption> GetVoteResultAsync(int voteId)
        {
            try
            {
                // Assuming you have a DbSet<Vote> in your DbContext called Votes
                // and a DbSet<VoteOption> in your DbContext called VoteOptions
                var vote = await _context.Votes
                    .Include(v => v.Options) // Include the related VoteOptions
                    .FirstOrDefaultAsync(v => v.Id == voteId);

                if (vote == null)
                {
                    // Handle the case where the vote with the specified ID does not exist
                    return null; // or throw an exception or return an appropriate response
                }

                // Calculate the result by counting the votes for each option
                var result = vote.Options
                    .OrderByDescending(o => o.VoteCount)
                    .FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // For example, you can log the exception and return null
                _logger.LogError(ex, "An error occurred while retrieving the vote result.");
                return null;
            }
        }

        public async Task<bool> DeleteVoteAsync(int voteId)
        {
            try
            {
                // Assuming you have a DbSet<Vote> in your DbContext called Votes
                var vote = await _context.Votes.FindAsync(voteId);

                if (vote == null)
                {
                    // Handle the case where the vote with the specified ID does not exist
                    return false;
                }

                // Mark the vote as deleted (soft delete)
                // You can set a DeletedAt timestamp or a flag to indicate deletion
                vote.DeletedAt = DateTime.UtcNow;

                // Optionally, you can set IsActive and IsDeleted flags accordingly
                vote.IsActive = false;
                vote.IsDeleted = true;

                // Update the vote entity in the database
                _context.Votes.Update(vote);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, or return appropriate responses
                // For example, you can log the exception and return false
                _logger.LogError(ex, "An error occurred while deleting the vote.");
                return false;
            }
        }

        
    }
}
