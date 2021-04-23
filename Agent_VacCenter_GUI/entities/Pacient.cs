using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Pacient : StavovaEntita
    {
        public static int AktualneID {get; set;}
        public int IDPacienta { get; private set; }
        public double CelkovaDobaCakania { get; set; }
        /*public double DobaCakaniaNaRegistraciu { get; set; }
        public double DobaCakaniaNaVysetrenie { get; set; }
        public double DobaCakaniaNaOckovanie { get; set; }*/
        public Pacient(OSPABA.Simulation sim)
            : base(sim) 
        {
            IDPacienta = AktualneID++;
        }

    }
}
