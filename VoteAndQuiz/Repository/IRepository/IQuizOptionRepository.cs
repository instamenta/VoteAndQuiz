using VoteAndQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VoteAndQuiz.Repository.IRepository
{
    public interface IQuizOptionRepository : IRepository<QuizOption>
    {
        void Update(QuizOption obj);
    }
}
