using System.ComponentModel.DataAnnotations;

namespace VoteAndQuiz.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string AuthId { get; set; }
        public ICollection<UserQuizAnswer> UserQuizAnswers { get; set; }
        public ICollection<UserVoteAnswer> UserVoteAnswers { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        
    }
}
//the user needs to have a reference to his quiz and votes votes