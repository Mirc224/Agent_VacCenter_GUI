using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;

namespace agents
{
	//meta! id="48"
	public class AgentCakarne : Agent
	{
		public ProcessCakania ProcessCakania { get; private set; }
		public WStat DlzkaRadu { get; private set; }
		public int PocetLudiVCakarni { get; set; }
		public AgentCakarne(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			DlzkaRadu.Clear();
			PocetLudiVCakarni = 0;
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerCakarne(SimId.ManagerCakarne, MySim, this);
			ProcessCakania = new ProcessCakania(SimId.ProcessCakania, MySim, this);
			AddOwnMessage(Mc.NoticeKoniecCakania);
			AddOwnMessage(Mc.NoticeZaciatokCakania);

			DlzkaRadu = new WStat(MySim);
		}
		//meta! tag="end"
	}
}
