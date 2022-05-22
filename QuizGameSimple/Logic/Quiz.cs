using QuizGameSimple.Logic.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameSimple.Logic
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MinimumCorrect { get; set; }

    }
}
