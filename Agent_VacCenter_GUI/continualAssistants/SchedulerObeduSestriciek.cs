using OSPABA;
using simulation;
using agents;
using Agent_VacCenter_GUI.model;

namespace continualAssistants
{
	//meta! id="136"
	public class SchedulerObeduSestriciek : BaseSchedulerObedov
	{
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
