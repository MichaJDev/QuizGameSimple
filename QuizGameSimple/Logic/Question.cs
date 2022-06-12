using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameSimple.Logic
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }
        public int Score { get; set; }
        public Answer CorrectAnswer { get; set; }
        public Answer GivenAnswer { get; set; }
        public bool IsAnswered { get; set; }
        public bool IsCorrect { get; set; }
        public Quiz Quiz { get; set; }
    }
}
