using parameters;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Agent_VacCenter_GUI
{
    public partial class AppGUI : Form
    {
        delegate void GUIStatUpdateCallback(OSPABA.Simulation sim);
        private simulation.VacCenterSimulation _simulation;
        private int[] _rychlosti = new int[] { 1, 10, 100, 1000, 10000, 100000, 500000, 1000000, 100000000 };
        public bool MaximalnaRychlost { get; set; } = false;
        public double AktualnaRychlostSimulacie { get; private set; } = 1;

        private Label[] _registraciaLabels;
        private Label[] _vysetrenieLabels;
        private Label[] _ockovanieLabels;
        private Label[] _pacientiLabels;

        private string[] _pracoviskaNazvyStatistik = new string[] { "Dĺžka radu:", "Doba čakania:", "Vyťaženie:" };
        public AppGUI()
        {
            _simulation = new simulation.VacCenterSimulation(this);
            _simulation.OnSimulationDidFinish(OnFinish);
            _simulation.OnRefreshUI(OnUIRefresh);
            InitializeComponent();
            Init();
            _registraciaLabels = new Label[] { labelDlzkaRaduRegistracia, labelDobaCakaniaRegistracia, labelVytazenieRegistracia };
            _vysetrenieLabels = new Label[] { labelDlzkaRaduVysetrenie, labelDobaCakaniaVysetrenie, labelVytazenieVysetrenie };
            _ockovanieLabels = new Label[] { labelDlzkaRaduOckovanie, labelDobaCakaniaOckovanie, labelVytazenieOckovanie };
            trackBarSlider.Maximum = _rychlosti.Length - 1;
            maxRychlostCHB.Checked = MaximalnaRychlost;
        }

        private void Init()
        {
            string[] statNames = new string[] {"Replikacia:", "Priemerný nadčas:",
                                               "Registrácia - AVG dĺžka radu:", "Registrácia - AVG dĺžka čakania:", "Registrácia - AVG vyťaženie:",
                                               "Vyšetrenie - AVG dĺžka radu:", "Vyšetrenie - AVG dĺžka čakania:", "Vyšetrenie - AVG vyťaženie:",
                                               "Očkovanie - AVG dĺžka radu:", "Očkovanie - AVG dĺžka čakania:", "Očkovanie - AVG vyťaženie:",
                                               "Priprava dávok - AVG dĺžka radu", "Priprava dávok - AVG dĺžka čakania:",
                                               "Priemerný počet ľudí v čakárni:", "Priemerný čas čakania:"};
            string[] statValues = new string[] {"0","0",
                                               "0", "0", "0",
                                               "0", "0", "0",
                                               "0", "0", "0",
                                               "0", "0",
                                               "0", "0"
                                               };
            string[] confidenceIntervals = new string[] {
                                                "0","<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>"};
            tabulkaReplikacie.Rows.Clear();
            for (int i = 0; i < statNames.Length; ++i)
            {
                tabulkaReplikacie.Rows.Add(new string[] { statNames[i], statValues[i] });
            }
        }

        public void AfterReplicationGUIUpdate()
        {
            double[] confidenceInterval;
            int i = 0;
            int replikacia = _simulation.CurrentReplication + 1;
            tabulkaReplikacie.Rows[i++].Cells[1].Value = (replikacia).ToString();


            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}min", ((_simulation.PriemernyNadcas.Mean() / 60)));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduRegistracia.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaRegistracia.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%", (_simulation.PriemerneVytazenieAdmin.Mean() * 100));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduVysetrenie.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaVysetrenie.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%", (_simulation.PriemerneVytazenieDoktor.Mean() * 100));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduOckovanie.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaOckovanie.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}%", (_simulation.PriemerneVytazenieSestricka.Mean() * 100));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}", (_simulation.PriemernaDlzkaRaduStriekacky.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.####}s", (_simulation.PriemernyCasCakaniaStriekacky.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}", (_simulation.PriemernyPocetLudiVCakarni.Mean()));
            tabulkaReplikacie.Rows[i++].Cells[1].Value = string.Format("{0:0.##}s", (_simulation.PriemernaCakaciaDoba.Mean()));


            if (_simulation.CurrentReplication > 0)
            {
                i = 1;
                confidenceInterval = _simulation.PriemernyNadcas.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.####}", confidenceInterval[0] / 60)}, {string.Format("{0:0.####}", confidenceInterval[1] / 60)}>");

                confidenceInterval = _simulation.PriemernaDlzkaRaduRegistracia.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.####}", confidenceInterval[0])}, {string.Format("{0:0.####}", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemernyCasCakaniaRegistracia.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}s", confidenceInterval[0])}, {string.Format("{0:0.##}s", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemerneVytazenieAdmin.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}", confidenceInterval[0] * 100)}, {string.Format("{0:0.##}", confidenceInterval[1] * 100)}>");

                confidenceInterval = _simulation.PriemernaDlzkaRaduVysetrenie.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.####}", confidenceInterval[0])}, {string.Format("{0:0.####}", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemernyCasCakaniaVysetrenie.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}s", confidenceInterval[0])}, {string.Format("{0:0.##}s", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemerneVytazenieDoktor.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}", confidenceInterval[0] * 100)}, {string.Format("{0:0.##}", confidenceInterval[1] * 100)}>");

                confidenceInterval = _simulation.PriemernaDlzkaRaduOckovanie.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.####}", confidenceInterval[0])}, {string.Format("{0:0.####}", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemernyCasCakaniaOckovanie.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}s", confidenceInterval[0])}, {string.Format("{0:0.##}s", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemerneVytazenieSestricka.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}", confidenceInterval[0] * 100)}, {string.Format("{0:0.##}", confidenceInterval[1] * 100)}>");

                confidenceInterval = _simulation.PriemernaDlzkaRaduStriekacky.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.####}", confidenceInterval[0])}, {string.Format("{0:0.####}", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemernyCasCakaniaStriekacky.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}s", confidenceInterval[0])}, {string.Format("{0:0.##}s", confidenceInterval[1])}>");

                confidenceInterval = _simulation.PriemernyPocetLudiVCakarni.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}", confidenceInterval[0] * 100)}, {string.Format("{0:0.##}", confidenceInterval[1] * 100)}>");

                confidenceInterval = _simulation.PriemernaCakaciaDoba.ConfidenceInterval95;
                tabulkaReplikacie.Rows[i++].Cells[2].Value = string.Format($"<{string.Format("{0:0.##}s", confidenceInterval[0])}, {string.Format("{0:0.##}s", confidenceInterval[1])}>");
            }
        }

        private void VypisStatistikyPracoviska(string[] nazvyStatistik, Label[] labelStatistiky, string[] hodnotaStatistiky)
        {
            for(int i = 0; i < nazvyStatistik.Length; ++i)
            {
                labelStatistiky[i].Text = nazvyStatistik[i] + " " + hodnotaStatistiky[i];
            }
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

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _registraciaLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentRegistracie.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentRegistracie.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentRegistracie.PriemerneVytazeniePracovnikov * 100)) });

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _vysetrenieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentVysetrenia.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentVysetrenia.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentVysetrenia.PriemerneVytazeniePracovnikov * 100)) });

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _ockovanieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentOckovania.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentOckovania.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentOckovania.PriemerneVytazeniePracovnikov * 100))  });
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

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _registraciaLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentRegistracie.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentRegistracie.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentRegistracie.PriemerneVytazeniePracovnikov * 100)) });

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _vysetrenieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentVysetrenia.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentVysetrenia.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentVysetrenia.PriemerneVytazeniePracovnikov * 100)) });

                VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _ockovanieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentOckovania.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentOckovania.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentOckovania.PriemerneVytazeniePracovnikov * 100))  });
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
            thread.Start(new ParametreSimulacie() { replikacie = replikacie, casSimulacie = casReplikacie});
            //_simulation.Simulate(replikacie, casReplikacie);
        }

        private void SpustSimulaciu(object obj)
        {
            var parametre = obj as ParametreSimulacie;
            //_simulation.Simulate();
            _simulation.Simulate(parametre.replikacie);
        }

        private void trackBarSlider_Scroll(object sender, EventArgs e)
        {
            AktualnaRychlostSimulacie = _rychlosti[trackBarSlider.Value];
            _simulation.ZmenaRychlosti();
        }

        private void maxRychlostCHB_CheckedChanged(object sender, EventArgs e)
        {
            MaximalnaRychlost = maxRychlostCHB.Checked;
            _simulation.ZmenaRychlosti();
        }
    }
}
