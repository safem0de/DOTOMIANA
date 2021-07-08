using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTOMIANA.Models
{
    class Heroes
    {
        public string attack_type { get; set; }
        public int id { get; set; }
        public int legs { get; set; }
        public string localized_name { get; set; }
        public string name { get; set; }
        public string primary_attr { get; set; }
        public List<string> roles { get; set; }

    }
}
