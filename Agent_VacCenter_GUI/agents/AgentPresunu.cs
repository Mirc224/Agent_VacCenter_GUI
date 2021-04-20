using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="60"
	public class AgentPresunu : Agent
	{
		public ProcessPresunu ProcessPresunu { get; private set; }
		public AgentPresunu(int id, Simulation mySim, Agent parent) :
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
			new ManagerPresunu(SimId.ManagerPresunu, MySim, this);
			ProcessPresunu = new ProcessPresunu(SimId.ProcessPresunu, MySim, this);
			AddOwnMessage(Mc.NoticeKoniecPresunu);
			AddOwnMessage(Mc.NoticeZaciatokPresunu);
			AddOwnMessage(Mc.VykonajPresun);
		}
		//meta! tag="end"
	}
}
