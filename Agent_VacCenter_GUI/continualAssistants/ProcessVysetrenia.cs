using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="38"
    public class ProcessVysetrenia : Process
    {
        /**
         * Reprezentuje proces vysetrenia pacienta. Po jeho prichode je vygenerovny cas trvania, na ktory je sprava pozdrzana a opatovne zaslana.
         */
        private OSPRNG.ExponentialRNG _generatorTrvania;
        public ProcessVysetrenia(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
             _generatorTrvania = new OSPRNG.ExponentialRNG(260, (MySim as VacCenterSimulation).GeneratorNasad);
        }

        //meta! sender="AgentVysetrenia", id="40", type="Notice"
        public void ProcessNoticeZaciatokVysetrenia(MessageForm message)
        {
            var sprava = message as Sprava;
            var trvanie = _generatorTrvania.Sample();
            sprava.Pacient.Stav = $"Vysetrovany pracovnikom: {sprava.Pracovnik.IDPracovnika} ({string.Format("{0:0.##}", trvanie)}s)";
            sprava.Pracovnik.Stav = $"Obsluhuje pacienta: {sprava.Pacient.IDPacienta} ({string.Format("{0:0.##}", trvanie)}s)";
            message.Code = Mc.NoticeKoniecVysetrenia;
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
                    ProcessNoticeZaciatokVysetrenia(message);
                    break;
                case Mc.NoticeKoniecVysetrenia:
                    message.Addressee = MyAgent;
                    AssistantFinished(message);
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
