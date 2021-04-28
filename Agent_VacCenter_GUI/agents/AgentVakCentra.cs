using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
    //meta! id="3"
    public class AgentVakCentra : Agent
    {
        /**
         * Zastresuje cele vakcinacne centrum, zabezpecuje posielanie sprav na presuny entit v modeli. Zabezpecuje koordinaciu pacientov, aby navstevovali jednotlive
         * ukony v takom poradi ako je potrebne.
         */
        public AgentVakCentra(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        private void Init()
        {
            new ManagerVakCentra(SimId.ManagerVakCentra, MySim, this);
            AddOwnMessage(Mc.NoticePrichodPacienta);
            AddOwnMessage(Mc.VykonajPresun);
            AddOwnMessage(Mc.ZaregistrujPacienta);
            AddOwnMessage(Mc.VysetriPacienta);
            AddOwnMessage(Mc.ZaockujPacienta);
            AddOwnMessage(Mc.PacientCakaj);
            AddOwnMessage(Mc.NaplnStriekacky);
            AddOwnMessage(Mc.VykonajObed);
        }
        //meta! tag="end"
    }
}
