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
                //AkCakaSpracujDalsieho();
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
            //AkCakaSpracujDalsieho();
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
                Front.Enqueue(sprava);
                MyAgent.DlzkaRadu.AddSample(Front.Count);
            }
            else
            {
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                sprava.Pacient.CelkovaDobaCakania += dobaCakania;
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
