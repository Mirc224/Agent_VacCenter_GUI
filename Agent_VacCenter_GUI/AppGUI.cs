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
        delegate void SetTimeCallback(OSPABA.Simulation sim);
        private simulation.VacCenterSimulation _simulation;
        public AppGUI()
        {
            _simulation = new simulation.VacCenterSimulation(this);
            _simulation.OnSimulationDidFinish(OnStart);
            _simulation.SetSimSpeed(1, 1);
            _simulation.OnRefreshUI(OnUIRefresh);
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            string[] statNames = new string[] {"Replikacia",
                                               "Registrácia - AVG dĺžka radu:", "Registrácia - AVG dĺžka čakania:", "Registrácia - AVG vyťaženie:",
                                               "Vyšetrenie - AVG dĺžka radu:", "Vyšetrenie - AVG dĺžka čakania:", "Vyšetrenie - AVG vyťaženie:",
                                               "Očkovanie - AVG dĺžka radu:", "Očkovanie - AVG dĺžka čakania:", "Očkovanie - AVG vyťaženie:"
                                               };
            string[] statValues = new string[] {"0",
                                               "0", "0", "0",
                                               "0", "0", "0",
                                               "0", "0", "0"
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
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernaDlzkaRaduRegistracia/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernyCasCakaniaRegistracia/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemerneVytazenieAdmin/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernaDlzkaRaduVysetrenie/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernyCasCakaniaVysetrenie/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemerneVytazenieDoktor/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernaDlzkaRaduOckovanie/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemernyCasCakaniaOckovanie/ replikacia).ToString();
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (_simulation.PriemerneVytazenieSestricka/ replikacia).ToString();
        }

        public void OnRefresh(OSPABA.Simulation sim)
        {
            Console.WriteLine("Refresh");
        }

        public void OnStart(OSPABA.Simulation sim)
        {
            var simulacia = sim as simulation.VacCenterSimulation;
            InicializujTabulku(tabulkaRegistracia, simulacia.AgentRegistracie.StatistikyPracoviska.UdajeOPracovnikoch);
            InicializujTabulku(tabulkaVysetrenie, simulacia.AgentVysetrenia.StatistikyPracoviska.UdajeOPracovnikoch);
            InicializujTabulku(tabulkaOckovanie, simulacia.AgentOckovania.StatistikyPracoviska.UdajeOPracovnikoch);
        }

        public void OnUIRefresh(OSPABA.Simulation sim)
        {
            var simulacia = sim as simulation.VacCenterSimulation;
            if(casLabel.InvokeRequired)
            {

                SetTimeCallback d = new SetTimeCallback(OnUIRefresh);
                Invoke(d, new object[] { sim });
            }
            else
            {
                TimeSpan t = TimeSpan.FromSeconds(simulacia.RealnyCasVSekundach);
                var startTime = t.ToString(@"hh\:mm\:ss");
                casLabel.Text = startTime;
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
            var replikacie = 1;
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
