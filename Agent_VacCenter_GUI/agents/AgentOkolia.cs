using OSPABA;
using simulation;
using managers;
using continualAssistants;
using OSPStat;
using entities;
using System.Collections.Generic;
using Agent_VacCenter_GUI.model;
using System.Collections;

namespace agents
{
	//meta! id="2"
	public class AgentOkolia : Agent, ISimUpdates
	{
		/**
		 * Agent okolia symbolizuje okolie systemu a je bodom, kde do systemu vstupuju pacienti. O ich prichody sa stara scheduler prichodov. Nachadzaju sa tu
		 * atributy pre zber statistik ako aj pomocne premene pre nasledny efektivny vypis.
		 */
		public SchedulerPrichodov SchedulerPrichodov { get; private set; }
		public Stat CelkovaDobaCakaniaPacientov { get; private set; }
		public int PocetNepridenychPacientov { get; private set; }
		public int PocetObjednanychPacientov { get; set; } = 540;
		public double CasMedziPrichodmi { get => (double)(540 * 60)/ PocetObjednanychPacientov;}
		public List<Pacient> ZoznamPridenychPacientov { get; private set; }
		public int PocetPacientovVojdenych { get; set; }
		public int PocetPacientovOdidenych { get; set; }
		public bool Generuj { get; set; }
		public BitArray OdideniPacienti { get; private set; }

		public int UpdatujPacientovOdIndexu { get; private set; }
		private int _poslednyUpdatePacientovOdIndexu;
		public List<string[]> InformacieOPacientoch { get; private set; }
		private OSPRNG.UniformDiscreteRNG _generatorNepridenychPacientov;
		public AgentOkolia(int id, Simulation mySim, Agent parent) : 
			base(id, mySim, parent)
		{
			Init();
		}

		/**
		 * Resetovanie statistik pred replikaciou.
		 */
		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
			PocetPacientovVojdenych = 0;
			PocetPacientovOdidenych = 0;
			UpdatujPacientovOdIndexu = 0;
			_poslednyUpdatePacientovOdIndexu = 0;
			Pacient.AktualneID = 0;
			CelkovaDobaCakaniaPacientov.Clear();
			ZoznamPridenychPacientov.Clear();
			InformacieOPacientoch.Clear();
			OdideniPacienti.SetAll(false);
			Generuj = true;
		}

		/**
		 * Pred kazdou replikaciou sa musi vygenerovat pocet nepridenych pacientov, ktori sa pouziva v scheduleri prichodov pre vypocet, ci sa dany pacient dostavi
		 * alebo nie.
		 */
		public void VygenerujNepridenych()
        {
			_generatorNepridenychPacientov = new OSPRNG.UniformDiscreteRNG(5, 25, (MySim as VacCenterSimulation).GeneratorNasad);
			PocetNepridenychPacientov = _generatorNepridenychPacientov.Sample();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ManagerOkolia(SimId.ManagerOkolia, MySim, this);
			SchedulerPrichodov = new SchedulerPrichodov(SimId.SchedulerPrichodov, MySim, this);
			AddOwnMessage(Mc.NoticeOdchodPacienta);
			AddOwnMessage(Mc.NoticePrichodPacienta);
			AddOwnMessage(Mc.NoticeNaplanujPrichod);
			AddOwnMessage(Mc.NoticeInicializuj);

			_generatorNepridenychPacientov = new OSPRNG.UniformDiscreteRNG(5, 25);
			CelkovaDobaCakaniaPacientov = new Stat();
		}
		//meta! tag="end"

		public void InicializaciaPredSimulaciou()
        {
			ZoznamPridenychPacientov = new List<Pacient>(PocetObjednanychPacientov);
			OdideniPacienti = new BitArray(PocetObjednanychPacientov);
			InformacieOPacientoch = new List<string[]>(PocetObjednanychPacientov);
        }

		public void UpdatujStatistiky()
		{

			int i = 0;
			Pacient tmpPacient;
			string[] infoOPacientovi;

			for (i = _poslednyUpdatePacientovOdIndexu; i < InformacieOPacientoch.Count; ++i)
			{
				tmpPacient = ZoznamPridenychPacientov[i];
				infoOPacientovi = InformacieOPacientoch[i];
				infoOPacientovi[1] = tmpPacient.Stav;
				infoOPacientovi[3] = string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaRegistraciu);
				infoOPacientovi[4] = string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaVysetrenie);
				infoOPacientovi[5] = string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaOckovanie);
				infoOPacientovi[6] = string.Format("{0:0.##}min", tmpPacient.DobaCakaniaVCakarni / 60);
			}

			for (i = InformacieOPacientoch.Count; i < ZoznamPridenychPacientov.Count; ++i)
            {
				tmpPacient = ZoznamPridenychPacientov[i];
				InformacieOPacientoch.Add(new string[] { tmpPacient.IDPacienta.ToString(), tmpPacient.Stav, tmpPacient.NaformovatovanyCasPrichodu, 
														 string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaRegistraciu),
														 string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaVysetrenie),
														 string.Format("{0:0.##}s", tmpPacient.DobaCakaniaNaOckovanie),
														 string.Format("{0:0.##}min", tmpPacient.DobaCakaniaVCakarni/60)});
			}
			
			for(i = _poslednyUpdatePacientovOdIndexu; i < PocetObjednanychPacientov; ++i)
            {
				if(!OdideniPacienti[i])
                {
					UpdatujPacientovOdIndexu = _poslednyUpdatePacientovOdIndexu;
					_poslednyUpdatePacientovOdIndexu = i;
					break;
                }

            }

		}

	}
}