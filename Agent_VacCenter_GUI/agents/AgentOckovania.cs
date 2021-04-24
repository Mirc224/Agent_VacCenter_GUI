using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;
using entities;
using System.Collections.Generic;
using Agent_VacCenter_GUI.model;

namespace agents
{
    //meta! id="6"
    public class AgentOckovania : BaseAgentPracoviska
    {
        public ProcessOckovania ProcessOckovania { get; private set; }
        public AgentOckovania(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            Init();

            PocetPracovnikov = 3;
            LokaciaPracoviska = Lokacie.MiestnostOckovanie;
            //InicializaciaPredSimulaciou();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            InicializaciaPredReplikaciou();
        }


        //meta! userInfo="Generated code: do not modify", tag="begin"
        private void Init()
        {
            new ManagerOckovania(SimId.ManagerOckovania, MySim, this);
            ProcessOckovania = new ProcessOckovania(SimId.ProcessOckovania, MySim, this);
            SchedulerObedov = new SchedulerObeduSestriciek(SimId.SchedulerObeduDoktorov, MySim, this);
            ProcessObsluhy = ProcessOckovania;
            AddOwnMessage(Mc.NoticeKoniecOckovania);
            AddOwnMessage(Mc.NoticeZaciatokOckovania);
            AddOwnMessage(Mc.ZaockujPacienta);
            AddOwnMessage(Mc.NaplnStriekacky);
            AddOwnMessage(Mc.NoticeCasObeda);
            AddOwnMessage(Mc.VykonajObed);

            DlzkaCakania = new Stat();
            DlzkaRadu = new WStat(MySim);
            VytazeniePracovnikov = new WStat(MySim);
        }
        //meta! tag="end"
    }
}
