using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="48"
	public class ManagerCakarne : Manager
	{
		public ManagerCakarne(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="ProcessCakania", id="57", type="Notice"
		public void ProcessNoticeKoniecCakania(MessageForm message)
		{
			message.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
			--MyAgent.PocetLudiVCakarni;
			MyAgent.DlzkaRadu.AddSample(MyAgent.PocetLudiVCakarni);
			Notice(message);
		}

		//meta! sender="AgentVakCentra", id="51", type="Notice"
		public void ProcessNoticeZaciatokCakania(MessageForm message)
		{
			message.Addressee = MyAgent.ProcessCakania;
			((Sprava)message).ZaciatokObsluhy = MySim.CurrentTime;
			++MyAgent.PocetLudiVCakarni;
			MyAgent.DlzkaRadu.AddSample(MyAgent.PocetLudiVCakarni);
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
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.NoticeKoniecCakania:
				ProcessNoticeKoniecCakania(message);
			break;

			case Mc.NoticeZaciatokCakania:
				ProcessNoticeZaciatokCakania(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentCakarne MyAgent
		{
			get
			{
				return (AgentCakarne)base.MyAgent;
			}
		}
	}
}
