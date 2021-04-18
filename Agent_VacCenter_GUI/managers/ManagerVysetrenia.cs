using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;

namespace managers
{
    //meta! id="5"
    public class ManagerVysetrenia : Manager
    {
        public Queue<Sprava> Front { get; private set; }
        public ManagerVysetrenia(int id, Simulation mySim, Agent myAgent) :
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
            Front = new Queue<Sprava>();
        }

        //meta! sender="AgentVakCentra", id="21", type="Notice"
        public void ProcessNoticeZaciatokVysetrenia(MessageForm message)
        {
            var sprava = message as Sprava;
            message.Addressee = MyAgent.ProcessVysetrenia;
            sprava.ZaciatokObsluhy = MySim.CurrentTime;
            if (!MyAgent.ObsluhaVolna)
            {
                Front.Enqueue(sprava);
                MyAgent.DlzkaRadu.AddSample(Front.Count);
            }
            else
            {
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                sprava.Pacient.DobaCakaniaNaVysetrenie = dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);

                NaplanujObsluhu(message);

                Notice(message);
            }
        }

        private void NaplanujObsluhu(MessageForm message)
        {
            var pracovnik = MyAgent.DajVolnehoPracovnika();
            --MyAgent.PocetVolnychPracovnikov;
            pracovnik.Utilization.AddSample(1);
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.MaxPocetPracovnikov - MyAgent.PocetVolnychPracovnikov);
            pracovnik.ZaciatokObsluhovania = MySim.CurrentTime;
            pracovnik.Obsadeny = true;
            ((Sprava)message).Pracovnik = pracovnik;
        }

        //meta! sender="ProcessVysetrenia", id="41", type="Notice"
        public void ProcessNoticeKoniecVysetrenia(MessageForm message)
        {
            message.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
            NavratPracovnika(message);
            Notice(message);

            if (Front.Count > 0)
            {
                var sprava = Front.Dequeue();
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                sprava.Pacient.DobaCakaniaNaVysetrenie = dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);

                sprava.Addressee = MyAgent.ProcessVysetrenia;
                MyAgent.DlzkaRadu.AddSample(Front.Count);
                NaplanujObsluhu(sprava);
                Notice(sprava);
            }
        }

        private void NavratPracovnika(MessageForm message)
        {
            var sprava = ((Sprava)message);
            sprava.Pracovnik.Obsadeny = false;
            double trvanieObsluhy = MySim.CurrentTime - sprava.Pracovnik.ZaciatokObsluhovania;
            sprava.Pracovnik.Utilization.AddSample(0);
            MyAgent.VytazeniePracovnikov.AddSample(trvanieObsluhy);
            ++MyAgent.PocetVolnychPracovnikov;
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.MaxPocetPracovnikov - MyAgent.PocetVolnychPracovnikov);
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
                case Mc.NoticeZaciatokVysetrenia:
                    ProcessNoticeZaciatokVysetrenia(message);
                    break;

                case Mc.NoticeKoniecVysetrenia:
                    ProcessNoticeKoniecVysetrenia(message);
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
