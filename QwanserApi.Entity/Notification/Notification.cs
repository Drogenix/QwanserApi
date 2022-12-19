using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwanserApi.Entity.Notification
{
    public class Notification : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Date { get; set; }
        public bool IsReaded { get; set; }
    }
}
