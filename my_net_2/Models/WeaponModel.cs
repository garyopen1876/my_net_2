using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_net_2.Models
{
    public class Weapon
    {
        public string weapon_name { get; set; }
        public int weapon_attack { get; set; }
        public string weapon_own { get; set; }

        public string weapon_id { get; }
    }
}
