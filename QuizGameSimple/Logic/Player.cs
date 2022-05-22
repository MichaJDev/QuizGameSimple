using QuizGameSimple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGameSimple.Logic
{
    public class Player
    {
        private readonly DAL dal = new();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Highscore { get; set; }
        public List<Quiz> CompletedQuizzes { get; set; }

        public void Save()
        {
            if (dal.ReadPlayer(this) != null)
            {
                dal.UpdatePlayer(this);
            }
        }

        public void Get(int id)
        {
            Player p = new();
            p.Id = id;
            if (dal.ReadPlayer(p) != null)
            {
                p = dal.ReadPlayer(p);
                this.Id =p.Id;
                this.Name = p.Name;
                this.Highscore = p.Highscore;
                this.CompletedQuizzes = p.CompletedQuizzes;
            }
        }
        public void New()
        {
            if(this.Name != null)
            {
                this.Highscore = 0;
                this.CompletedQuizzes.Clear();
                dal.CreatePlayer(this);
            }
        } 
    }
}
