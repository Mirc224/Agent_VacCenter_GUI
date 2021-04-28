using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;
using Agent_VacCenter_GUI.model;
using entities;

namespace managers
{
    //meta! id="6"
    public class ManagerOckovania : BaseManagerPracoviska
    {
        /**
         * Koordinuje pacienta v ockovacej miestnosti. Ak je volny pracovnik, zasle pacienta na obsluhu. V pripade ak volny nie je, zaradeny do cakacieho frontu,
         * odkial su pacienti postupne vyberani. Po spracovani kazdeho pacienta kontroluje ci je pocet striekaciek u sestricky vacsi ako 0 a v pripade ak nie,
         * posiela ju agentovi pripravy davok, kde si striekacky naplni.
         */
        public ManagerOckovania(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
            Front = new Queue<Sprava>();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication

            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
            Front.Clear();
        }

        //meta! sender="ProcessOckovania", id="46", type="Notice"
        public void ProcessNoticeKoniecOckovania(MessageForm message)
        {
            var sestricka = ((Sprava)message).Pracovnik as Sestricka;
            (message as Sprava).Pracovnik = null;
            message.Code = Mc.ZaockujPacienta;
            Response(message);

            --sestricka.PocetNaplnenych;
            if(sestricka.PocetNaplnenych > 0)
            {
                DokonceniePracePracovnikom(sestricka);
            }
            else
            {
                var sprava = new Sprava(MySim);
                sprava.Pracovnik = sestricka;
                sprava.Code = Mc.NaplnStriekacky;
                sprava.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
                Request(sprava);
            }
            
        }

        public void ProcessNaplnStriekacky(MessageForm message)
        {
            DokonceniePracePracovnikom((message as Sprava).Pracovnik);
        }

       
        //meta! sender="AgentVakCentra", id="23", type="Notice"
        public void ProcessNoticeZaciatokOckovania(MessageForm message)
        {
            var sprava = message as Sprava;
            message.Addressee = MyAgent.ProcessOckovania;
            message.Code = Mc.NoticeZaciatokOckovania;
            sprava.ZaciatokObsluhy = MySim.CurrentTime;
            if (!MyAgent.ObsluhaVolna)
            {
                sprava.Pacient.Stav = "Èaká na oèkovanie";
                Front.Enqueue(sprava);
                MyAgent.DlzkaRadu.AddSample(Front.Count);
            }
            else
            {
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                //sprava.Pacient.CelkovaDobaCakania += dobaCakania;
                sprava.Pacient.DobaCakaniaNaOckovanie = dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);

                NaplanujObsluhu(message);

                StartContinualAssistant(message);
            }
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
                case Mc.ZaockujPacienta:
                    ProcessNoticeZaciatokOckovania(message);
                    break;

                case Mc.Finish:
                    ProcessNoticeKoniecOckovania(message);
                    break;
                case Mc.NaplnStriekacky:
                    ProcessNaplnStriekacky(message);
                    break;
                case Mc.NoticeCasObeda:
                    MyAgent.JeCasObeda = true;
                    NaplanujMozneObedy();
                    //System.Console.WriteLine(((VacCenterSimulation)MySim).NaformovatovanyCas);
                    break;
                case Mc.VykonajObed:
                    NavratPracovnikaZObedu((message as Sprava).Pracovnik);
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
