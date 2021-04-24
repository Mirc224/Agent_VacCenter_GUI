using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public class Pacient : StavovaEntita
    {
        public static int AktualneID {get; set;}
        public int IDPacienta { get; private set; }
        public double CelkovaDobaCakania { get => _celkovaDobaCakania;
            set 
            {
                _casyCakaniaNaUkony[_cisloUkonu++] = value - _celkovaDobaCakania;
                _celkovaDobaCakania += value; 
            } 
        }
        public double DobaCakaniaNaRegistraciu { get => _casyCakaniaNaUkony[0];}
        public double DobaCakaniaNaVysetrenie { get => _casyCakaniaNaUkony[1]; }
        public double DobaCakaniaNaOckovanie { get => _casyCakaniaNaUkony[2]; }
        public double DobaCakaniaVCakarni { get; set; }
        public double CasPrichodu { get; set; }

        private int _cisloUkonu = 0;
        private double[] _casyCakaniaNaUkony = new double[3];
        public string NaformovatovanyCasPrichodu
        {
            get
            {
                TimeSpan t = TimeSpan.FromSeconds(CasPrichodu);
                return t.ToString(@"hh\:mm\:ss");
            }
        }

        private double _celkovaDobaCakania;
        public Pacient(OSPABA.Simulation sim)
            : base(sim) 
        {
            IDPacienta = AktualneID++;
        }

    }
}
