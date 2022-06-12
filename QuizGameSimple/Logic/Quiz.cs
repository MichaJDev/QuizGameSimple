using QuizGameSimple.Data;
using QuizGameSimple.Logic.enums;

namespace QuizGameSimple.Logic
{
    public class Quiz
    {
        private readonly DAL dal = new();
        public bool Running { get; set; } = false;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MinimumCorrect { get; set; }

        public void Save()
        {
            if (dal.ReadQuiz(this) != null)
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
            if (this.Name != null && this.Description != null && this.Questions != null)
            {
                dal.CreateQuiz(this);
            }
        }
        public void Delete()
        {
            dal.DeleteQuiz(this);
        }

        public void Start(Panel p)
        {
            while (Running)
            {
                for (int y = 0; y < Questions.Count - 1; y++)
                {

                    Question q = Questions[y];
                    if (q != null)
                    {
                        if (!q.IsAnswered)
                        {
                            Label questionLbl = (Label)p.Controls.OfType<Label>().Where(x => x.Name.Contains($"Question{Questions.Count - 1}"));

                            questionLbl.Text = q.Description;
                            for (int i = 0; i < q.Answers.Count - 1; i++)
                            {
                                Label answerLbl = (Label)p.Controls.OfType<Label>().Where(x => x.Name.Contains($"Answer{i}"));
                                answerLbl.Text = q.Answers[i].Description;
                            }
                        }
                    }
                }
            }
        }
        public void AnswerQuestion(Question q, Answer a)
        {
            q.IsAnswered = true;
            if (q.GivenAnswer == q.CorrectAnswer)
            {
                q.IsCorrect = true;
                Questions.Remove(q);
            }
            else
            {
                q.IsCorrect = false;
            }
        }
    }
}
