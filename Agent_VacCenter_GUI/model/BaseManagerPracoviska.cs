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
            ++MyAgent.PocetPracujucich;
            pracovnik.Utilization.AddSample(1);
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.PocetPracujucich);
            pracovnik.ZaciatokObsluhovania = MySim.CurrentTime;
            MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, false);
            //pracovnik.Nedostupny = true;
            ((Sprava)message).Pracovnik = pracovnik;
        }

        protected void DokonceniePracePracovnikom(Pracovnik pracovnik)
        {
            //pracovnik.Nedostupny = false;
            MyAgent.DostupniPracovnici.Set(pracovnik.IDPracovnika, true);
            //double trvanieObsluhy = MySim.CurrentTime - pracovnik.ZaciatokObsluhovania;
            pracovnik.Utilization.AddSample(0);
            //MyAgent.VytazeniePracovnikov.AddSample(trvanieObsluhy);
            --MyAgent.PocetPracujucich;
            MyAgent.VytazeniePracovnikov.AddSample(MyAgent.PocetPracujucich);

            SkusPoslatNaObedAleboObsluzDalsieho(pracovnik);
            
        }

        protected void SkusPoslatNaObedAleboObsluzDalsieho(Pracovnik pracovnik)
        {
            if (!SkustPoslatPracovnikaNaObed(pracovnik))
                AkCakaSpracujDalsieho();
        }

        protected void NaplanujMozneObedy()
        {

            if(MyAgent.PocetUzNajedenychPracovnikov < MyAgent.MaxPocetPracovnikov && MyAgent.JeCasObeda)
            {
                //var zamestnanciNaObed = new List<Pracovnik>(MyAgent.MaxPocetPracovnikov);
                var dostupniNenajedeni = new BitArray(MyAgent.DostupniPracovnici);
                dostupniNenajedeni.And(MyAgent.NenajedeniPracovnici);
                int i = 0;
                for(i = 0; i < MyAgent.MaxPocetPracovnikov; ++i)
                {
                    if (dostupniNenajedeni[i])
                        if(MyAgent.PocetObedujucich < MyAgent.MaxPocetPracovnikov / 2)
                        {
                            //zamestnanciNaObed.Add(MyAgent.Pracovnici[i]);
                            SkustPoslatPracovnikaNaObed(MyAgent.Pracovnici[i]);
                            if (MyAgent.PocetUzNajedenychPracovnikov == MyAgent.MaxPocetPracovnikov)
                                break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
        }

        protected bool SkustPoslatPracovnikaNaObed(Pracovnik pracovnik)
        {
            //if (pracovnik.Nedostupny  || pracovnik.Obedoval)
            //throw new Exception("Toto nemoze nastat!");
            //pracovnik.Nedostupny = true;
            if(MyAgent.NenajedeniPracovnici[pracovnik.IDPracovnika] && MyAgent.PocetObedujucich < MyAgent.MaxPocetPracovnikov / 2 && MyAgent.JeCasObeda)
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
