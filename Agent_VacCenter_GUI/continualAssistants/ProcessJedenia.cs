using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
    //meta! id="124"
    public class ProcessJedenia : Process
    {
        /**
         * Reprezentuje proces jedenia pacientov. Obsahuje v sebe generator trojuholnikoveho rozdelenia s parametrami min=5, mod=15, max=30. V zavislosti od 
         * vygenerovaneho cisla pozdrzi spravu na dany cas a po jeho uplynuti ju sam sebe posle.
         */
        private OSPRNG.TriangularRNG _generatorTrvania = new OSPRNG.TriangularRNG(5 * 60, 15 * 60, 30 * 60);
        public ProcessJedenia(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania = new OSPRNG.TriangularRNG(5 * 60, 15 * 60, 30 * 60, (MySim as VacCenterSimulation).GeneratorNasad);
        }

        //meta! sender="AgentJedalne", id="125", type="Start"
        public void ProcessStart(MessageForm message)
        {
            var trvanie = _generatorTrvania.Sample();
            (message as Sprava).Pracovnik.Stav = $"Obeduje ({string.Format("{0:0.##}", trvanie/60)}min)";
            message.Code = Mc.VykonajObed;
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
                    ProcessStart(message);
                    break;
                case Mc.VykonajObed:
                    message.Addressee = MyAgent;
                    AssistantFinished(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentJedalne MyAgent
        {
            get
            {
                return (AgentJedalne)base.MyAgent;
            }
        }
    }
}
