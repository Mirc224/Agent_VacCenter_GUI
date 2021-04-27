using OSPABA;
using simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_VacCenter_GUI.model
{
    public abstract class BaseSchedulerObedov: Scheduler
    {
        public int Hodina { get; protected set; } = 0;
        public int Minuta { get; protected set; } = 0;
        public int Sekunda { get; protected set; } = 0;
        public BaseSchedulerObedov(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            var sprava = new Sprava(MySim);
            sprava.Code = Mc.NoticeCasObeda;
            double casCakania = Math.Max(Hodina * 3600 + Minuta * 60 + Sekunda - MySim.ZaciatocnyCasVSekundach,0);
            Hold(casCakania, sprava);
        }

        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NoticeCasObeda:
                    message.Addressee = MyAgent;
                    Notice(message);
                    break;
                default:
                    ProcessDefault(message);
                    break;
            }
        }

        public new VacCenterSimulation MySim
        {
            get
            {
                return (VacCenterSimulation)base.MySim;
            }
        }
    }
}
