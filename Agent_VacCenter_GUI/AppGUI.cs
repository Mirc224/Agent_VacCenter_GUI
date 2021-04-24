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

        private Thread _simulationThread;

        private string[] _pracoviskaNazvyStatistik = new string[] { "Dĺžka radu:", "Doba čakania:", "Vyťaženie:" };
        private string[] _pacientiNazvyStatistik = new string[] { "AVG ľudí v čakárni: ", "Celková doba čakania:" };

        private ParametreSimulacie _parametreSimulacie;
        public AppGUI()
        {
            _simulation = new simulation.VacCenterSimulation(this);
            _simulation.OnReplicationWillStart(OnReplicationStart);
            _simulation.OnSimulationDidFinish(OnFinish);
            _simulation.OnRefreshUI(OnUIRefresh);
            _simulation.OnPause(OnPause);
            InitializeComponent();
            Init();
            _registraciaLabels = new Label[] { labelDlzkaRaduRegistracia, labelDobaCakaniaRegistracia, labelVytazenieRegistracia };
            _vysetrenieLabels = new Label[] { labelDlzkaRaduVysetrenie, labelDobaCakaniaVysetrenie, labelVytazenieVysetrenie };
            _ockovanieLabels = new Label[] { labelDlzkaRaduOckovanie, labelDobaCakaniaOckovanie, labelVytazenieOckovanie };
            _pacientiLabels = new Label[] { labelLudiVCakarni, labelDobaCakaniaCakaren };
            _parametreSimulacie = new ParametreSimulacie() { CasSimulacie = 540 * 60, Replikacie = 1000,
                                                             ReplikaciiNaUpdate = 100,
                                                             PocetPacientov = 540,
                                                             SpecialnePrichody = false,
                                                             ZobrazenieZavislosti = false };
            
            trackBarSlider.Maximum = _rychlosti.Length - 1;
            maxRychlostCHB.Checked = MaximalnaRychlost;

            PredvyplnVstupy();
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
                                                "","<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>",
                                               "<0, 0>", "<0, 0>"};
            tabulkaReplikacie.Rows.Clear();
            for (int i = 0; i < statNames.Length; ++i)
            {
                tabulkaReplikacie.Rows.Add(new string[] { statNames[i], statValues[i], confidenceIntervals[i] });
            }
        }

        public void OnReplicationStart(OSPABA.Simulation sim)
        {
            if (casLabel.InvokeRequired)
            {
                GUIStatUpdateCallback d = new GUIStatUpdateCallback(OnReplicationStart);
                Invoke(d, new object[] { sim });
            }
            else
            {
                tabulkaPacienti.Rows.Clear();

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


                if (_simulation.CurrentReplication > 1)
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
        }

        private void VypisStatistikyPracoviska(string[] nazvyStatistik, Label[] labelStatistiky, string[] hodnotaStatistiky)
        {
            for (int i = 0; i < nazvyStatistik.Length; ++i)
            {
                labelStatistiky[i].Text = nazvyStatistik[i] + " " + hodnotaStatistiky[i];
            }
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
                startPauseButton.Text = "Start";
                UpdateGUI();
            }
        }

        private void UpdateGUI()
        {
            casLabel.Text = _simulation.NaformovatovanyCas;
            _simulation.VykonajUpdateStavu();
            InicializujTabulku(tabulkaRegistracia, _simulation.AgentRegistracie.StatistikyPracoviska.UdajeOPracovnikoch);
            InicializujTabulku(tabulkaVysetrenie, _simulation.AgentVysetrenia.StatistikyPracoviska.UdajeOPracovnikoch);
            InicializujTabulku(tabulkaOckovanie, _simulation.AgentOckovania.StatistikyPracoviska.UdajeOPracovnikoch);

            VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _registraciaLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentRegistracie.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentRegistracie.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentRegistracie.PriemerneVytazeniePracovnikov * 100)) });

            VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _vysetrenieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentVysetrenia.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentVysetrenia.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentVysetrenia.PriemerneVytazeniePracovnikov * 100)) });

            VypisStatistikyPracoviska(_pracoviskaNazvyStatistik, _ockovanieLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentOckovania.DlzkaRadu.Mean())),
                                                                                                        string.Format("{0:0.####}s", (_simulation.AgentOckovania.DlzkaCakania.Mean())),
                                                                                                        string.Format("{0:0.##}%", (_simulation.AgentOckovania.PriemerneVytazeniePracovnikov * 100))  });

            VypisStatistikyPracoviska(_pacientiNazvyStatistik, _pacientiLabels, new string[] { string.Format("{0:0.####}", (_simulation.AgentCakarne.DlzkaRadu.Mean())),
                                                                                              string.Format("{0:0.####}s", (_simulation.AgentOkolia.CelkovaDobaCakaniaPacientov.Mean()))});

            UpdatniTabulkuPacientov();
        }

        public void OnUIRefresh(OSPABA.Simulation sim)
        {
            var simulacia = sim as simulation.VacCenterSimulation;
            if (casLabel.InvokeRequired)
            {

                GUIStatUpdateCallback d = new GUIStatUpdateCallback(OnUIRefresh);
                Invoke(d, new object[] { sim });
            }
            else
            {
                UpdateGUI();
            }

        }

        private void OnPause(OSPABA.Simulation sim)
        {
            OnUIRefresh(_simulation);
        }

        private void UpdatniTabulkuPacientov()
        {
            _simulation.AgentOkolia.UpdatujStatistiky();
            int i = 0;
            var riadky = tabulkaPacienti.Rows;
            var infoOPacientoch = _simulation.AgentOkolia.InformacieOPacientoch;
            string[] pacientData;
            DataGridViewCellCollection cells;
            for (i = _simulation.AgentOkolia.UpdatujPacientovOdIndexu; i < riadky.Count; ++i)
            {
                cells = tabulkaPacienti.Rows[i].Cells;
                pacientData = infoOPacientoch[i];
                cells[1].Value = pacientData[1];
                cells[3].Value = pacientData[3];
                cells[4].Value = pacientData[4];
                cells[5].Value = pacientData[5];
                cells[6].Value = pacientData[6];
            }

            for (i = riadky.Count; i < infoOPacientoch.Count; ++i)
            {
                riadky.Add(infoOPacientoch[i]);
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
            if (!_simulation.IsRunning())
            {
                var replikacie = 1000;
                var casReplikacie = 540 * 60;
                _simulationThread = new Thread(new ThreadStart(SpustSimulaciu));
                _simulationThread.Start();
                startPauseButton.Text = "Pause";
            }
            else
            {
                if(_simulation.IsRunning() && _simulation.IsPaused())
                {
                    startPauseButton.Text = "Pause";
                    _simulation.ResumeSimulation();
                }
                else
                {
                    startPauseButton.Text = "Continue";
                    _simulation.PauseSimulation();
                }
                
            }

            //_simulation.Simulate(replikacie, casReplikacie);
        }

        private void SpustSimulaciu()
        {
            _simulation.AplikujParametreSimulacie( _parametreSimulacie);
            if(_parametreSimulacie.ZobrazenieZavislosti)
            {

            }
            else
            {
                _simulation.ResumeSimulation();
                _simulation.StopSimulation();
                _simulation.Simulate(_parametreSimulacie.Replikacie);
            }
            
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

        private void stopButton_Click(object sender, EventArgs e)
        {
            _simulation.StopSimulation();
            if (_simulationThread != null && _simulationThread.IsAlive)
                _simulationThread.Abort();
            startPauseButton.Text = "Start";
        }

        private void AppGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            _simulation.StopSimulation();
            if (_simulationThread != null && _simulationThread.IsAlive)
                _simulationThread.Abort();
        }

        private void PredvyplnVstupy()
        {
            inputAdmini.Text = _simulation.AgentRegistracie.DolnaHranicaPracovnikov.ToString();
            inputDoktori.Text = _simulation.AgentVysetrenia.DolnaHranicaPracovnikov.ToString();
            inputMaxDoktori.Text = _simulation.AgentVysetrenia.HornaHranicaPracovnikov.ToString();
            inputSestricky.Text = _simulation.AgentOckovania.DolnaHranicaPracovnikov.ToString();
            inputReplikacie.Text = _parametreSimulacie.Replikacie.ToString();
            inputPocetPacientov.Text = _parametreSimulacie.PocetPacientov.ToString();
            inputZavislostUpdate.Text = _parametreSimulacie.ReplikaciiNaUpdate.ToString();
            checkBoxSpecifickePrichody.Checked = _parametreSimulacie.SpecialnePrichody;
            checkBoxZavislost.Checked = _parametreSimulacie.ZobrazenieZavislosti;

            if (!checkBoxZavislost.Checked)
            {
                inputMaxDoktori.Enabled = false;
                inputZavislostUpdate.Enabled = false;
            }
                
        }

        private void AppGUI_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxSpecifickePrichody_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
