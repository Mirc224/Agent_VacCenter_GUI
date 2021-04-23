using OSPABA;
using simulation;
using agents;
using Agent_VacCenter_GUI.model;

namespace continualAssistants
{
	//meta! id="132"
	public class SchedulerObeduDoktorov : BaseSchedulerObedov
	{
		public SchedulerObeduDoktorov(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			Hodina = 11;
			Minuta = 45;
		}

		public new AgentVysetrenia MyAgent
		{
			get
			{
				return (AgentVysetrenia)base.MyAgent;
			}
		}
	}
}
