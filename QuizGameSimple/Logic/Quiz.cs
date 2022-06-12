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
        
        private Label qLbl, ans1Lbl, ans2Lbl, ans3Lbl;

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

        public void Play(Panel p)
        {
           
        }
        public void AskQuestion(Panel p)
        {
            Question q = Questions.First();
            

            foreach(Control c in p.Controls)
            {
                switch(c.Name)
                {
                    case "qLbl":
                        qLbl = (Label) c;
                        qLbl.Text = q.Description;
                        break;
                    case "ans1Lbl":
                        ans1Lbl = (Label) c;
                        ans1Lbl.Text = q.Answers[0].Description;
                        break;
                    case "ans2Lbl":
                        ans2Lbl = (Label)c;
                        ans2Lbl.Text = q.Answers[1].Description;
                        break;
                    case "ans3Lbl":
                        ans3Lbl = (Label)c;
                        ans3Lbl.Text = q.Answers[2].Description;
                        break;
                }
            }
        }
    }
}
