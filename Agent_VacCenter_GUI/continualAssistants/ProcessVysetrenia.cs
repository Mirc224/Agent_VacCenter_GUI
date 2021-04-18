using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="38"
    public class ProcessVysetrenia : Process
    {
        private OSPRNG.ExponentialRNG _generatorTrvania = new OSPRNG.ExponentialRNG(260);
        public ProcessVysetrenia(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania.Seed();
        }

        //meta! sender="AgentVysetrenia", id="40", type="Notice"
        public void ProcessNoticeZaciatokVysetrenia(MessageForm message)
        {
            message.Code = Mc.NoticeKoniecVysetrenia;
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
                case Mc.NoticeZaciatokVysetrenia:
                    ProcessNoticeZaciatokVysetrenia(message);
                    break;
                case Mc.NoticeKoniecVysetrenia:
                    message.Addressee = MyAgent;
                    Notice(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentVysetrenia MyAgent
        {
            get
            {
                return (AgentVysetrenia)base.MyAgent;
            }
        }
    }
}
