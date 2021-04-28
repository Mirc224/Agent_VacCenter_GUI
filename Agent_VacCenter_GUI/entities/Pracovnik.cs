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
    public class Pracovnik: StavovaEntita
    {
        /**
         * Entita reprezentujuca pracovnika. Obsahuje atributy nesuce informacie o jeho stave, type, pracovisku ako aj jeho statisiky o vytazeni a dalsie
         * pomocne atributy, ktore su potrebne pre vypocet statistik.
         */
        public TypPracovnika TypPracovnika { get; set; }
        public int IDPracovnika { get; set; }
        public bool Obedoval { get; set; } = false;
        //public bool Nedostupny { get; set; } = false;
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
            //Nedostupny = false;

            ZaciatokObsluhovania = 0;
            Utilization.Clear();
        }
    }
}
