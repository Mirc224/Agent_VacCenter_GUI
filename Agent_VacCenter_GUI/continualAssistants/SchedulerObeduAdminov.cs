using OSPABA;
using simulation;
using agents;
using Agent_VacCenter_GUI.model;

namespace continualAssistants
{
	//meta! id="126"
	public class SchedulerObeduAdminov : BaseSchedulerObedov
	{
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
