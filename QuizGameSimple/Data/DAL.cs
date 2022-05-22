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
            cmd.Parameters.AddWithValue("@diff", StringifyDifficulty(q.Difficulty));
            foreach (Question question in q.Questions)
            {
                CreateQuestion(question);
            }
            cmd.Parameters.AddWithValue("@min", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
            cmd.Parameters.AddWithValue("@diff", q.Score);

            foreach (Answer answer in q.Answers)
            {
                CreateAnswer(answer);
            }
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
            Quiz quiz = new();
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT * FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                quiz.Id = r.GetInt32(0);
                quiz.Name = r.GetString(1);
                quiz.Description = r.GetString(2);
                quiz.Questions = ReadQuestions(q);
                quiz.Difficulty = ParseDifficulty(r.GetString(3));
                quiz.MinimumCorrect = r.GetInt32(4);
            }
            return q;

        }

        public List<Question> ReadQuestions(Quiz q)
        {
            List<Question> qs = new();
            Question question = new();
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT * FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                question.Id = r.GetInt32(0); ;
                question.Description = r.GetString(2);
                question.Answers = ReadAnswers(question);
                question.Quiz = ReadQuiz(q);
                qs.Add(question);
            }
            return qs;

        }
        public List<Answer> ReadAnswers(Question q)
        {
            List<Answer> answers = new();
            Answer a = new();
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT * FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                a.Id = r.GetInt32(0); ;
                a.Description = r.GetString(2);
                a.IsRightAnswer = r.GetBoolean(3);
                a.Question = q;
                answers.Add(a);
            }
            return answers;
        }
        public Player ReadPlayer(Player p)
        {
            using SqlConnection con = new(conString);
            string sql = "SELECT * FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", p.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                p.Id = r.GetInt32(0);
                p.Name = r.GetString(1);
                p.Highscore = r.GetInt32(2);
                p.CompletedQuizzes = ReadCompletedQuizzes(p);

            }
            return p;
        }

        public List<Quiz> ReadAllQuizzes()
        {
            List<Quiz> quizzes = new();
            Quiz q = new();
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT * FROM Quizzes";
            using SqlCommand cmd = new(sql, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                q.Id = r.GetInt32(0);
                q.Name = r.GetString(1);
                q.Description = r.GetString(2);
                q.Questions = ReadQuestions(q);
                q.Difficulty = ParseDifficulty(r.GetString(3));
                q.MinimumCorrect = r.GetInt32(4);
                quizzes.Add(q);
            }
            return quizzes;
        }

        public List<Quiz> ReadCompletedQuizzes(Player p)
        {
            List<Quiz> completed = new();
            Quiz q = new();
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT * FROM CompletedQuizzes WHERE @Id = id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                q.Id = r.GetInt32(0);
                Quiz nQ = ReadQuiz(q);
                completed.Add(nQ);
            }
            return completed;
        }

        public void UpdateQuiz(Quiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "UPDATE Quizzes SET Name = @Name, Description=@Desc, Difficulty = @Difficulty, MinimumCorrect = @MinimumCorrect WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);

            cmd.Parameters.AddWithValue("@Id", q.Id);
            cmd.Parameters.AddWithValue("@Name", q.Name);
            cmd.Parameters.AddWithValue("@Desc", q.Description);
            cmd.Parameters.AddWithValue("@Difficulty", StringifyDifficulty(q.Difficulty));
            cmd.Parameters.AddWithValue("MinimumCorrect", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            foreach (Question question in q.Questions)
            {
                UpdateQuestion(question);
            }
        }
        public void UpdateQuestion(Question q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "UPDATE Questions SET Description = @Desc, Score = @Score WHERE Id = @Id";
            SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("Id", q.Id);
            cmd.Parameters.AddWithValue("@Desc", q.Description);
            cmd.Parameters.AddWithValue("@Score", q.Score);
            foreach (Answer a in q.Answers)
            {
                UpdateAnswer(a);
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UpdateAnswer(Answer a)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "UPDATE Awnsers SET Description = @Desc, IsRightAnswer = @IsRightAnswer WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);

            cmd.Parameters.AddWithValue("@Id", a.Id);
            cmd.Parameters.AddWithValue("@Desc", a.Description);
            cmd.Parameters.AddWithValue("@IsRightAnswer", a.IsRightAnswer);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UpdatePlayer(Player p)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "UPDATE Players SET Name = @Name, Highscore = @Score WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Score", p.Highscore);
            foreach (Quiz q in p.CompletedQuizzes)
            {
                UpdateCompletedQuiz(q, p);
            }
        }

        public void UpdateCompletedQuiz(Quiz q, Player p)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "SELECT COUNT(*) FROM COMPLETED WHERE PlayerId = @PId";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Pid", p.Id);
            int count = (int)cmd.ExecuteScalar();
            if (count < p.CompletedQuizzes.Count())
            {
                int newCount = p.CompletedQuizzes.Count() - count;
                for (int i = 0; i < newCount; i++)
                {
                    if (i > count)
                    {
                        sql = "INSERT INTO CompletedQuizzes (QuizID, PlayerID) VALUES (@QId, @PId)";
                        cmd.Parameters.AddWithValue("@QId", q.Id);
                        cmd.Parameters.AddWithValue("@PId", p.Id);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        sql = "UPDATE CompletedQuizzes SET QuizId = @QId, PlayerID = @PId";
                        cmd.Parameters.AddWithValue("@QId", q.Id);
                        cmd.Parameters.AddWithValue("@PId", p.Id);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }

                }
            }
            else
            {
                sql = "UPDATE CompletedQuizzes SET QuizId = @QId WHERE PlayerID = @PId";
                cmd.Parameters.AddWithValue("@QId", q.Id);
                cmd.Parameters.AddWithValue("@PId", p.Id);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteQuiz(Quiz q)
        {
            foreach (Question question in q.Questions)
            {
                DeleteQuestion(question);
            }
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "DELETE FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeleteQuestion(Question q)
        {
            foreach (Answer a in q.Answers)
            {
                DeleteAnswer(a);
            }
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "DELETE FROM Questions WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeleteAnswer(Answer a)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "DELETE FROM Answers WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", a.Id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeletePlayer(Player p)
        {
            foreach (Quiz q in p.CompletedQuizzes)
            {
                DeleteCompletedQuiz(p);
            }
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "DELETE FROM Players WHERE Id = @Id";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public void DeleteCompletedQuiz(Player p)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string sql = "DELETE FROM CompletedQuizzes WHERE PlayerId = @PId";
            using SqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@PId", p.Id);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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

        private string StringifyDifficulty(Difficulty d)
        {
            if (d == Difficulty.EASY)
            {
                return "Easy";
            }
            else if (d == Difficulty.MEDIUM)
            {
                return "Medium";
            }
            else
            {
                return "Hard";
            }
        }
    }
}
