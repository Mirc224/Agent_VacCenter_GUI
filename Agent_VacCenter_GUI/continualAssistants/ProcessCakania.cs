using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="54"
    public class ProcessCakania : Process
    {
        /**
         * Reprezentuje cakanie v cakarni. Obsahuje generator trvania. Ten generuje cislo od 0 po 1 v zavislosti od coho je sprava pozdrzana o 15 alebo 30 minut 
         * simulacneho casu.
         */
        private OSPRNG.UniformContinuousRNG _generatorTrvania;
        public ProcessCakania(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania = new OSPRNG.UniformContinuousRNG(0, 1, (MySim as VacCenterSimulation).GeneratorNasad);
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
            sprava.Pacient.Stav = $"?ak? v ?ak?rni ({string.Format("{0:0.##}", trvanie/60)}min)";
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
