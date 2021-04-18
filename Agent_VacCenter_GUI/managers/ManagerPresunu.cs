using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
    //meta! id="60"
    public class ManagerPresunu : Manager
    {
        public ManagerPresunu(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
        }

        public void ProcessNoticeZaciatokPresunu(MessageForm message)
        {
            message.Addressee = MyAgent.ProcessPresunu;
            Notice(message);
        }

        public void ProcessNoticeKoniecPresunu(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
            Notice(message);
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        public void Init()
        {
        }

        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NoticeZaciatokPresunu:
                    ProcessNoticeZaciatokPresunu(message);
                    break;

                case Mc.NoticeKoniecPresunu:
                    ProcessNoticeKoniecPresunu(message);
                    break;
                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentPresunu MyAgent
        {
            get
            {
                return (AgentPresunu)base.MyAgent;
            }
        }
    }
}