using entities;
using OSPABA;
using simulation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_VacCenter_GUI.model
{
    public abstract class BaseManagerPracoviska : OSPABA.Manager
    {
        /**
         * Predstavuje predka manazera vsetkych pracovisk. Nachadzaju sa tu metody pre naplanovanie obsluhy pacientov a odchodov na obed.
         */
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
                switch(MyAgent.LokaciaPracoviska)
                {
                    case Lokacie.MiestnostRegistracia:
                        sprava.Pacient.DobaCakaniaNaRegistraciu = dobaCakania;
                        break;
                    case Lokacie.MiestnostVysetrenie:
                        sprava.Pacient.DobaCakaniaNaVysetrenie = dobaCakania;
                        break;
                    case Lokacie.MiestnostOckovanie:
                        sprava.Pacient.DobaCakaniaNaOckovanie = dobaCakania;
                        break;
                }
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
            ++MyAgent.PocetPracujucich;
            pracovnik.Utilization.AddSample(1);
            MyAgent.VytazeniePracovnikov.AddSample((double)MyAgent.PocetPracujucich/(MyAgent.PocetPracovnikov - MyAgent.PocetObedujucich));
            pracovnik.ZaciatokObsluhovania = MySim.CurrentTime;
            MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, false);
            ((Sprava)message).Pracovnik = pracovnik;
        }

        protected void DokonceniePracePracovnikom(Pracovnik pracovnik)
        {
            MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, true);
            pracovnik.Utilization.AddSample(0);
            --MyAgent.PocetPracujucich;
            pracovnik.Stav = "Nečinný";
            MyAgent.VytazeniePracovnikov.AddSample((double)MyAgent.PocetPracujucich / (MyAgent.PocetPracovnikov - MyAgent.PocetObedujucich));

            SkusPoslatNaObedAleboObsluzDalsieho(pracovnik);
            
        }

        protected void SkusPoslatNaObedAleboObsluzDalsieho(Pracovnik pracovnik)
        {
            if (!SkustPoslatPracovnikaNaObed(pracovnik))
                AkCakaSpracujDalsieho();
        }

        protected void NaplanujMozneObedy()
        {

            if(MyAgent.PocetUzNajedenychPracovnikov < MyAgent.PocetPracovnikov && MyAgent.JeCasObeda)
            {
                var dostupniPracovnici = MyAgent.DostupniPracovniciList;
                dostupniPracovnici.Clear();
                var dostupniNenajedeni = new BitArray(MyAgent.DostupniPracovnici);
                dostupniNenajedeni.And(MyAgent.NenajedeniPracovnici);
                int i = 0;
                for(i = 0; i < MyAgent.PocetPracovnikov; ++i)
                {
                    if (dostupniNenajedeni[i])
                        dostupniPracovnici.Add(MyAgent.Pracovnici[i]);
                }

                int index = -1;
                while (dostupniPracovnici.Count != 0 && MyAgent.PocetObedujucich < MyAgent.PocetPracovnikov / 2)
                {
                    if (dostupniPracovnici.Count == 0)
                        return;
                    if(dostupniPracovnici.Count == 1)
                    {
                        SkustPoslatPracovnikaNaObed(dostupniPracovnici[0]);
                        dostupniPracovnici.Clear();
                        return;
                    }
                    var generator = MyAgent.GeneratoryVyberuZamenstnancaNaObed[dostupniPracovnici.Count - 2];

                    if (MyAgent.PocetUzNajedenychPracovnikov == MyAgent.PocetPracovnikov)
                        break;
                    
                    index = generator.Sample();
                    SkustPoslatPracovnikaNaObed(dostupniPracovnici[index]);
                    dostupniPracovnici.RemoveAt(index);
                }
            }
        }

        protected bool SkustPoslatPracovnikaNaObed(Pracovnik pracovnik)
        {
            if(MyAgent.NenajedeniPracovnici[pracovnik.IDPracovnika] && MyAgent.PocetObedujucich < MyAgent.PocetPracovnikov / 2 && MyAgent.JeCasObeda)
            {
                var sprava = new Sprava(MySim);
                sprava.Code = Mc.VykonajObed;
                sprava.Pracovnik = pracovnik;
                sprava.Addressee = ((VacCenterSimulation)MySim).AgentVakCentra;
                MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, false);
                ++MyAgent.PocetObedujucich;
                ++MyAgent.PocetUzNajedenychPracovnikov;
                Request(sprava);
                return true;
            }
            return false;
        }

        protected void NavratPracovnikaZObedu(Pracovnik pracovnik)
        {
            MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, true);
            MyAgent.NenajedeniPracovnici.Set(pracovnik.IDPracovnika, false);
            pracovnik.Obedoval = true;
            --MyAgent.PocetObedujucich;
            pracovnik.Stav = "Nečinný";
            NaplanujMozneObedy();
            AkCakaSpracujDalsieho();
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
