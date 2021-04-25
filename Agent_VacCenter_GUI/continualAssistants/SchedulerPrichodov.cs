using OSPABA;
using simulation;
using agents;
using DataStructures;

namespace continualAssistants
{
	//meta! id="26"
	public class SchedulerPrichodov : Scheduler
	{
		private OSPRNG.UniformContinuousRNG _generatorPravdepodobnosti;
		private PairingHeap<double, double> _haldaPrichodov;

		public SchedulerPrichodov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			_generatorPravdepodobnosti = new OSPRNG.UniformContinuousRNG(0, 1, (MySim as VacCenterSimulation).GeneratorNasad);
			_haldaPrichodov = new PairingHeap<double, double>();
			MyAgent.VygenerujNepridenych();

			double casSimulacie = 0;
			var sim = MySim as VacCenterSimulation;

			int multiplier = 1;
			double casovyRozostup = 0;
			for(int i = 0; i < MyAgent.PocetObjednanychPacientov; ++i)
            {
				multiplier = 1;
				while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
				{
					++multiplier;
				}
				casovyRozostup = multiplier * MyAgent.CasMedziPrichodmi;
				if (casovyRozostup + casSimulacie > sim.CasPrevadzkyVSekundach)
				{
					return;
				}
				casSimulacie += casovyRozostup;
				_haldaPrichodov.Insert(casSimulacie, casSimulacie);
				if (casSimulacie > sim.CasPrevadzkyVSekundach)
					return;
			}

		}

		//meta! sender="AgentOkolia", id="28", type="Notice"
		public void ProcessNoticeNaplanujPrichod(MessageForm message)
		{
			//int multiplier = 1;
			var sim = MySim as VacCenterSimulation;
			/*while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
            {
                ++multiplier;
				if(multiplier * MyAgent.CasMedziPrichodmi + MySim.CurrentTime > sim.CasPrevadzkyVSekundach)
                {
					MyAgent.Generuj = false;
					return;
                }
            }*/
			if (_haldaPrichodov.Count == 0)
            {
				MyAgent.Generuj = false;
				return;
			}
				
				
			message.Code = Mc.NoticePrichodPacienta;
			double casPrichodu = _haldaPrichodov.GetMin();
            //System.Console.WriteLine(casPrichodu - sim.CurrentTime);
			Hold(casPrichodu - sim.CurrentTime, message);
		}

		public void ProcessNoticePrichodPacienta(MessageForm message)
		{
			message.Addressee = MyAgent;
			Notice(message);
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.NoticeNaplanujPrichod:
				ProcessNoticeNaplanujPrichod(message);
			break;

			case Mc.NoticePrichodPacienta:
				ProcessNoticePrichodPacienta(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentOkolia MyAgent
		{
			get
			{
				return (AgentOkolia)base.MyAgent;
			}
		}
	}
}
