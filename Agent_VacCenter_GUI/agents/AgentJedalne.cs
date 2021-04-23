using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="117"
	public class AgentJedalne : Agent
	{
		public ProcessJedenia ProcessJedenia { get; set; }
		public AgentJedalne(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerJedalne(SimId.ManagerJedalne, MySim, this);
			ProcessJedenia = new ProcessJedenia(SimId.ProcessJedenia, MySim, this);
			AddOwnMessage(Mc.VykonajObed);
		}
		//meta! tag="end"
	}
}
