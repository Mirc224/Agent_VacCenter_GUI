using OSPABA;
using agents;
using Agent_VacCenter_GUI;
using System;
using OSPStat;

namespace simulation
{
	public class VacCenterSimulation : Simulation
	{
		public string NaformovatovanyCas {
			get
			{
				TimeSpan t = TimeSpan.FromSeconds(RealnyCasVSekundach);
				return t.ToString(@"hh\:mm\:ss");
			}
		}
		public double ZaciatocnyCasVSekundach { get => 28800; }
		public double RealnyCasVSekundach { get => CurrentTime + ZaciatocnyCasVSekundach; }

		public Stat PriemernaDlzkaRaduRegistracia { get; private set; } = new Stat();
		public Stat PriemernaDlzkaRaduVysetrenie { get; private set; } = new Stat();
		public Stat PriemernaDlzkaRaduOckovanie { get; private set; } = new Stat();

		public Stat PriemernyCasCakaniaRegistracia { get; private set; } = new Stat();
		public Stat PriemernyCasCakaniaVysetrenie { get; private set; } = new Stat();
		public Stat PriemernyCasCakaniaOckovanie { get; private set; } = new Stat();

		public Stat PriemerneVytazenieAdmin { get; private set; } = new Stat();
		public Stat PriemerneVytazenieDoktor { get; private set; } = new Stat();
		public Stat PriemerneVytazenieSestricka { get; private set; } = new Stat();
		public Stat PriemernaDlzkaRaduStriekacky { get; private set; } = new Stat();
		public Stat PriemernyCasCakaniaStriekacky { get; private set; } = new Stat();

		public Stat PriemernaCakaciaDoba { get; private set; } = new Stat();
		public Stat PriemernyPocetLudiVCakarni { get; private set; } = new Stat();

		public Stat PriemernyNadcas { get; private set; } = new Stat();

		public AppGUI GUI;
		public VacCenterSimulation(AppGUI gui)
		{
			GUI = gui;
			Init();
		}

		public void ZmenaRychlosti()
        {
			if (GUI != null)
				if (GUI.MaximalnaRychlost)
					SetMaxSimSpeed();
				else
					SetSimSpeed(Math.Ceiling(GUI.AktualnaRychlostSimulacie / 10000), 1.0/GUI.AktualnaRychlostSimulacie);

		}

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis

			PriemernyNadcas.Clear();

			PriemernaDlzkaRaduRegistracia.Clear();
			PriemernaDlzkaRaduVysetrenie.Clear();
			PriemernaDlzkaRaduOckovanie.Clear();

			PriemernyCasCakaniaRegistracia.Clear();
			PriemernyCasCakaniaVysetrenie.Clear();
			PriemernyCasCakaniaOckovanie.Clear();

			PriemerneVytazenieAdmin.Clear();
			PriemerneVytazenieDoktor.Clear();
			PriemerneVytazenieSestricka.Clear();

			PriemernaDlzkaRaduStriekacky.Clear();
			PriemernyCasCakaniaStriekacky.Clear();

			PriemernaCakaciaDoba.Clear();
			PriemernyPocetLudiVCakarni.Clear();

		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
			// Reset entities, queues, local statistics, etc...
			ZmenaRychlosti();
		}

		public void UpdateStatistikPredUkoncenim()
        {
			PriemernyNadcas.AddSample(CurrentTime - 540 * 60);
			AgentRegistracie.UpdateZaverecnychStatistik();
			AgentVysetrenia.UpdateZaverecnychStatistik();
			AgentOckovania.UpdateZaverecnychStatistik();
			AgentCakarne.UpdateZaverecnychStatistik();
			AgentPripravyDavok.UpdateZaverecnychStatistik();
		}
		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();
            //Console.WriteLine(CurrentTime - 540 * 60);

			PriemernaDlzkaRaduRegistracia.AddSample( AgentRegistracie.DlzkaRadu.Mean());
			PriemernaDlzkaRaduVysetrenie.AddSample(AgentVysetrenia.DlzkaRadu.Mean());
			PriemernaDlzkaRaduOckovanie.AddSample( AgentOckovania.DlzkaRadu.Mean());

			PriemernyCasCakaniaRegistracia.AddSample(AgentRegistracie.DlzkaCakania.Mean());
			PriemernyCasCakaniaVysetrenie.AddSample(AgentVysetrenia.DlzkaCakania.Mean());
			PriemernyCasCakaniaOckovanie.AddSample(AgentOckovania.DlzkaCakania.Mean());

			PriemerneVytazenieAdmin.AddSample(AgentRegistracie.PriemerneVytazeniePracovnikov);
			PriemerneVytazenieDoktor.AddSample(AgentVysetrenia.PriemerneVytazeniePracovnikov);
			PriemerneVytazenieSestricka.AddSample(AgentOckovania.PriemerneVytazeniePracovnikov);

			PriemernaDlzkaRaduStriekacky.AddSample(AgentPripravyDavok.DlzkaRadu.Mean());
			PriemernyCasCakaniaStriekacky.AddSample(AgentPripravyDavok.DlzkaCakania.Mean());

			PriemernyPocetLudiVCakarni.AddSample(AgentCakarne.DlzkaRadu.Mean());

			PriemernaCakaciaDoba.AddSample(AgentOkolia.CelkovaDobaCakaniaPacientov.Mean());

			if((CurrentReplication + 1) % 100 == 0)
            {
				System.Console.WriteLine($"R{CurrentReplication + 1}: Koniec replikace");
				System.Console.WriteLine($"Vytazenie administracie: {PriemerneVytazenieAdmin.Mean()}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduRegistracia.Mean()}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaRegistracia.Mean()}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Vytazenie doktorov: {PriemerneVytazenieDoktor.Mean()}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduVysetrenie.Mean()}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaVysetrenie.Mean()}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Vytazenie sestriciek: {PriemerneVytazenieSestricka.Mean()}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduOckovanie.Mean()}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaOckovanie.Mean()}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Priemerna dlzka radu striekacky: {PriemernaDlzkaRaduStriekacky.Mean()}");
				System.Console.WriteLine($"Priemerny cas cakania striekacky: {PriemernyCasCakaniaStriekacky.Mean()}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Priemerny pocet ludi v cakarni: {PriemernyPocetLudiVCakarni.Mean()}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernaCakaciaDoba.Mean()}");

				System.Console.WriteLine();

				System.Console.WriteLine(AgentOkolia.PocetNepridenychPacientov + " " + AgentOkolia.PocetPacientovVojdenych);
			}
			if (GUI != null)
				GUI.AfterReplicationGUIUpdate();
		}

		override protected void SimulationFinished()
		{
			// Dysplay simulation results
			base.SimulationFinished();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			AgentModelu = new AgentModelu(SimId.AgentModelu, this, null);
			AgentOkolia = new AgentOkolia(SimId.AgentOkolia, this, AgentModelu);
			AgentVakCentra = new AgentVakCentra(SimId.AgentVakCentra, this, AgentModelu);
			AgentRegistracie = new AgentRegistracie(SimId.AgentRegistracie, this, AgentVakCentra);
			AgentVysetrenia = new AgentVysetrenia(SimId.AgentVysetrenia, this, AgentVakCentra);
			AgentOckovania = new AgentOckovania(SimId.AgentOckovania, this, AgentVakCentra);
			AgentCakarne = new AgentCakarne(SimId.AgentCakarne, this, AgentVakCentra);
			AgentPripravyDavok = new AgentPripravyDavok(SimId.AgentPripravyDavok, this, AgentVakCentra);
			AgentJedalne = new AgentJedalne(SimId.AgentJedalne, this, AgentVakCentra);
			AgentPresunu = new AgentPresunu(SimId.AgentPresunu, this, AgentVakCentra);
		}

		public void VykonajUpdateStavu()
        {
			AgentRegistracie.UpdatujStatistiky();
			AgentVysetrenia.UpdatujStatistiky();
			AgentOckovania.UpdatujStatistiky();
        }
		public AgentModelu AgentModelu
		{ get; set; }
		public AgentOkolia AgentOkolia
		{ get; set; }
		public AgentVakCentra AgentVakCentra
		{ get; set; }
		public AgentRegistracie AgentRegistracie
		{ get; set; }
		public AgentVysetrenia AgentVysetrenia
		{ get; set; }
		public AgentOckovania AgentOckovania
		{ get; set; }
		public AgentCakarne AgentCakarne
		{ get; set; }
		public AgentPresunu AgentPresunu
		{ get; set; }
		public AgentPripravyDavok AgentPripravyDavok
		{ get; set; }
		public AgentJedalne AgentJedalne
		{ get; set; }
		//meta! tag="end"
	}
}