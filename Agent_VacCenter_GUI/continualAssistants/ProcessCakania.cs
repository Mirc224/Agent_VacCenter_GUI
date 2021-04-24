using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="54"
    public class ProcessCakania : Process
    {
        private OSPRNG.UniformContinuousRNG _generatorTrvania = new OSPRNG.UniformContinuousRNG(0, 1);
        public ProcessCakania(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania.Seed();
        }

        //meta! sender="AgentCakarne", id="56", type="Notice"
        public void ProcessNoticeZaciatokCakania(MessageForm message)
        {
            double trvanie = 0;
            message.Code = Mc.NoticeKoniecCakania;
            if (_generatorTrvania.Sample() < 0.95)
                trvanie = 15 * 60;
            else
                trvanie = 30 * 60;

            var sprava = (message as Sprava);
            sprava.Pacient.Stav = $"Èaká v èakárni ({string.Format("{0:0.##}", trvanie/60)}min)";
            sprava.Pacient.DobaCakaniaVCakarni = trvanie;
            Hold(trvanie, message);
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
                case Mc.Start:
                    ProcessNoticeZaciatokCakania(message);
                    break;

                case Mc.NoticeKoniecCakania:
                    message.Addressee = MyAgent;
                    AssistantFinished(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentCakarne MyAgent
        {
            get
            {
                return (AgentCakarne)base.MyAgent;
            }
        }
    }
}
