using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	//meta! id="26"
	public class SchedulerPrichodov : Scheduler
	{
		private OSPRNG.UniformContinuousRNG _generatorPravdepodobnosti;
		public SchedulerPrichodov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			_generatorPravdepodobnosti = new OSPRNG.UniformContinuousRNG(0, 1, (MySim as VacCenterSimulation).GeneratorNasad);
		}

		//meta! sender="AgentOkolia", id="28", type="Notice"
		public void ProcessNoticeNaplanujPrichod(MessageForm message)
		{
			int multiplier = 1;
            while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
            {
                ++multiplier;
            }
            message.Code = Mc.NoticePrichodPacienta;
			Hold(multiplier * MyAgent.CasMedziPrichodmi, message);
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
