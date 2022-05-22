using QuizGameSimple.Data;
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
        private readonly DAL dal = new();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MinimumCorrect { get; set; }

        public void Save()
        {
            if(dal.ReadQuiz(this) != null)
            {
                dal.UpdateQuiz(this);
            }
            
        }
        public List<Quiz> GetAll()
        {
            return dal.ReadAllQuizzes();
        }
        public void New()
        {
            if(this.Name != null && this.Description != null && this.Questions != null)
            {
                dal.CreateQuiz(this);
            }
        }
    }
}
