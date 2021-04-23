using OSPABA;
using simulation;
using agents;
using continualAssistants;
using entities;

namespace managers
{
    //meta! id="2"
    public class ManagerOkolia : Manager
    {
        public ManagerOkolia(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
        }

        //meta! userInfo="Removed from model"
        public void ProcessNotice(MessageForm message)
        {
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! sender="AgentModelu", id="16", type="Notice"
        public void ProcessNoticeOdchodPacienta(MessageForm message)
        {
            var pacient = ((Sprava)message).Pacient;
            ++MyAgent.PocetPacientovOdidenych;
            MyAgent.CelkovaDobaCakaniaPacientov.AddSample(pacient.CelkovaDobaCakania);
        }

        //meta! sender="SchedulerPrichodov", id="29", type="Notice"
        public void ProcessNoticePrichodPacienta(MessageForm message)
        {
            ++MyAgent.PocetPacientovVojdenych;
            //message.Addressee = MySim.FindAgent(SimId.AgentModelu);
            message.Addressee = ((VacCenterSimulation)MySim).AgentModelu;
            ((Sprava)message).Pacient = new Pacient(MySim);

            Notice(message);

            var novaInicializacnaSprava = new Sprava(MySim) { Addressee = MyAgent.SchedulerPrichodov, Code = Mc.NoticeNaplanujPrichod };
            Notice(novaInicializacnaSprava);
        }

        //meta! sender="AgentModelu", id="14", type="Notice"
        public void ProcessNoticeInicializuj(MessageForm message)
        {
            message.Code = Mc.NoticeNaplanujPrichod;
            message.Addressee = MyAgent.SchedulerPrichodov;
            Notice(message);
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        public void Init()
        {
        }

        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NoticePrichodPacienta:
                    ProcessNoticePrichodPacienta(message);
                    break;

                case Mc.NoticeOdchodPacienta:
                    ProcessNoticeOdchodPacienta(message);
                    break;

                case Mc.NoticeInicializuj:
                    ProcessNoticeInicializuj(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentOkolia MyAgent
        {
            get
            {
                return (AgentOkolia)base.MyAgent;
            }
        }
    }
}