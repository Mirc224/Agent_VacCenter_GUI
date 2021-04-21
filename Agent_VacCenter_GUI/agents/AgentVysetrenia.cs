using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;
using entities;
using System.Collections.Generic;
using Agent_VacCenter_GUI.model;

namespace agents
{
	//meta! id="5"
	public class AgentVysetrenia : BaseAgentPracoviska
	{
		public ProcessVysetrenia ProcessVysetrenia { get; private set; }
		public AgentVysetrenia(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
			MaxPocetPracovnikov = 11;
			InicializaciaPredSimulaciou(Lokacie.MiestnostVysetrenie);
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			InicializaciaPredReplikaciou();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerVysetrenia(SimId.ManagerVysetrenia, MySim, this);
			ProcessVysetrenia = new ProcessVysetrenia(SimId.ProcessVysetrenia, MySim, this);
			ProcessObsluhy = ProcessVysetrenia;
			AddOwnMessage(Mc.VysetriPacienta);
			AddOwnMessage(Mc.NoticeZaciatokVysetrenia);
			AddOwnMessage(Mc.NoticeKoniecVysetrenia);

			DlzkaCakania = new Stat();
			DlzkaRadu = new WStat(MySim);
			VytazeniePracovnikov = new WStat(MySim);
		}
		//meta! tag="end"
	}
}
