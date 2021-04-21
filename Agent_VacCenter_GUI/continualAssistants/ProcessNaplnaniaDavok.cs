using OSPABA;
using simulation;
using agents;
using entities;

namespace continualAssistants
{
    //meta! id="90"
    public class ProcessNaplnaniaDavok : Process
    {
        private OSPRNG.TriangularRNG _generatorTrvania = new OSPRNG.TriangularRNG(6, 10, 40);
        public ProcessNaplnaniaDavok(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            _generatorTrvania.Seed();
        }

        //meta! sender="AgentPripravyDavok", id="92", type="Notice"
        public void ProcessNoticeZaciatokNaplnania(MessageForm message)
        {
            message.Code = Mc.NoticeKoniecNaplnania;
            Hold(_generatorTrvania.Sample(), message);
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