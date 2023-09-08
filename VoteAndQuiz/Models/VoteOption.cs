namespace VoteAndQuiz.Models
{
    public class VoteOption
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public long VoteCount { get; set; }
    }
}