using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameSimple.Logic
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsRightAnswer { get; set; }
        public Question Question { get; set; }

    }
}
