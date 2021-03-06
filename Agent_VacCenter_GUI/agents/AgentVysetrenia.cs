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
		/**
		 * Symbolizuje vyetrenie v ramci modelu vakcinacneho centra. Potomok triedy base agent pracoviska, ktory na viac obsahuje proces vysetrenia. Tomuto prcoesu
		 * agent zasle spravu v momente, ked je volny niektory z pracovnikov pracoviska. Ak ziaden nie je volny, je sprava zaradena do frontu.
		 */
		public ProcessVysetrenia ProcessVysetrenia { get; private set; }
		public AgentVysetrenia(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
			PocetPracovnikov = 6;
			LokaciaPracoviska = Lokacie.MiestnostVysetrenie;
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
			SchedulerObedov = new SchedulerObeduDoktorov(SimId.SchedulerObeduDoktorov, MySim, this);
			ProcessObsluhy = ProcessVysetrenia;
			AddOwnMessage(Mc.VysetriPacienta);
			AddOwnMessage(Mc.NoticeZaciatokVysetrenia);
			AddOwnMessage(Mc.NoticeKoniecVysetrenia);
			AddOwnMessage(Mc.NoticeCasObeda);
			AddOwnMessage(Mc.VykonajObed);

			DlzkaCakania = new Stat();
			DlzkaRadu = new WStat(MySim);
			VytazeniePracovnikov = new WStat(MySim);
		}
		//meta! tag="end"
	}
}
