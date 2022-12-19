using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwanserApi.Entity
{
    public class Socials : Entity
    {
        public SocialsName SocialsName { get; set; }

        public string UserLink { get; set; }

        public string IconUrl { get; set; }
    }
}
