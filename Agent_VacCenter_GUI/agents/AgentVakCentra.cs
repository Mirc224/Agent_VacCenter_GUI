using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
    //meta! id="3"
    public class AgentVakCentra : Agent
    {
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
            AddOwnMessage(Mc.NoticeKoniecOckovania);
            AddOwnMessage(Mc.NoticeKoniecRegistracie);
            AddOwnMessage(Mc.NoticePrichodPacienta);
            AddOwnMessage(Mc.NoticeKoniecVysetrenia);
            AddOwnMessage(Mc.NoticeKoniecCakania);
            AddOwnMessage(Mc.NoticeKoniecPresunu);
        }
        //meta! tag="end"
    }
}
