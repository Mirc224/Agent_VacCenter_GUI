using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;
using entities;
using System.Collections.Generic;

namespace agents
{
	//meta! id="5"
	public class AgentVysetrenia : Agent
	{
		public ProcessVysetrenia ProcessVysetrenia { get; private set; }
		public int MaxPocetPracovnikov { get; set; } = 6;
		public int PocetVolnychPracovnikov { get; set; }
		public bool ObsluhaVolna { get => PocetVolnychPracovnikov > 0; }
		public WStat DlzkaRadu { get; private set; }
		public Stat DlzkaCakania { get; private set; }
		public WStat VytazeniePracovnikov { get; private set; }
		public double PriemerneVytazeniePracovnikov { get => VytazeniePracovnikov.Mean() / MaxPocetPracovnikov; }

		private OSPRNG.UniformDiscreteRNG[] _generatoryVyberuZamenstnanca;
		private Pracovnik[] _staff;
		private List<Pracovnik> _dostupniPracovnici;
		public AgentVysetrenia(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			PocetVolnychPracovnikov = MaxPocetPracovnikov;
			_staff = new Pracovnik[MaxPocetPracovnikov];
			if (MaxPocetPracovnikov > 1)
				_generatoryVyberuZamenstnanca = new OSPRNG.UniformDiscreteRNG[MaxPocetPracovnikov - 1];

			for (int i = 0; i < MaxPocetPracovnikov; ++i)
			{
				_staff[i] = new Pracovnik(MySim);
				_staff[i].Pracovisko = Lokacie.MiestnostVysetrenie;
			}

			for (int i = 0; i < MaxPocetPracovnikov - 1; ++i)
				_generatoryVyberuZamenstnanca[i] = new OSPRNG.UniformDiscreteRNG(0, i + 1);
			_dostupniPracovnici = new List<Pracovnik>(MaxPocetPracovnikov);

			DlzkaCakania.Clear();
			DlzkaRadu.Clear();
			VytazeniePracovnikov.Clear();
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

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerVysetrenia(SimId.ManagerVysetrenia, MySim, this);
			ProcessVysetrenia = new ProcessVysetrenia(SimId.ProcessVysetrenia, MySim, this);
			AddOwnMessage(Mc.NoticeZaciatokVysetrenia);
			AddOwnMessage(Mc.NoticeKoniecVysetrenia);

			DlzkaCakania = new Stat();
			DlzkaRadu = new WStat(MySim);
			VytazeniePracovnikov = new WStat(MySim);
		}
		//meta! tag="end"
	}
}
