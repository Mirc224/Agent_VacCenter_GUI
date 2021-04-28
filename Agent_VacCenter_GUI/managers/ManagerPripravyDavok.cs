using OSPABA;
using simulation;
using agents;
using continualAssistants;
using System.Collections.Generic;

namespace managers
{
	//meta! id="83"
	public class ManagerPripravyDavok : Manager
	{
		/**
         * Manazuje pripravu davok pre sestricky. Posiela spravy procesu pripravy davok v pripade ak je dostupne miesto na pripravu vakcinacnej davky. 
         * V pripade ak nie je, je sestricka zaradena do frontu.
         */
		public Queue<Sprava> Front { get; private set; }
		public ManagerPripravyDavok(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="AgentVakCentra", id="86", type="Request"
		public void ProcessNaplnStriekacky(MessageForm message)
		{
			var sprava = message as Sprava;
			message.Addressee = MyAgent.ProcessNaplnaniaDavok;
			message.Code = Mc.NoticeZaciatokNaplnania;
			sprava.ZaciatokObsluhy = MySim.CurrentTime;
			if (!MyAgent.ObsluhaVolna)
			{
				Front.Enqueue(sprava);
				MyAgent.DlzkaRadu.AddSample(Front.Count);
			}
			else
			{
				double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
				MyAgent.DlzkaCakania.AddSample(dobaCakania);

				NaplanujObsluhu(message);

				StartContinualAssistant(message);
			}
		}

		private void NaplanujObsluhu(MessageForm message)
		{
			--MyAgent.PocetVolnych;
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="ProcessNaplnaniaDavok", id="93", type="Notice"
		public void ProcessNoticeKoniecNaplnania(MessageForm message)
		{
			++MyAgent.PocetVolnych;
			message.Code = Mc.NaplnStriekacky;
			Response(message);

			if (Front.Count > 0)
			{
				var sprava = Front.Dequeue();
				double dobaCakania = MySim.CurrentTime - sprava.ZaciatokObsluhy;
				MyAgent.DlzkaCakania.AddSample(dobaCakania);

				sprava.Addressee = MyAgent.ProcessNaplnaniaDavok;
				MyAgent.DlzkaRadu.AddSample(Front.Count);
				NaplanujObsluhu(sprava);
				StartContinualAssistant(sprava);
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
			case Mc.NaplnStriekacky:
					switch(message.Sender.Id)
                    {
						case SimId.AgentVakCentra:
							ProcessNaplnStriekacky(message);
							break;
						default:
                            System.Console.WriteLine("zle");
							break;
					}
				
			break;

			case Mc.Finish:
				ProcessNoticeKoniecNaplnania(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new AgentPripravyDavok MyAgent
		{
			get
			{
				return (AgentPripravyDavok)base.MyAgent;
			}
		}
	}
}