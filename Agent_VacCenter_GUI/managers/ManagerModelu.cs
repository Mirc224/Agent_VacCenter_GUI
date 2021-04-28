using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Diagnostics;

namespace managers
{
	//meta! id="1"
	public class ManagerModelu : Manager
	{
		/**
         * Manazer agenta bossa, ktory sprostredkuje komunikaciu medzi okolim a vakcinacnym centrom. Zasiela spravy o inicializcii agentovi okolia.
         */
		public ManagerModelu(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! userInfo="Removed from model"
		public void ProcessNotice(MessageForm message)
		{
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="AgentVakCentra", id="18", type="Notice"
		public void ProcessNoticeOdchodPacienta(MessageForm message)
		{
			message.Addressee = ((VacCenterSimulation)MySim).AgentOkolia;
			Notice(message);
		}

		//meta! sender="AgentOkolia", id="15", type="Notice"
		public void ProcessNoticePrichodPacienta(MessageForm message)
		{
			//message.Addressee = MySim.FindAgent(SimId.AgentVakCentra);
			message.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
			Notice(message);
		}

		public void ProcessInicializuj(MessageForm message)
		{
			//message.Addressee = MySim.FindAgent(SimId.AgentOkolia);
			message.Addressee = ((VacCenterSimulation)MySim).AgentOkolia;
			Notice(message);
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.NoticeInicializuj:
				ProcessInicializuj(message);
			break;
				case Mc.NoticePrichodPacienta:
				ProcessNoticePrichodPacienta(message);
			break;

			case Mc.NoticeOdchodPacienta:
				ProcessNoticeOdchodPacienta(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentModelu MyAgent
		{
			get
			{
				return (AgentModelu)base.MyAgent;
			}
		}
	}
}