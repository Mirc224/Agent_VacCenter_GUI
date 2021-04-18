using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agent_VacCenter_GUI
{
    public partial class AppGUI : Form
    {
        private simulation.VacCenterSimulation _simulation;
        public AppGUI()
        {
            _simulation = new simulation.VacCenterSimulation(this);
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

        private void startStopButton_Click(object sender, EventArgs e)
        {
            var replikacie = 4;
            //var casReplikacie = 540 * 60;
            var casReplikacie = 540 * 600;

            _simulation.Simulate(replikacie, casReplikacie);
        }
    }
}
