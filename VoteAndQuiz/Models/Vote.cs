using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoteAndQuiz.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime VoteEndDate { get; set; }//data do koqto e vote-a, data sled koqto slagash pechelivshi i zagubili
        
        public int VoteOptionId { get; set; }
        [ForeignKey("OptionId")]
        public ICollection<VoteOption> Options { get; set; } 

        public long voteVotes { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
