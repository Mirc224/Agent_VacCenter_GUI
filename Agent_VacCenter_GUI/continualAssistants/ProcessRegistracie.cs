using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="31"
    public class ProcessRegistracie : Process
    {
        private OSPRNG.UniformContinuousRNG _generatorTrvania = new OSPRNG.UniformContinuousRNG(140, 220);
        public ProcessRegistracie(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania.Seed();
        }

        //meta! sender="AgentRegistracie", id="34", type="Notice"
        public void ProcessNoticeZaciatokRegistracie(MessageForm message)
        {
            message.Code = Mc.NoticeKoniecRegistracie;
            Hold(_generatorTrvania.Sample(), message);
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NoticeZaciatokRegistracie:
                    ProcessNoticeZaciatokRegistracie(message);
                    break;

                case Mc.NoticeKoniecRegistracie:
                    message.Addressee = MyAgent;
                    Notice(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
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
