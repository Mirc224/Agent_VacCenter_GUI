using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Pacient : StavovaEntita
    {
        /**
         * Entita reprezentujuca pacienta. Obsahuje atributy pre zber statsitik ohladom cakacich dob casu prichodu a podobne.
         */
        public static int AktualneID {get; set;}
        public int IDPacienta { get; private set; }
        public double CelkovaDobaCakania { get => DobaCakaniaNaRegistraciu + DobaCakaniaNaVysetrenie + DobaCakaniaNaOckovanie; }
        public double DobaCakaniaNaRegistraciu { get => _casyCakaniaNaUkony[0]; set => _casyCakaniaNaUkony[0] = value; }
        public double DobaCakaniaNaVysetrenie { get => _casyCakaniaNaUkony[1]; set => _casyCakaniaNaUkony[1] = value; }
        public double DobaCakaniaNaOckovanie { get => _casyCakaniaNaUkony[2]; set => _casyCakaniaNaUkony[2] = value; }
        public double DobaCakaniaVCakarni { get; set; }
        public double CasPrichodu { get; set; }

        private double[] _casyCakaniaNaUkony = new double[3];
        public string NaformovatovanyCasPrichodu
        {
            get
            {
                TimeSpan t = TimeSpan.FromSeconds(CasPrichodu);
                return t.ToString(@"hh\:mm\:ss");
            }
        }

        public Pacient(OSPABA.Simulation sim)
            : base(sim) 
        {
            IDPacienta = AktualneID++;
        }

    }
}
