using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwanserApi.Entity
{
    public class Tag:Entity
    {
        public string Name { get; set; }

        public int TotalMentions { get; set; }

        public int MentionsToday { get; set; }
    }
}
