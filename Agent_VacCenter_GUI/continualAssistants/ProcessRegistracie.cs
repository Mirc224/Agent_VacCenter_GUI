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
            var sprava = message as Sprava;
            var trvanie = _generatorTrvania.Sample();
            sprava.Pacient.Stav = $"Registrovany pracovnikom: {sprava.Pracovnik.IDPracovnika} ({string.Format("{0:0.##}", trvanie)}s)";
            sprava.Pracovnik.Stav = $"Obsluhuje pacienta: {sprava.Pacient.IDPacienta} ({string.Format("{0:0.##}", trvanie)}s)";
            message.Code = Mc.NoticeKoniecRegistracie;
            
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
                    ProcessNoticeZaciatokRegistracie(message);
                    break;

                case Mc.NoticeKoniecRegistracie:
                    message.Addressee = MyAgent;
                    AssistantFinished(message);
                    //Notice(message);
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
