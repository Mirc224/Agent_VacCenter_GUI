using entities;
using OSPABA;
using simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_VacCenter_GUI.model
{
    public abstract class BaseManagerPracoviska : OSPABA.Manager
    {
        public Queue<Sprava> Front { get; protected set; }
        public BaseManagerPracoviska(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
        }
        protected void AkCakaSpracujDalsieho()
        {
            if (Front.Count > 0)
            {
                var sprava = Front.Dequeue();
                double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
                sprava.Pacient.CelkovaDobaCakania += dobaCakania;
                MyAgent.DlzkaCakania.AddSample(dobaCakania);

                sprava.Addressee = MyAgent.ProcessObsluhy;
                MyAgent.DlzkaRadu.AddSample(Front.Count);
                NaplanujObsluhu(sprava);
                StartContinualAssistant(sprava);
            }
        }
        protected void NaplanujObsluhu(MessageForm message)
        {
            var pracovnik = MyAgent.DajVolnehoPracovnika();
            --MyAgent.PocetVolnychPracovnikov;
            pracovnik.Utilization.AddSample(1);
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.MaxPocetPracovnikov - MyAgent.PocetVolnychPracovnikov);
            pracovnik.ZaciatokObsluhovania = MySim.CurrentTime;
            pracovnik.Obsadeny = true;
            ((Sprava)message).Pracovnik = pracovnik;
        }

        protected void NavratPracovnika(Pracovnik pracovnik)
        {
            pracovnik.Obsadeny = false;
            double trvanieObsluhy = MySim.CurrentTime - pracovnik.ZaciatokObsluhovania;
            pracovnik.Utilization.AddSample(0);
            MyAgent.VytazeniePracovnikov.AddSample(trvanieObsluhy);
            ++MyAgent.PocetVolnychPracovnikov;
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.MaxPocetPracovnikov - MyAgent.PocetVolnychPracovnikov);
        }

        public new BaseAgentPracoviska MyAgent
        {
            get
            {
                return (BaseAgentPracoviska)base.MyAgent;
            }
        }
    }
}
