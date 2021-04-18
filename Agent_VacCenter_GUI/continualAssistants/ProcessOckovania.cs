using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="43"
    public class ProcessOckovania : Process
    {
        private OSPRNG.TriangularRNG _generatorTrvania = new OSPRNG.TriangularRNG(20, 75, 100);
        public ProcessOckovania(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania.Seed();
        }

        //meta! sender="AgentOckovania", id="45", type="Notice"
        public void ProcessNoticeZaciatokOckovania(MessageForm message)
        {
            message.Code = Mc.NoticeKoniecOckovania;
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
                case Mc.NoticeZaciatokOckovania:
                    ProcessNoticeZaciatokOckovania(message);
                    break;
                case Mc.NoticeKoniecOckovania:
                    message.Addressee = MyAgent;
                    Notice(message);
                    break;
                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentOckovania MyAgent
        {
            get
            {
                return (AgentOckovania)base.MyAgent;
            }
        }
    }
}
