using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTOMIANA.Models
{
    class Players
    {
        public int account_id { get; set; }
        public string name { get; set; }
        public int games_played { get; set; }
        public int wins { get; set; }
        public Boolean is_current_team_member { get; set; }
    }
}
