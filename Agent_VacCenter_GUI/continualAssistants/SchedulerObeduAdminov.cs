using OSPABA;
using simulation;
using agents;
using Agent_VacCenter_GUI.model;

namespace continualAssistants
{
	//meta! id="126"
	public class SchedulerObeduAdminov : BaseSchedulerObedov
	{
		/**
         * Planovac obedov pre administrativnych pracovnikov. V nastavenom case zasle spravu agentovi o tom, ze nastal cas obeda a pracovnici mozu zacat chodit na obed.
         */
		public SchedulerObeduAdminov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			Hodina = 11;
		}

		//meta! tag="end"
		public new AgentRegistracie MyAgent
		{
			get
			{
				return (AgentRegistracie)base.MyAgent;
			}
		}
	}
}
