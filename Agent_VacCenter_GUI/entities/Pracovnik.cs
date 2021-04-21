using OSPStat;
using simulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace entities
{
    public enum TypPracovnika
    {
        ADMIN = Lokacie.MiestnostRegistracia,
        DOKTOR = Lokacie.MiestnostVysetrenie,
        SESTRICKA = Lokacie.MiestnostOckovanie
    }
    public class Pracovnik: PohyblivaEntita
    {
        public TypPracovnika TypPracovnika { get; set; }
        public int IDPracovnika { get; set; }
        public string Stav { get; set; } = "Nečinný";
        public bool Obedoval { get; set; } = false;
        public bool Obsadeny { get; set; } = false;
        public double ZaciatokObsluhovania { get; set; } = 0;
        public WStat Utilization { get; private set; }
        public double MeanUtiliztion { get => Utilization.Mean(); }
        public int Pracovisko { get; set; }
        public Pracovnik(OSPABA.Simulation sim)
            :base(sim) { Utilization = new WStat(sim); }

        public virtual void Clear()
        {
            Stav = "Nečinný";
            Obedoval = false;
            Obsadeny = false;

            ZaciatokObsluhovania = 0;
            Utilization.Clear();
        }
    }
}
