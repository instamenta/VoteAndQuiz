using Microsoft.EntityFrameworkCore;
using VoteAndQuiz.Models;

namespace VoteAndQuiz.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<QuizOption> QuizOptions { get; set; }
        public DbSet<VoteOption> VoteOptions { get; set; }
        public DbSet<UserQuizAnswer> UserQuizAnswers { get; set; }
        public DbSet<UserVoteAnswer> UserVoteAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasConversion(
                    v => v.ToByteArray(),
                    v => new Guid(v)
                );
        }
    }
}
