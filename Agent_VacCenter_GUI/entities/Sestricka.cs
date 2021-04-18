using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Sestricka : Pracovnik
    {
        public int PocetNaplnenych { get; set; } = 20;
        public Sestricka(OSPABA.Simulation sim)
            : base(sim) {}
    }
}
