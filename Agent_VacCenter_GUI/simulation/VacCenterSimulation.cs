using OSPABA;
using agents;
using Agent_VacCenter_GUI;
using System;

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
		public double PriemernaDlzkaRaduRegistracia;
		public double PriemernaDlzkaRaduVysetrenie;
		public double PriemernaDlzkaRaduOckovanie;

		public double PriemernyCasCakaniaRegistracia;
		public double PriemernyCasCakaniaVysetrenie;
		public double PriemernyCasCakaniaOckovanie;

		public double PriemerneVytazenieAdmin;
		public double PriemerneVytazenieDoktor;
		public double PriemerneVytazenieSestricka;

		public double PriemernaDlzkaRaduStriekacky;
		public double PriemernyCasCakaniaStriekacky;

		public double PriemernaCakaciaDoba;
		public double PriemernyPocetLudiVCakarni;

		public AppGUI GUI;
		public VacCenterSimulation(AppGUI gui)
		{
			GUI = gui;
			Init();
		}

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
			// Create global statistcis


			PriemernaDlzkaRaduRegistracia = 0;
			PriemernaDlzkaRaduVysetrenie = 0;
			PriemernaDlzkaRaduOckovanie = 0;

			PriemernyCasCakaniaRegistracia = 0;
			PriemernyCasCakaniaVysetrenie = 0;
			PriemernyCasCakaniaOckovanie = 0;

			PriemerneVytazenieAdmin = 0;
			PriemerneVytazenieDoktor = 0;
			PriemerneVytazenieSestricka = 0;

			PriemernaDlzkaRaduStriekacky = 0;
			PriemernyCasCakaniaStriekacky = 0;

			PriemernaCakaciaDoba = 0;
			PriemernyPocetLudiVCakarni = 0;
			
		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
			// Reset entities, queues, local statistics, etc...
		}

		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();


			PriemernaDlzkaRaduRegistracia += AgentRegistracie.DlzkaRadu.Mean();
			PriemernaDlzkaRaduVysetrenie += AgentVysetrenia.DlzkaRadu.Mean();
			PriemernaDlzkaRaduOckovanie += AgentOckovania.DlzkaRadu.Mean();

			PriemernyCasCakaniaRegistracia += AgentRegistracie.DlzkaCakania.Mean();
			PriemernyCasCakaniaVysetrenie += AgentVysetrenia.DlzkaCakania.Mean();
			PriemernyCasCakaniaOckovanie += AgentOckovania.DlzkaCakania.Mean();

			PriemerneVytazenieAdmin += AgentRegistracie.PriemerneVytazeniePracovnikov;
			PriemerneVytazenieDoktor += AgentVysetrenia.PriemerneVytazeniePracovnikov;
			PriemerneVytazenieSestricka += AgentOckovania.PriemerneVytazeniePracovnikov;

			PriemernaDlzkaRaduStriekacky += AgentPripravyDavok.DlzkaRadu.Mean();
			PriemernyCasCakaniaStriekacky += AgentPripravyDavok.DlzkaCakania.Mean();

			PriemernyPocetLudiVCakarni += AgentCakarne.DlzkaRadu.Mean();

			PriemernaCakaciaDoba += AgentOkolia.CelkovaDobaCakaniaPacientov.Mean();

			if((CurrentReplication + 1) % 100 == 0)
            {
				System.Console.WriteLine($"R{CurrentReplication + 1}: Koniec replikace");
				System.Console.WriteLine($"Vytazenie administracie: {PriemerneVytazenieAdmin / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduRegistracia / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaRegistracia / (CurrentReplication + 1)}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Vytazenie doktorov: {PriemerneVytazenieDoktor / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduVysetrenie / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaVysetrenie / (CurrentReplication + 1)}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Vytazenie sestriciek: {PriemerneVytazenieSestricka / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerna dlzka radu: {PriemernaDlzkaRaduOckovanie / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernyCasCakaniaOckovanie / (CurrentReplication + 1)}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Priemerna dlzka radu striekacky: {PriemernaDlzkaRaduStriekacky / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerny cas cakania striekacky: {PriemernyCasCakaniaStriekacky / (CurrentReplication + 1)}");
				System.Console.WriteLine();

				System.Console.WriteLine($"Priemerny pocet ludi v cakarni: {PriemernyPocetLudiVCakarni / (CurrentReplication + 1)}");
				System.Console.WriteLine($"Priemerny cas cakania: {PriemernaCakaciaDoba / (CurrentReplication + 1)}");

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