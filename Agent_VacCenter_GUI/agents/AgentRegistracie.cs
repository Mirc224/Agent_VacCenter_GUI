using OSPABA;
using simulation;
using managers;
using continualAssistants;
using entities;
using System.Collections.Generic;
using OSPStat;
using Agent_VacCenter_GUI.model;

namespace agents
{
	//meta! id="4"
	public class AgentRegistracie : BaseAgentPracoviska
	{

		public ProcessRegistracie ProcessRegistracie { get; private set; }
		public AgentRegistracie(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
			PocetPracovnikov = 5;
			LokaciaPracoviska = Lokacie.MiestnostRegistracia;
			//InicializaciaPredSimulaciou();
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
			new ManagerRegistracie(SimId.ManagerRegistracie, MySim, this);
			ProcessRegistracie =  new ProcessRegistracie(SimId.ProcessRegistracie, MySim, this);
			SchedulerObedov = new SchedulerObeduAdminov(SimId.SchedulerObeduAdminov, MySim, this);

			ProcessObsluhy = ProcessRegistracie;
			AddOwnMessage(Mc.NoticeKoniecRegistracie);
			AddOwnMessage(Mc.NoticeZaciatokRegistracie);
			AddOwnMessage(Mc.ZaregistrujPacienta);
			AddOwnMessage(Mc.NoticeCasObeda);
			AddOwnMessage(Mc.VykonajObed);

			DlzkaCakania = new Stat();
			DlzkaRadu = new WStat(MySim);
			VytazeniePracovnikov = new WStat(MySim);
		}
		//meta! tag="end"
	}
}
