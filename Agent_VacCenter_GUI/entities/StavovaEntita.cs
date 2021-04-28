using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{ 
    public class StavovaEntita : OSPABA.Entity
    {
        /**
         * Predstavuje potomka entity a predka vsektych entit v modeli a umoznuje zaznamenavat stav/cinnost entity pre jej vypis na GUI.
         */
        public string Stav { get; set; }
        public StavovaEntita(OSPABA.Simulation sim)
            :base(sim) { }
    }
}
