﻿using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Pacient : PohyblivaEntita
    {
        public int IDPacienta { get; set; }
        public double CelkovaDobaCakania { get; set; }
        /*public double DobaCakaniaNaRegistraciu { get; set; }
        public double DobaCakaniaNaVysetrenie { get; set; }
        public double DobaCakaniaNaOckovanie { get; set; }*/
        public Pacient(OSPABA.Simulation sim)
            : base(sim) { }

    }
}
