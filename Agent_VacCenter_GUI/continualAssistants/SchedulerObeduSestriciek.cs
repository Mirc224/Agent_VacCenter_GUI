using OSPABA;
using simulation;
using agents;
using Agent_VacCenter_GUI.model;

namespace continualAssistants
{
	//meta! id="136"
	public class SchedulerObeduSestriciek : BaseSchedulerObedov
	{
		/**
         * Planovac obedov pre zdravotne sestry. V nastavenom case zasle spravu agentovi o tom, ze nastal cas obeda a pracovnici mozu zacat chodit na obed.
         */
		public SchedulerObeduSestriciek(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			Hodina = 13;
			Minuta = 30;
		}

		public new AgentOckovania MyAgent
		{
			get
			{
				return (AgentOckovania)base.MyAgent;
			}
		}
	}
}
