using OSPABA;
using simulation;
using agents;
using Vac_Center_Agent_Test.simulation;

namespace continualAssistants
{
    //meta! id="67"
    public class ProcessPresunu : Process
    {
        /**
         * Prcoes predstavuje presun entit v modeli. Obsahuje generator trvania prechodu pre kazdu trasu, ktorou sa entity mozu pohybovat. Po prichode spravy
         * sa na zaklade cielovej lokacie vyberie spravny generator a sprava sa pozdrzi na vygenerovany cas.
         */
        private OSPRNG.UniformContinuousRNG _generatorTrvaniaPrechoduVysetrenie = new OSPRNG.UniformContinuousRNG(40, 90);
        private OSPRNG.UniformContinuousRNG _generatorTrvaniaPrechoduOckovanie = new OSPRNG.UniformContinuousRNG(20, 45);
        private OSPRNG.UniformContinuousRNG _generatorTrvaniaPrechoduCakaren = new OSPRNG.UniformContinuousRNG(45, 110);
        private OSPRNG.UniformContinuousRNG _generatorTrvaniaPrechoduJedalen = new OSPRNG.UniformContinuousRNG(70, 200);
        private OSPRNG.UniformContinuousRNG _generatorTrvaniaPrechoduPrirpavna = new OSPRNG.UniformContinuousRNG(10, 18);
        public ProcessPresunu(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvaniaPrechoduVysetrenie = new OSPRNG.UniformContinuousRNG(40, 90, (MySim as VacCenterSimulation).GeneratorNasad);
            _generatorTrvaniaPrechoduOckovanie = new OSPRNG.UniformContinuousRNG(20, 45, (MySim as VacCenterSimulation).GeneratorNasad);
            _generatorTrvaniaPrechoduCakaren = new OSPRNG.UniformContinuousRNG(45, 110, (MySim as VacCenterSimulation).GeneratorNasad);
            _generatorTrvaniaPrechoduJedalen = new OSPRNG.UniformContinuousRNG(70, 200, (MySim as VacCenterSimulation).GeneratorNasad);
            _generatorTrvaniaPrechoduPrirpavna = new OSPRNG.UniformContinuousRNG(10, 18, (MySim as VacCenterSimulation).GeneratorNasad);
        }

        //meta! sender="AgentPresunu", id="69", type="Notice"
        public void ProcessNoticeKoniecPresunu(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
            AssistantFinished(message);
        }
        public void ProcessNoticeZaciatokPresunu(MessageForm message)
        {
            var sprava = message as SpravaPresunu;
            double trvaniePrechodu = 0;
            switch (sprava.CielovaLokacia)
            {
                case Lokacie.MiestnostVysetrenie:
                    trvaniePrechodu = _generatorTrvaniaPrechoduVysetrenie.Sample();
                    break;
                case Lokacie.MiestnostOckovanie:
                    trvaniePrechodu = _generatorTrvaniaPrechoduOckovanie.Sample();
                    break;
                case Lokacie.MiestnostCakaren:
                    trvaniePrechodu = _generatorTrvaniaPrechoduCakaren.Sample();
                    break;
                case Lokacie.MiestnostJedalen:
                    trvaniePrechodu = _generatorTrvaniaPrechoduJedalen.Sample();
                    break;
                case Lokacie.MiestnostPriravyDavky:
                    trvaniePrechodu = _generatorTrvaniaPrechoduPrirpavna.Sample();
                    break;
                default:
                    break;
            }
            sprava.Code = Mc.NoticeKoniecPresunu;
            if (sprava.EntitaPresunu == EntitySimulacie.Pracovnik)
                sprava.PovodnaSprava.Pracovnik.Stav += $" ({string.Format("{0:0.##}", trvaniePrechodu)}s)";
            else
                sprava.PovodnaSprava.Pacient.Stav += $" ({string.Format("{0:0.##}", trvaniePrechodu)}s)";
            Hold(trvaniePrechodu, sprava);
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
