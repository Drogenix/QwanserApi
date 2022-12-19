using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwanserApi.Entity
{
    public class Question : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<QuestionTag> Tags { get; set; }
        public DateTime Date { get; set; }
        public string HtmlContent { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public bool IsClosed { get; set; }
    }
}
