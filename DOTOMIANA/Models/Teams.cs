using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTOMIANA.Models
{
    class Teams
    {
        public int team_id { get; set; }
        public double rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int last_match_time { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
    }
}
