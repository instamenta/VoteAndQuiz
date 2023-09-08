﻿using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteAndQuiz.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime QuizEndDate { get; set; }//data do koqto e quiza
        public long quizVotes { get; set; }
        public ICollection<QuizOption> Options { get; set; } //iskrataDick.Add('vupros3', 'kolko ti e kosmat')
        public string CorrectOption { get; set; }
    }
}