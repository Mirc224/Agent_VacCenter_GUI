using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="117"
	public class ManagerJedalne : Manager
	{
		public ManagerJedalne(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentVakCentra", id="120", type="Request"
		public void ProcessVykonajObed(MessageForm message)
		{
			message.Addressee = MyAgent.ProcessJedenia;
			StartContinualAssistant(message);
		}

		//meta! sender="ProcessJedenia", id="125", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
			message.Code = Mc.VykonajObed;
			Response(message);
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
			case Mc.Finish:
				ProcessFinish(message);
			break;

			case Mc.VykonajObed:
				ProcessVykonajObed(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentJedalne MyAgent
		{
			get
			{
				return (AgentJedalne)base.MyAgent;
			}
		}
	}
}
