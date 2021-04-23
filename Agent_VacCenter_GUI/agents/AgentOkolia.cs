using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;
using entities;

namespace agents
{
	//meta! id="2"
	public class AgentOkolia : Agent
	{
		public SchedulerPrichodov SchedulerPrichodov { get; private set; }
		public Stat CelkovaDobaCakaniaPacientov { get; private set; }
		public int PocetNepridenychPacientov { get; private set; }

		public int PocetObjednanychPacientov { get; private set; } = 540;
		public double CasMedziPrichodmi { get => (double)(540 * 60)/ PocetObjednanychPacientov;}

		public int PocetPacientovVojdenych { get; set; }
		public int PocetPacientovOdidenych { get; set; }
		public bool Generuj { get; set; }

		private OSPRNG.UniformDiscreteRNG _generatorNepridenychPacientov;
		public AgentOkolia(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			_generatorNepridenychPacientov.Seed();
			PocetPacientovVojdenych = 0;
			PocetPacientovOdidenych = 0;
			Pacient.AktualneID = 0;
			CelkovaDobaCakaniaPacientov.Clear();
			PocetNepridenychPacientov = _generatorNepridenychPacientov.Sample();
			Generuj = true;
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerOkolia(SimId.ManagerOkolia, MySim, this);
			SchedulerPrichodov = new SchedulerPrichodov(SimId.SchedulerPrichodov, MySim, this);
			AddOwnMessage(Mc.NoticeOdchodPacienta);
			AddOwnMessage(Mc.NoticePrichodPacienta);
			AddOwnMessage(Mc.NoticeNaplanujPrichod);
			AddOwnMessage(Mc.NoticeInicializuj);

			_generatorNepridenychPacientov = new OSPRNG.UniformDiscreteRNG(5, 25);
			CelkovaDobaCakaniaPacientov = new Stat();
		}
		//meta! tag="end"
	}
}