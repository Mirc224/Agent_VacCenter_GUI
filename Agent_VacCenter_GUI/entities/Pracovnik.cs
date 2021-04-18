using OSPStat;
using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Pracovnik: PohyblivaEntita
    {
        public bool Obsadeny { get; set; } = false;
        public double ZaciatokObsluhovania { get; set; } = 0;
        public WStat Utilization { get; private set; }
        public double MeanUtiliztion { get => Utilization.Mean(); }
        public int Pracovisko { get; set; }
        public Pracovnik(OSPABA.Simulation sim)
            :base(sim) { Utilization = new WStat(sim); }
    }
}
