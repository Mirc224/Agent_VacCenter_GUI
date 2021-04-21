using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;

namespace agents
{
	//meta! id="83"
	public class AgentPripravyDavok : Agent
	{
		public int MaxPocetVolnych { get; set; } = 2;
		public int PocetVolnych { get; set; } = 0;
		public bool ObsluhaVolna { get => PocetVolnych > 0; }
		public WStat DlzkaRadu { get; protected set; }
		public Stat DlzkaCakania { get; protected set; }
		public ProcessNaplnaniaDavok ProcessNaplnaniaDavok { get; private set; }
		public AgentPripravyDavok(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			PocetVolnych = MaxPocetVolnych;
			DlzkaRadu.Clear();
			DlzkaCakania.Clear();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerPripravyDavok(SimId.ManagerPripravyDavok, MySim, this);
			ProcessNaplnaniaDavok = new ProcessNaplnaniaDavok(SimId.ProcessNaplnaniaDavok, MySim, this);
			AddOwnMessage(Mc.NaplnStriekacky);
			AddOwnMessage(Mc.NoticeZaciatokNaplnania);
			AddOwnMessage(Mc.NoticeKoniecNaplnania);

			DlzkaRadu = new WStat(MySim);
			DlzkaCakania = new Stat();
		}
		//meta! tag="end"
	}
}