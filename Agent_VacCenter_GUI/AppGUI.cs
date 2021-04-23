using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agent_VacCenter_GUI
{
    public class ParametreSimulace
    {
        public int replikacie;
        public double casSimulacie;
    }
    public partial class AppGUI : Form
    {
        delegate void GUIStatUpdateCallback(OSPABA.Simulation sim);
        private simulation.VacCenterSimulation _simulation;
        public AppGUI()
        {
            _simulation = new simulation.VacCenterSimulation(this);
            _simulation.OnSimulationDidFinish(OnFinish);
            //_simulation.SetSimSpeed(5, 0.0001);
            _simulation.OnRefreshUI(OnUIRefresh);
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string[] statNames = new string[] {"Replikacia",
                                               "Registrácia - AVG dĺžka radu:", "Registrácia - AVG dĺžka čakania:", "Registrácia - AVG vyťaženie:",
                                               "Vyšetrenie - AVG dĺžka radu:", "Vyšetrenie - AVG dĺžka čakania:", "Vyšetrenie - AVG vyťaženie:",
                                               "Očkovanie - AVG dĺžka radu:", "Očkovanie - AVG dĺžka čakania:", "Očkovanie - AVG vyťaženie:",
                                               "Priemerný počet ľudí v čakárni:", "Priemerný čas čakania:"};
            string[] statValues = new string[] {"0",
                                               "0", "0", "0",
                                               "0", "0", "0",
                                               "0", "0", "0",
                                               "0", "0"
                                               };
            tabulkaReplikacie.Rows.Clear();
            for (int i = 0; i < statNames.Length; ++i)
            {
                tabulkaReplikacie.Rows.Add(new string[] { statNames[i], statValues[i]});
            }
        }

        public void AfterReplicationGUIUpdate()
        {

            int i = 0;
            int replikacia = _simulation.CurrentReplication + 1;
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduRegistracia/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaRegistracia/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%",(_simulation.PriemerneVytazenieAdmin * 100 / replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduVysetrenie/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaVysetrenie/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%", (_simulation.PriemerneVytazenieDoktor * 100 / replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduOckovanie/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaOckovanie/ replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%",(_simulation.PriemerneVytazenieSestricka * 100 / replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}",(_simulation.PriemernyPocetLudiVCakarni / replikacia));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}s", (_simulation.PriemernaCakaciaDoba / replikacia));
        }

        public void OnRefresh(OSPABA.Simulation sim)
        {
            Console.WriteLine("Refresh");
        }

        public void OnFinish(OSPABA.Simulation sim)
        {
            var simulacia = sim as simulation.VacCenterSimulation;
            if (casLabel.InvokeRequired)
            {

                GUIStatUpdateCallback d = new GUIStatUpdateCallback(OnFinish);
                Invoke(d, new object[] { sim });
            }
            else
            {
                Console.WriteLine("Teraz");
                casLabel.Text = simulacia.NaformovatovanyCas;
                simulacia.VykonajUpdateStavu();
                InicializujTabulku(tabulkaRegistracia, simulacia.AgentRegistracie.StatistikyPracoviska.UdajeOPracovnikoch);
                InicializujTabulku(tabulkaVysetrenie, simulacia.AgentVysetrenia.StatistikyPracoviska.UdajeOPracovnikoch);
                InicializujTabulku(tabulkaOckovanie, simulacia.AgentOckovania.StatistikyPracoviska.UdajeOPracovnikoch);
            }
        }

        public void OnUIRefresh(OSPABA.Simulation sim)
        {
            var simulacia = sim as simulation.VacCenterSimulation;
            if(casLabel.InvokeRequired)
            {

                GUIStatUpdateCallback d = new GUIStatUpdateCallback(OnUIRefresh);
                Invoke(d, new object[] { sim });
            }
            else
            {
                casLabel.Text = simulacia.NaformovatovanyCas;
                simulacia.VykonajUpdateStavu();
                InicializujTabulku(tabulkaRegistracia, simulacia.AgentRegistracie.StatistikyPracoviska.UdajeOPracovnikoch);
                InicializujTabulku(tabulkaVysetrenie, simulacia.AgentVysetrenia.StatistikyPracoviska.UdajeOPracovnikoch);
                InicializujTabulku(tabulkaOckovanie, simulacia.AgentOckovania.StatistikyPracoviska.UdajeOPracovnikoch);
            }
            
        }

        private void InicializujTabulku(DataGridView tabulka, string[][] udaje)
        {
            tabulka.Rows.Clear();
            for (int i = 0; i < udaje.Length; ++i)
            {
                tabulka.Rows.Add(udaje[i]);
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            var replikacie = 1000;
            //var casReplikacie = 540 * 60;
            var casReplikacie = 540 * 60;
            Thread thread = new Thread(new ParameterizedThreadStart(SpustSimulaciu));
            thread.Start(new ParametreSimulace() { replikacie = replikacie, casSimulacie = casReplikacie});
            //_simulation.Simulate(replikacie, casReplikacie);
        }

        private void SpustSimulaciu(object obj)
        {
            var parametre = obj as ParametreSimulace;

            _simulation.Simulate(parametre.replikacie, parametre.casSimulacie);
        }
    }
}
