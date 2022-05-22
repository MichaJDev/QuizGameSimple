using QuizGameSimple.Logic;
using QuizGameSimple.Logic.enums;
using System.Data.SqlClient;

namespace QuizGameSimple.Data
{
    public class DAL
    {
        private readonly string conString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
        public void CreateQuiz(Quiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "INSERT INTO Quizzes (Name,Description, Difficulty, MinimumCorrect) VALUES (@name,@desc,@diff,@min)";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@name", q.Name);
            cmd.Parameters.AddWithValue("@desc", q.Description);
            cmd.Parameters.AddWithValue("@diff", q.Difficulty.ToString());
            foreach(Question question in q.Questions)
            {
                CreateQuestion(question);
            }
            cmd.Parameters.AddWithValue("@min", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CreateQuestion(Question q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "INSERT INTO Questions (Description, Score) VALUES (@name,@score)";
            using SqlCommand cmd = new(sql, con);
           
            cmd.Parameters.AddWithValue("@desc", q.Description);
            foreach(Answer answer in q.Answers)
            {
                CreateAnswer(answer);
            }
            cmd.Parameters.AddWithValue("@diff", q.Score);
           

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CreateAnswer(Answer a)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "INSERT INTO Answers (Description, IsRightAnswer) VALUES (@name,@right)";
            using SqlCommand cmd = new(sql, con);

            cmd.Parameters.AddWithValue("@desc", a.Description);
            cmd.Parameters.AddWithValue("@right", a.IsRightAnswer);
            
        
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CreatePlayer(Player p)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "INSERT INTO Players (Name, HighScore) VALUES (@name,@score)";
            using SqlCommand cmd = new(sql, con);

            cmd.Parameters.AddWithValue("@desc", p.Name);
            
            cmd.Parameters.AddWithValue("@score", p.Highscore);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public Quiz ReadQuiz(Quiz q)
        {
            Quiz quiz = new Quiz();
            using SqlConnection con = new(conString);
            string sql = "SELECT * FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                quiz.Id = r.GetInt32(0);
                quiz.Name = r.GetString(1);
                quiz.Description = r.GetString(2);
                quiz.Questions = ReadQuestionsFromQuiz(q);
                quiz.Difficulty = ParseDifficulty(r.GetString(3));
                quiz.MinimumCorrect = r.GetInt32(4);
            }

        }

        public void ReadQuestion(Question q)
        {

        }
        public void ReadAnswer(Answer a)
        {

        }
        public void ReadPlayer(Player p)
        {

        }
        
        public void UpdateQuiz(Quiz q)
        {

        }
        public void UpdateQuestion(Question q)
        {

        }
        public void UpdateAnswer(Answer a)
        {

        }
        public void UpdatePlayer(Player p)
        {

        }
        public void QeleteQuiz(Quiz q)
        {

        }
        public void DeleteQuestion(Question q)
        {

        }
        public void DeleteAnswer(Answer a)
        {

        }
        public void DeletePlayer(Player p)
        {

        }

        private Difficulty ParseDifficulty(string s)
        {
            Difficulty d = Difficulty.NONE;
            switch (s)
            {
                case "Easy":
                    d = Difficulty.EASY;
                    break;
                case "Medium":
                    d = Difficulty.MEDIUM;
                    break;
                case "Hard":
                    d = Difficulty.HARD;
                    break;
            }
            return d;
        }
        private List<Question> ReadQuestionsFromQuiz(Quiz q)
        {
            throw new NotImplementedException();
        }
    }
}
