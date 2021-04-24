using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="43"
    public class ProcessOckovania : Process
    {
        private OSPRNG.TriangularRNG _generatorTrvania;
        public ProcessOckovania(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania = new OSPRNG.TriangularRNG(20, 75, 100, (MySim as VacCenterSimulation).GeneratorNasad);
        }

        //meta! sender="AgentOckovania", id="45", type="Notice"
        public void ProcessNoticeZaciatokOckovania(MessageForm message)
        {
            var trvanie = _generatorTrvania.Sample();
            var sprava = message as Sprava;
            sprava.Pacient.Stav = $"Ockovany pracovnikom: {sprava.Pracovnik.IDPracovnika} ({string.Format("{0:0.##}", trvanie)}s)";
            sprava.Pracovnik.Stav = $"Obsluhuje pacienta: {sprava.Pacient.IDPacienta} ({string.Format("{0:0.##}", trvanie)}s)";
            message.Code = Mc.NoticeKoniecOckovania;
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
                    ProcessNoticeZaciatokOckovania(message);
                    break;
                case Mc.NoticeKoniecOckovania:
                    message.Addressee = MyAgent;
                    AssistantFinished(message);
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
