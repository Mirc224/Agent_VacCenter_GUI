using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;
using entities;
using Agent_VacCenter_GUI.model;

namespace managers
{
    //meta! id="4"
    public class ManagerRegistracie : BaseManagerPracoviska
    {
        /**
         * Koordinuje pacienta v miestnosti registracie. Po prichode pacienta skontroluje ci je volny pracovnik a ak ano, posiela spravu procesu registracie. Ak nie
         * je sprava zaradena do frontu sprav, kde caka na spracovanie.
         */
        public ManagerRegistracie(int id, Simulation mySim, Agent myAgent) :
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

        //meta! sender="ProcessRegistracie", id="35", type="Notice"
        public void ProcessNoticeKoniecRegistracie(MessageForm message)
        {
            DokonceniePracePracovnikom(((Sprava)message).Pracovnik);
            (message as Sprava).Pracovnik = null;
            message.Code = Mc.ZaregistrujPacienta;
            Response(message);


            //AkCakaSpracujDalsieho();
        }

        //meta! sender="AgentVakCentra", id="19", type="Notice"
        public void ProcessNoticeZaciatokRegistracie(MessageForm message)
        {
            var sprava = message as Sprava;
            message.Code = Mc.NoticeZaciatokRegistracie;
            message.Addressee = MyAgent.ProcessRegistracie;
            sprava.ZaciatokObsluhy = MySim.CurrentTime;
            if (!MyAgent.ObsluhaVolna)
            {
                sprava.Pacient.Stav = "Èaká na registráciu";
                Front.Enqueue(sprava);
                MyAgent.DlzkaRadu.AddSample(Front.Count);
            }
            else
            {
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                
                //sprava.Pacient.CelkovaDobaCakania += dobaCakania;
                sprava.Pacient.DobaCakaniaNaRegistraciu = dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);
                NaplanujObsluhu(message);
                StartContinualAssistant(message);
                //Notice(message);
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
                case Mc.ZaregistrujPacienta:
                    ProcessNoticeZaciatokRegistracie(message);
                    break;

                case Mc.Finish:
                    ProcessNoticeKoniecRegistracie(message);
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
        public new AgentRegistracie MyAgent
        {
            get
            {
                return (AgentRegistracie)base.MyAgent;
            }
        }
    }
}
