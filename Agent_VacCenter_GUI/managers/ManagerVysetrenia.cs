using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;
using Agent_VacCenter_GUI.model;

namespace managers
{
    //meta! id="5"
    public class ManagerVysetrenia : BaseManagerPracoviska
    {
        public ManagerVysetrenia(int id, Simulation mySim, Agent myAgent) :
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

        //meta! sender="AgentVakCentra", id="21", type="Notice"
        public void ProcessNoticeZaciatokVysetrenia(MessageForm message)
        {
            var sprava = message as Sprava;
            message.Addressee = MyAgent.ProcessVysetrenia;
            message.Code = Mc.NoticeZaciatokVysetrenia;
            sprava.ZaciatokObsluhy = MySim.CurrentTime;
            if (!MyAgent.ObsluhaVolna)
            {
                Front.Enqueue(sprava);
                MyAgent.DlzkaRadu.AddSample(Front.Count);
                sprava.Pacient.Stav = "Èaká na vyšetrenie";
            }
            else
            {
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                //sprava.Pacient.CelkovaDobaCakania += dobaCakania;
                sprava.Pacient.DobaCakaniaNaVysetrenie = dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);

                NaplanujObsluhu(message);

                StartContinualAssistant(message);
            }
        }

        //meta! sender="ProcessVysetrenia", id="41", type="Notice"
        public void ProcessNoticeKoniecVysetrenia(MessageForm message)
        {
            DokonceniePracePracovnikom(((Sprava)message).Pracovnik);
            (message as Sprava).Pracovnik = null;
            message.Code = Mc.VysetriPacienta;
            Response(message);

            //AkCakaSpracujDalsieho();
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
                case Mc.VysetriPacienta:
                    ProcessNoticeZaciatokVysetrenia(message);
                    break;

                case Mc.Finish:
                    ProcessNoticeKoniecVysetrenia(message);
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
        public new AgentVysetrenia MyAgent
        {
            get
            {
                return (AgentVysetrenia)base.MyAgent;
            }
        }
    }
}
