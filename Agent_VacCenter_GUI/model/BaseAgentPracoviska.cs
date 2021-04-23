using entities;
using OSPABA;
using OSPStat;
using simulation;
using System.Collections;
using System.Collections.Generic;

namespace Agent_VacCenter_GUI.model
{
    public abstract class BaseAgentPracoviska : Agent
    {
        public Process ProcessObsluhy { get; protected set; }
        public Scheduler SchedulerObedov { get; protected set; }
        public StatistikyPracoviska StatistikyPracoviska { get; set; } = new StatistikyPracoviska();
        public int MaxPocetPracovnikov { get; set; } = 3;
        public int PocetPracujucich { get; set; } = 0;
        public int PocetObedujucich { get; set; } = 0;
        public int PocetUzNajedenychPracovnikov { get; set; } = 0;
        public int PocetVolnychPracovnikov { get => MaxPocetPracovnikov - PocetPracujucich - PocetObedujucich; }
        public bool ObsluhaVolna { get => PocetVolnychPracovnikov > 0; }
        public WStat DlzkaRadu { get; protected set; }
        public Stat DlzkaCakania { get; protected set; }
        public WStat VytazeniePracovnikov { get; protected set; }
        public bool JeCasObeda { get; set; } = false;
        public BitArray DostupniPracovnici { get; set; }
        public BitArray NenajedeniPracovnici { get; set; }

        public double PriemerneVytazeniePracovnikov { get => VytazeniePracovnikov.Mean() / MaxPocetPracovnikov; }
        //public List<Pracovnik> NenajedeniPracovnici { get; protected set; }
        protected OSPRNG.UniformDiscreteRNG[] _generatoryVyberuZamenstnanca;
        public Pracovnik[] Pracovnici { get; protected set; }
        protected List<Pracovnik> _dostupniPracovnici;
        public BaseAgentPracoviska(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {

        }

        public Pracovnik DajVolnehoPracovnika()
        {
            _dostupniPracovnici.Clear();
            /*for (int i = 0; i < MaxPocetPracovnikov; ++i)
                if (!_staff[i].Nedostupny)
                    _dostupniPracovnici.Add(_staff[i]);*/
            int i = -1;
            for (i = 0; i < MaxPocetPracovnikov; ++i)
            {
                if (DostupniPracovnici[i])
                    _dostupniPracovnici.Add(Pracovnici[i]);
            }

            if (_dostupniPracovnici.Count == 0)
                return null;

            if (_dostupniPracovnici.Count == 1)
                return _dostupniPracovnici[0];

            var generator = _generatoryVyberuZamenstnanca[_dostupniPracovnici.Count - 2];

            return _dostupniPracovnici[generator.Sample()];

        }

        public void InicializaciaPredSimulaciou(int lokaciaPracoviska)
        {
            NenajedeniPracovnici = new BitArray(MaxPocetPracovnikov, true);
            DostupniPracovnici = new BitArray(MaxPocetPracovnikov, true);
            //NenajedeniPracovnici = new List<Pracovnik>(MaxPocetPracovnikov);
            Pracovnici = new Pracovnik[MaxPocetPracovnikov];
            if (MaxPocetPracovnikov > 1)
                _generatoryVyberuZamenstnanca = new OSPRNG.UniformDiscreteRNG[MaxPocetPracovnikov - 1];

            for (int i = 0; i < MaxPocetPracovnikov; ++i)
            {
                if (lokaciaPracoviska == Lokacie.MiestnostOckovanie)
                {
                    Pracovnici[i] = new Sestricka(MySim);
                }
                else
                    Pracovnici[i] = new Pracovnik(MySim);
                Pracovnici[i].IDPracovnika = i;
                Pracovnici[i].Pracovisko = lokaciaPracoviska;
                Pracovnici[i].TypPracovnika = (TypPracovnika)lokaciaPracoviska;
            }

            for (int i = 0; i < MaxPocetPracovnikov - 1; ++i)
                _generatoryVyberuZamenstnanca[i] = new OSPRNG.UniformDiscreteRNG(0, i + 1);
            _dostupniPracovnici = new List<Pracovnik>(MaxPocetPracovnikov);
        }

        public virtual void InicializaciaPredReplikaciou()
        {

            NenajedeniPracovnici.SetAll(true);
            DostupniPracovnici.SetAll(true);
            //NenajedeniPracovnici.Clear();
            for (int i = 0; i < _generatoryVyberuZamenstnanca.Length; ++i)
                _generatoryVyberuZamenstnanca[i].Seed();

            for (int i = 0; i < MaxPocetPracovnikov; ++i)
            {
                Pracovnici[i].Clear();
                //NenajedeniPracovnici.Add(_staff[i]);
            }

            _dostupniPracovnici.Clear();

            DlzkaCakania.Clear();
            DlzkaRadu.Clear();
            VytazeniePracovnikov.Clear();
            PocetPracujucich = 0;
            PocetObedujucich = 0;
            PocetUzNajedenychPracovnikov = 0;
            InicializujStatisitky();
            JeCasObeda = false;
        }

        protected virtual void InicializujStatisitky()
        {
            string[][] statistikyZamestnancov = new string[Pracovnici.Length][];
            Pracovnik tmpPracovnik;
            for (int i = 0; i < Pracovnici.Length; ++i)
            {
                tmpPracovnik = Pracovnici[i];
                if (tmpPracovnik.TypPracovnika == TypPracovnika.SESTRICKA)
                {
                    statistikyZamestnancov[i] = new string[] { tmpPracovnik.IDPracovnika.ToString(), tmpPracovnik.Stav, tmpPracovnik.Obedoval ? "Áno" : "nie",
                        (tmpPracovnik.MeanUtiliztion * 100).ToString(), (tmpPracovnik as Sestricka).PocetNaplnenych.ToString() };
                }
                else
                    statistikyZamestnancov[i] = new string[] { tmpPracovnik.IDPracovnika.ToString(), tmpPracovnik.Stav, tmpPracovnik.Obedoval ? "Áno" : "nie", (tmpPracovnik.MeanUtiliztion * 100).ToString() };
            }
            StatistikyPracoviska.PriemernaDlzkaRadu = DlzkaRadu.Mean();
            StatistikyPracoviska.PriemernaDobaCakania = DlzkaCakania.Mean();
            StatistikyPracoviska.Vytazenie = VytazeniePracovnikov.Mean();
            StatistikyPracoviska.UdajeOPracovnikoch = statistikyZamestnancov;
        }

        public void UpdatujStatistiky()
        {
            StatistikyPracoviska.PriemernaDlzkaRadu = DlzkaRadu.Mean();
            StatistikyPracoviska.PriemernaDobaCakania = DlzkaCakania.Mean();
            StatistikyPracoviska.Vytazenie = VytazeniePracovnikov.Mean();
            if (Pracovnici[0].TypPracovnika == TypPracovnika.SESTRICKA)
            {
                Sestricka tmpPracovnik;
                for (int i = 0; i < MaxPocetPracovnikov; ++i)
                {
                    tmpPracovnik = (Pracovnici[i] as Sestricka);
                    StatistikyPracoviska.UdajeOPracovnikoch[i][1] = tmpPracovnik.Stav;
                    StatistikyPracoviska.UdajeOPracovnikoch[i][2] = tmpPracovnik.Obedoval ? "Áno" : "Nie";
                    StatistikyPracoviska.UdajeOPracovnikoch[i][3] = string.Format("{0:0.##}%", tmpPracovnik.MeanUtiliztion * 100);
                    StatistikyPracoviska.UdajeOPracovnikoch[i][4] = tmpPracovnik.PocetNaplnenych.ToString();
                }
            }
            else
            {
                Pracovnik tmpPracovnik;
                for (int i = 0; i < MaxPocetPracovnikov; ++i)
                {
                    tmpPracovnik = Pracovnici[i];
                    StatistikyPracoviska.UdajeOPracovnikoch[i][1] = tmpPracovnik.Stav;
                    StatistikyPracoviska.UdajeOPracovnikoch[i][2] = tmpPracovnik.Obedoval ? "Áno" : "Nie";
                    StatistikyPracoviska.UdajeOPracovnikoch[i][3] = string.Format("{0:0.##}%", tmpPracovnik.MeanUtiliztion * 100);
                }
            }
        }

        public void UpdateZaverecnychStatistik()
        {
            VytazeniePracovnikov.AddSample(PocetPracujucich);
            DlzkaRadu.AddSample(MyManager.Front.Count);
        }

        public new BaseManagerPracoviska MyManager 
        {
            get => base.MyManager as BaseManagerPracoviska;
        }

    }
}
