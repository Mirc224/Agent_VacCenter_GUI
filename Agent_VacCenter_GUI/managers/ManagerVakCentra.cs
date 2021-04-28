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
        /**
         * Stara sa o planovanie presunov entit a koordinuje ukony a poradie v ktorom ich prideny pacient musi vykonat.
         */
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

        //meta! sender="AgentModelu", id="17", type="Notice"
        public void ProcessPrichodPacienta(MessageForm message)
        {

            message.Addressee = ((VacCenterSimulation)MySim).AgentRegistracie;
            message.Code = Mc.ZaregistrujPacienta;

            Request(message);
        }

        //meta! sender="AgentRegistracie", id="20", type="Notice"
        public void ProcessKoniecRegistracie(MessageForm message)
        {
            (message as Sprava).Pacient.Stav = "Presun na vyšetrenie: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentVysetrenia;
            message.Code = Mc.VysetriPacienta;
            ((Sprava)message).TypSpravy = TypSpravy.REQUEST;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostVysetrenie, message as Sprava);

            Request(spravaPresunu);
        }

        //meta! sender="AgentOckovania", id="24", type="Notice"
        public void ProcessKoniecOckovania(MessageForm message)
        {
            (message as Sprava).Pacient.Stav = "Presun do èakárne: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentCakarne;
            message.Code = Mc.PacientCakaj;
            ((Sprava)message).TypSpravy = TypSpravy.REQUEST;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostCakaren, message as Sprava);

            Request(spravaPresunu);
        }
        //meta! sender="AgentVysetrenia", id="22", type="Notice"
        public void ProcessKoniecVysetrenia(MessageForm message)
        {
            (message as Sprava).Pacient.Stav = "Presun na oèkovanie: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentOckovania;
            message.Code = Mc.ZaockujPacienta;
            ((Sprava)message).TypSpravy = TypSpravy.REQUEST;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pacient, Lokacie.MiestnostOckovanie, message as Sprava);

            Request(spravaPresunu);
        }

        //meta! sender="AgentCakarne", id="52", type="Notice"
        public void ProcessKoniecCakania(MessageForm message)
        {
            (message as Sprava).Pacient.Stav = "Odišiel z vakcinaèného centra";
            message.Addressee = ((VacCenterSimulation)MySim).AgentModelu;
            message.Code = Mc.NoticeOdchodPacienta;
            Notice(message);
        }

        public void ProcessNaplnStriekacky(MessageForm message)
        {
            (message as Sprava).Pracovnik.Stav = "Presun do prípravovne dávok: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentPripravyDavok;
            message.Code = Mc.NaplnStriekacky;
            ((Sprava)message).TypSpravy = TypSpravy.REQUEST;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pracovnik, Lokacie.MiestnostPriravyDavky, message as Sprava);

            Request(spravaPresunu);
        }

        public void ProcessKoniecNaplnaniaStriekackiek(MessageForm message)
        {
            (message as Sprava).Pracovnik.Stav = "Presun do oèkovacej miestnosti: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentOckovania;
            message.Code = Mc.NaplnStriekacky;
            ((Sprava)message).TypSpravy = TypSpravy.RESPONSE;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pracovnik, Lokacie.MiestnostPriravyDavky, message as Sprava);
            Request(spravaPresunu);
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

        public void ProcessObedPracovnika(MessageForm message)
        {
            var sprava = message as Sprava;
            sprava.Pracovnik.Stav = "Presud do jedálne: ";
            message.Addressee = ((VacCenterSimulation)MySim).AgentJedalne;
            message.Code = Mc.VykonajObed;
            sprava.TypSpravy = TypSpravy.REQUEST;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pracovnik, Lokacie.MiestnostJedalen, message as Sprava);
            Request(spravaPresunu);
        }

        public void ProcessKoniecObeduPracovnika(MessageForm message)
        {
            //message.Addressee = ((VacCenterSimulation)MySim).AgentJedalne;
            var sprava = message as Sprava;
            sprava.Pracovnik.Stav = "Presun na pracovisko: ";
            message.Code = Mc.VykonajObed;
            ((Sprava)message).TypSpravy = TypSpravy.RESPONSE;
            var spravaPresunu = NaplanujPresun(EntitySimulacie.Pracovnik, Lokacie.MiestnostJedalen, message as Sprava);
            Request(spravaPresunu);
        }

        public void ProcessKoniecPresunu(MessageForm message)
        {
            var povodnaSprava = (message as SpravaPresunu).PovodnaSprava as Sprava;
            
            switch(povodnaSprava.TypSpravy)
            {
                case TypSpravy.RESPONSE:
                    Response(povodnaSprava);
                    break;
                case TypSpravy.REQUEST:
                    Request(povodnaSprava);
                    break;
                case TypSpravy.NOTICE:
                    Notice(povodnaSprava);
                    break;
            }
            
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
                    ProcessPrichodPacienta(message);
                    break;
                case Mc.VysetriPacienta:
                    ProcessKoniecVysetrenia(message);
                    break;
                case Mc.ZaockujPacienta:
                    ProcessKoniecOckovania(message);
                    break;
                case Mc.ZaregistrujPacienta:
                    ProcessKoniecRegistracie(message);
                    break;
                case Mc.VykonajPresun:
                    ProcessKoniecPresunu(message);
                    break;
                case Mc.PacientCakaj:
                    ProcessKoniecCakania(message);
                    break;
                case Mc.NaplnStriekacky:
                    switch(message.Sender.Id)
                    {
                        case SimId.AgentOckovania:
                            ProcessNaplnStriekacky(message);
                            break;
                        case SimId.AgentPripravyDavok:
                            ProcessKoniecNaplnaniaStriekackiek(message);
                            break;
                    }
                    break;
                case Mc.VykonajObed:
                    switch(message.Sender.Id)
                    {
                        case SimId.AgentJedalne:
                            ProcessKoniecObeduPracovnika(message);
                            break;

                        case SimId.AgentRegistracie:
                        case SimId.AgentVysetrenia:
                        case SimId.AgentOckovania:
                            ProcessObedPracovnika(message);
                            break;
                    }
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
