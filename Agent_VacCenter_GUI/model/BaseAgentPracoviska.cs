using entities;
using OSPABA;
using OSPStat;
using simulation;
using System.Collections.Generic;

namespace Agent_VacCenter_GUI.model
{
    public abstract class BaseAgentPracoviska: Agent
    {
        public Process ProcessObsluhy { get; protected set; }
        public StatistikyPracoviska StatistikyPracoviska { get; set; } = new StatistikyPracoviska();
        public int MaxPocetPracovnikov { get; set; } = 3;
        public int PocetVolnychPracovnikov { get; set; }
        public bool ObsluhaVolna { get => PocetVolnychPracovnikov > 0; }
        public WStat DlzkaRadu { get; protected set; }
        public Stat DlzkaCakania { get; protected set; }
        public WStat VytazeniePracovnikov { get; protected set; }

        public double PriemerneVytazeniePracovnikov { get => VytazeniePracovnikov.Mean() / MaxPocetPracovnikov; }

        protected OSPRNG.UniformDiscreteRNG[] _generatoryVyberuZamenstnanca;
        protected Pracovnik[] _staff;
        protected List<Pracovnik> _dostupniPracovnici;
        public BaseAgentPracoviska(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {

        }

        public Pracovnik DajVolnehoPracovnika()
        {
            _dostupniPracovnici.Clear();
            for (int i = 0; i < MaxPocetPracovnikov; ++i)
                if (!_staff[i].Obsadeny)
                    _dostupniPracovnici.Add(_staff[i]);

            if (_dostupniPracovnici.Count == 0)
                return null;

            if (_dostupniPracovnici.Count == 1)
                return _dostupniPracovnici[0];

            var generator = _generatoryVyberuZamenstnanca[_dostupniPracovnici.Count - 2];

            return _dostupniPracovnici[generator.Sample()];

        }

        public void InicializaciaPredSimulaciou(int lokaciaPracoviska)
        {
            _staff = new Pracovnik[MaxPocetPracovnikov];
            if (MaxPocetPracovnikov > 1)
                _generatoryVyberuZamenstnanca = new OSPRNG.UniformDiscreteRNG[MaxPocetPracovnikov - 1];

            for (int i = 0; i < MaxPocetPracovnikov; ++i)
            {
                if (lokaciaPracoviska == Lokacie.MiestnostOckovanie)
                {
                    _staff[i] = new Sestricka(MySim);
                }
                else
                    _staff[i] = new Pracovnik(MySim);
                _staff[i].IDPracovnika = i;
                _staff[i].Pracovisko = lokaciaPracoviska;
                _staff[i].TypPracovnika = (TypPracovnika)lokaciaPracoviska;
            }

            for (int i = 0; i < MaxPocetPracovnikov - 1; ++i)
                _generatoryVyberuZamenstnanca[i] = new OSPRNG.UniformDiscreteRNG(0, i + 1);
            _dostupniPracovnici = new List<Pracovnik>(MaxPocetPracovnikov);
        }

        public virtual void InicializaciaPredReplikaciou()
        {
            for (int i = 0; i < _generatoryVyberuZamenstnanca.Length; ++i)
                _generatoryVyberuZamenstnanca[i].Seed();

            for (int i = 0; i < MaxPocetPracovnikov; ++i)
            {
                _staff[i].Clear();
            }

            _dostupniPracovnici.Clear();

            DlzkaCakania.Clear();
            DlzkaRadu.Clear();
            VytazeniePracovnikov.Clear();
            PocetVolnychPracovnikov = MaxPocetPracovnikov;
            InicializujStatisitky();
        }

        protected virtual void InicializujStatisitky()
        {
            string[][] statistikyZamestnancov = new string[_staff.Length][];
            Pracovnik tmpPracovnik;
            for (int i = 0; i < _staff.Length; ++i)
            {
                tmpPracovnik = _staff[i];
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

    }
}
