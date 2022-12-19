using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwanserApi.Entity
{
    public class Answer : Entity
    {
        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime Date { get; set; }

        public string HtmlContent { get; set; }

    }
}
