using OSPABA;
using simulation;
using agents;
using entities;

namespace continualAssistants
{
    //meta! id="90"
    public class ProcessNaplnaniaDavok : Process
    {
        /**
         * Reprezentuje prcoes naplnania davok sestrickami. Ak je volne miesto na prirpavu vakcinacnych davok, je pre sestricku postupne vygenerovanych tolko 
         * casov trvania, kolko je jej maximalny pocet striekaciek. Generator ma trojuholnikove rozdelenie pravdepodobnosti s hodnotami min=6, mod=10 a max = 40.
         */
        private OSPRNG.TriangularRNG _generatorTrvania;
        public ProcessNaplnaniaDavok(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania = new OSPRNG.TriangularRNG(6, 10, 40, (MySim as VacCenterSimulation).GeneratorNasad);
        }

        //meta! sender="AgentPripravyDavok", id="92", type="Notice"
        public void ProcessNoticeZaciatokNaplnania(MessageForm message)
        {
            var trvanie = _generatorTrvania.Sample();
            (message as Sprava).Pracovnik.Stav = $"Napåòa striekaèku è. {(((message as Sprava).Pracovnik)as Sestricka).PocetNaplnenych + 1} ({string.Format("{0:0.##}", trvanie)}s)";
            message.Code = Mc.NoticeKoniecNaplnania;
            Hold(trvanie, message);
        }

        public void ProcessNoticeKoniecNaplnania(MessageForm message)
        {
            var sprava = message as Sprava;
            var sestricka = sprava.Pracovnik as Sestricka;
            ++sestricka.PocetNaplnenych;
            if (sestricka.PocetNaplnenych == sestricka.MaxPocetStriekaciek)
            {
                sprava.Code = Mc.NaplnStriekacky;
                sprava.Addressee = MyAgent;
                AssistantFinished(sprava);
            }
            else
                ProcessNoticeZaciatokNaplnania(message);
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
                    ProcessNoticeZaciatokNaplnania(message);
                    break;

                case Mc.NoticeKoniecNaplnania:
                    ProcessNoticeKoniecNaplnania(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentPripravyDavok MyAgent
        {
            get
            {
                return (AgentPripravyDavok)base.MyAgent;
            }
        }
    }
}