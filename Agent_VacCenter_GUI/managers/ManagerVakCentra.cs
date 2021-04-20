using OSPABA;
using simulation;
using agents;
using continualAssistants;
using Vac_Center_Agent_Test.simulation;

namespace managers
{
    //meta! id="3"
    public class ManagerVakCentra : Manager
    {
        public ManagerVakCentra(int id, Simulation mySim, Agent myAgent) :
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

        //meta! sender="AgentOckovania", id="24", type="Notice"
        public void ProcessNoticeKoniecOckovania(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentCakarne;
            message.Code = Mc.PacientCakaj;
            
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostCakaren, message as Sprava);

            Request(spravaPresunu);
        }

        //meta! sender="AgentRegistracie", id="20", type="Notice"
        public void ProcessNoticeKoniecRegistracie(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentVysetrenia;
            message.Code = Mc.VysetriPacienta;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostVysetrenie, message as Sprava);
            
            Request(spravaPresunu);
        }

        //meta! sender="AgentModelu", id="17", type="Notice"
        public void ProcessNoticePrichodPacienta(MessageForm message)
        {

            message.Addressee = ((VacCenterSimulation)MySim).AgentRegistracie;
            message.Code = Mc.ZaregistrujPacienta;

            //var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostRegistracia, message as Sprava);

            Request(message);
        }

        public SpravaPresunu NaplanujPresun(int entitaPresunu, int lokaciaPresunu, Sprava povodnaSprava)
        {
            var spravaPresunu = new SpravaPresunu(MySim) { PovodnaSprava = povodnaSprava};
            spravaPresunu.Addressee = ((VacCenterSimulation)MySim).AgentPresunu;
            spravaPresunu.EntitaPresunu = entitaPresunu;
            spravaPresunu.CielovaLokacia = lokaciaPresunu;
            spravaPresunu.Code = Mc.VykonajPresun;
            return spravaPresunu;
        }

        //meta! sender="AgentVysetrenia", id="22", type="Notice"
        public void ProcessNoticeKoniecVysetrenia(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentOckovania;
            message.Code = Mc.ZaockujPacienta;

            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostOckovanie, message as Sprava);

            Request(spravaPresunu);
        }

        //meta! sender="AgentCakarne", id="52", type="Notice"
        public void ProcessNoticeKoniecCakania(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentModelu;
            message.Code = Mc.NoticeOdchodPacienta;
            Notice(message);
        }

        public void ProcessNoticeKoniecPresunu(MessageForm message)
        {
            var povodnaSprava = (message as SpravaPresunu).PovodnaSprava;
            //if (povodnaSprava.Code == Mc.PacientCakaj)
            Request(povodnaSprava);
/*            else
                Notice(povodnaSprava);*/
        }
        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
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
                case Mc.VysetriPacienta:
                    ProcessNoticeKoniecVysetrenia(message);
                    break;
                case Mc.ZaockujPacienta:
                    ProcessNoticeKoniecOckovania(message);
                    break;
                case Mc.ZaregistrujPacienta:
                    ProcessNoticeKoniecRegistracie(message);
                    break;
                case Mc.VykonajPresun:
                    ProcessNoticeKoniecPresunu(message);
                    break;
                case Mc.PacientCakaj:
                    ProcessNoticeKoniecCakania(message);
                    break;
                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentVakCentra MyAgent
        {
            get
            {
                return (AgentVakCentra)base.MyAgent;
            }
        }
    }
}
