using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{ 
    public class StavovaEntita : OSPABA.Entity
    {
        public string Stav { get; set; }
        public StavovaEntita(OSPABA.Simulation sim)
            :base(sim) { }
    }
}
