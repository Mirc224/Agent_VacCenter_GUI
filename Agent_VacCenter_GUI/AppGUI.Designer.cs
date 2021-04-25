
namespace Agent_VacCenter_GUI
{
    partial class AppGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReplikacie = new System.Windows.Forms.TabPage();
            this.tabulkaReplikacie = new System.Windows.Forms.DataGridView();
            this.statistika = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hodnota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intervalySpolahlivostiReplikace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPacienti = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDobaCakaniaCakaren = new System.Windows.Forms.Label();
            this.labelLudiVCakarni = new System.Windows.Forms.Label();
            this.tabulkaPacienti = new System.Windows.Forms.DataGridView();
            this.idPacienta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinnost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.casPrichodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cakanieRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cakanieVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cakanieOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cakanieCakaren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabRegistracia = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelVytazenieRegistracia = new System.Windows.Forms.Label();
            this.labelDobaCakaniaRegistracia = new System.Windows.Forms.Label();
            this.labelDlzkaRaduRegistracia = new System.Windows.Forms.Label();
            this.tabulkaRegistracia = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabVysetrenie = new System.Windows.Forms.TabPage();
            this.vysetreniePanel = new System.Windows.Forms.Panel();
            this.labelVytazenieVysetrenie = new System.Windows.Forms.Label();
            this.labelDobaCakaniaVysetrenie = new System.Windows.Forms.Label();
            this.labelDlzkaRaduVysetrenie = new System.Windows.Forms.Label();
            this.tabulkaVysetrenie = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOckovanie = new System.Windows.Forms.TabPage();
            this.ockovaniePanel = new System.Windows.Forms.Panel();
            this.labelVytazenieOckovanie = new System.Windows.Forms.Label();
            this.labelDobaCakaniaOckovanie = new System.Windows.Forms.Label();
            this.labelDlzkaRaduOckovanie = new System.Windows.Forms.Label();
            this.tabulkaOckovanie = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetStriekaciekOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabZavislost = new System.Windows.Forms.TabPage();
            this.startPauseButton = new System.Windows.Forms.Button();
            this.casLabel = new System.Windows.Forms.Label();
            this.trackBarSlider = new System.Windows.Forms.TrackBar();
            this.maxRychlostCHB = new System.Windows.Forms.CheckBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxZavislost = new System.Windows.Forms.CheckBox();
            this.inputPocetPacientov = new System.Windows.Forms.TextBox();
            this.inputReplikacie = new System.Windows.Forms.TextBox();
            this.labelGuiUpdate = new System.Windows.Forms.Label();
            this.labelReplikacie = new System.Windows.Forms.Label();
            this.labelPocetObjednanych = new System.Windows.Forms.Label();
            this.labelMaxDoktori = new System.Windows.Forms.Label();
            this.checkBoxSpecifickePrichody = new System.Windows.Forms.CheckBox();
            this.labelSestricky = new System.Windows.Forms.Label();
            this.labelDoktori = new System.Windows.Forms.Label();
            this.labelAdmini = new System.Windows.Forms.Label();
            this.inputAdmini = new System.Windows.Forms.TextBox();
            this.inputDoktori = new System.Windows.Forms.TextBox();
            this.inputSestricky = new System.Windows.Forms.TextBox();
            this.inputMaxDoktori = new System.Windows.Forms.TextBox();
            this.inputZavislostUpdate = new System.Windows.Forms.TextBox();
            this.buttonPouziNastavenia = new System.Windows.Forms.Button();
            this.labelSeed = new System.Windows.Forms.Label();
            this.inputSeed = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSeed = new System.Windows.Forms.CheckBox();
            this.grafZavislosti = new OxyPlot.WindowsForms.PlotView();
            this.tabControl1.SuspendLayout();
            this.tabReplikacie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaReplikacie)).BeginInit();
            this.tabPacienti.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaPacienti)).BeginInit();
            this.tabRegistracia.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaRegistracia)).BeginInit();
            this.tabVysetrenie.SuspendLayout();
            this.vysetreniePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaVysetrenie)).BeginInit();
            this.tabOckovanie.SuspendLayout();
            this.ockovaniePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOckovanie)).BeginInit();
            this.tabZavislost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabReplikacie);
            this.tabControl1.Controls.Add(this.tabPacienti);
            this.tabControl1.Controls.Add(this.tabRegistracia);
            this.tabControl1.Controls.Add(this.tabVysetrenie);
            this.tabControl1.Controls.Add(this.tabOckovanie);
            this.tabControl1.Controls.Add(this.tabZavislost);
            this.tabControl1.Location = new System.Drawing.Point(9, 138);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1497, 705);
            this.tabControl1.TabIndex = 0;
            // 
            // tabReplikacie
            // 
            this.tabReplikacie.Controls.Add(this.tabulkaReplikacie);
            this.tabReplikacie.Location = new System.Drawing.Point(4, 25);
            this.tabReplikacie.Name = "tabReplikacie";
            this.tabReplikacie.Size = new System.Drawing.Size(1489, 676);
            this.tabReplikacie.TabIndex = 5;
            this.tabReplikacie.Text = "Replikacie";
            this.tabReplikacie.UseVisualStyleBackColor = true;
            // 
            // tabulkaReplikacie
            // 
            this.tabulkaReplikacie.AllowUserToAddRows = false;
            this.tabulkaReplikacie.AllowUserToDeleteRows = false;
            this.tabulkaReplikacie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaReplikacie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabulkaReplikacie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statistika,
            this.hodnota,
            this.intervalySpolahlivostiReplikace});
            this.tabulkaReplikacie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabulkaReplikacie.Location = new System.Drawing.Point(0, 0);
            this.tabulkaReplikacie.Name = "tabulkaReplikacie";
            this.tabulkaReplikacie.ReadOnly = true;
            this.tabulkaReplikacie.RowHeadersVisible = false;
            this.tabulkaReplikacie.RowHeadersWidth = 51;
            this.tabulkaReplikacie.RowTemplate.Height = 24;
            this.tabulkaReplikacie.Size = new System.Drawing.Size(1489, 676);
            this.tabulkaReplikacie.TabIndex = 0;
            // 
            // statistika
            // 
            this.statistika.HeaderText = "Štatistika";
            this.statistika.MinimumWidth = 6;
            this.statistika.Name = "statistika";
            this.statistika.ReadOnly = true;
            this.statistika.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // hodnota
            // 
            this.hodnota.HeaderText = "Hodnota";
            this.hodnota.MinimumWidth = 6;
            this.hodnota.Name = "hodnota";
            this.hodnota.ReadOnly = true;
            this.hodnota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // intervalySpolahlivostiReplikace
            // 
            this.intervalySpolahlivostiReplikace.HeaderText = "Intervaly spoľahlivosti";
            this.intervalySpolahlivostiReplikace.MinimumWidth = 6;
            this.intervalySpolahlivostiReplikace.Name = "intervalySpolahlivostiReplikace";
            this.intervalySpolahlivostiReplikace.ReadOnly = true;
            this.intervalySpolahlivostiReplikace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPacienti
            // 
            this.tabPacienti.Controls.Add(this.panel2);
            this.tabPacienti.Controls.Add(this.tabulkaPacienti);
            this.tabPacienti.Location = new System.Drawing.Point(4, 25);
            this.tabPacienti.Name = "tabPacienti";
            this.tabPacienti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPacienti.Size = new System.Drawing.Size(1489, 676);
            this.tabPacienti.TabIndex = 0;
            this.tabPacienti.Text = "Pacienti";
            this.tabPacienti.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDobaCakaniaCakaren);
            this.panel2.Controls.Add(this.labelLudiVCakarni);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1483, 55);
            this.panel2.TabIndex = 3;
            // 
            // labelDobaCakaniaCakaren
            // 
            this.labelDobaCakaniaCakaren.AutoSize = true;
            this.labelDobaCakaniaCakaren.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDobaCakaniaCakaren.Location = new System.Drawing.Point(615, 21);
            this.labelDobaCakaniaCakaren.Name = "labelDobaCakaniaCakaren";
            this.labelDobaCakaniaCakaren.Size = new System.Drawing.Size(203, 20);
            this.labelDobaCakaniaCakaren.TabIndex = 3;
            this.labelDobaCakaniaCakaren.Text = "Celková doba čakania: ";
            // 
            // labelLudiVCakarni
            // 
            this.labelLudiVCakarni.AutoSize = true;
            this.labelLudiVCakarni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLudiVCakarni.Location = new System.Drawing.Point(90, 21);
            this.labelLudiVCakarni.Name = "labelLudiVCakarni";
            this.labelLudiVCakarni.Size = new System.Drawing.Size(179, 20);
            this.labelLudiVCakarni.TabIndex = 2;
            this.labelLudiVCakarni.Text = "AVG ľudí v čakárni: ";
            // 
            // tabulkaPacienti
            // 
            this.tabulkaPacienti.AllowUserToAddRows = false;
            this.tabulkaPacienti.AllowUserToDeleteRows = false;
            this.tabulkaPacienti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabulkaPacienti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaPacienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabulkaPacienti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPacienta,
            this.cinnost,
            this.casPrichodu,
            this.cakanieRegistracia,
            this.cakanieVysetrenie,
            this.cakanieOckovanie,
            this.cakanieCakaren});
            this.tabulkaPacienti.Location = new System.Drawing.Point(3, 64);
            this.tabulkaPacienti.Name = "tabulkaPacienti";
            this.tabulkaPacienti.ReadOnly = true;
            this.tabulkaPacienti.RowHeadersVisible = false;
            this.tabulkaPacienti.RowHeadersWidth = 51;
            this.tabulkaPacienti.RowTemplate.Height = 24;
            this.tabulkaPacienti.Size = new System.Drawing.Size(1486, 609);
            this.tabulkaPacienti.TabIndex = 0;
            // 
            // idPacienta
            // 
            this.idPacienta.HeaderText = "IdPacienta";
            this.idPacienta.MinimumWidth = 6;
            this.idPacienta.Name = "idPacienta";
            this.idPacienta.ReadOnly = true;
            this.idPacienta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cinnost
            // 
            this.cinnost.HeaderText = "Činnosť";
            this.cinnost.MinimumWidth = 6;
            this.cinnost.Name = "cinnost";
            this.cinnost.ReadOnly = true;
            this.cinnost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // casPrichodu
            // 
            this.casPrichodu.HeaderText = "Čas príchodu";
            this.casPrichodu.MinimumWidth = 6;
            this.casPrichodu.Name = "casPrichodu";
            this.casPrichodu.ReadOnly = true;
            this.casPrichodu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cakanieRegistracia
            // 
            this.cakanieRegistracia.HeaderText = "Čakanie - Registracia";
            this.cakanieRegistracia.MinimumWidth = 6;
            this.cakanieRegistracia.Name = "cakanieRegistracia";
            this.cakanieRegistracia.ReadOnly = true;
            this.cakanieRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cakanieVysetrenie
            // 
            this.cakanieVysetrenie.HeaderText = "Čakanie - Vyšetrenie";
            this.cakanieVysetrenie.MinimumWidth = 6;
            this.cakanieVysetrenie.Name = "cakanieVysetrenie";
            this.cakanieVysetrenie.ReadOnly = true;
            this.cakanieVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cakanieOckovanie
            // 
            this.cakanieOckovanie.HeaderText = "Čakanie - Očkovanie";
            this.cakanieOckovanie.MinimumWidth = 6;
            this.cakanieOckovanie.Name = "cakanieOckovanie";
            this.cakanieOckovanie.ReadOnly = true;
            this.cakanieOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cakanieCakaren
            // 
            this.cakanieCakaren.HeaderText = "Čakanie - Čakáreň";
            this.cakanieCakaren.MinimumWidth = 6;
            this.cakanieCakaren.Name = "cakanieCakaren";
            this.cakanieCakaren.ReadOnly = true;
            this.cakanieCakaren.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabRegistracia
            // 
            this.tabRegistracia.Controls.Add(this.panel1);
            this.tabRegistracia.Controls.Add(this.tabulkaRegistracia);
            this.tabRegistracia.Location = new System.Drawing.Point(4, 25);
            this.tabRegistracia.Name = "tabRegistracia";
            this.tabRegistracia.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistracia.Size = new System.Drawing.Size(1489, 676);
            this.tabRegistracia.TabIndex = 1;
            this.tabRegistracia.Text = "Registracia";
            this.tabRegistracia.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelVytazenieRegistracia);
            this.panel1.Controls.Add(this.labelDobaCakaniaRegistracia);
            this.panel1.Controls.Add(this.labelDlzkaRaduRegistracia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1483, 55);
            this.panel1.TabIndex = 3;
            // 
            // labelVytazenieRegistracia
            // 
            this.labelVytazenieRegistracia.AutoSize = true;
            this.labelVytazenieRegistracia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVytazenieRegistracia.Location = new System.Drawing.Point(709, 18);
            this.labelVytazenieRegistracia.Name = "labelVytazenieRegistracia";
            this.labelVytazenieRegistracia.Size = new System.Drawing.Size(104, 20);
            this.labelVytazenieRegistracia.TabIndex = 2;
            this.labelVytazenieRegistracia.Text = "Vyťaženie: ";
            // 
            // labelDobaCakaniaRegistracia
            // 
            this.labelDobaCakaniaRegistracia.AutoSize = true;
            this.labelDobaCakaniaRegistracia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDobaCakaniaRegistracia.Location = new System.Drawing.Point(356, 18);
            this.labelDobaCakaniaRegistracia.Name = "labelDobaCakaniaRegistracia";
            this.labelDobaCakaniaRegistracia.Size = new System.Drawing.Size(135, 20);
            this.labelDobaCakaniaRegistracia.TabIndex = 1;
            this.labelDobaCakaniaRegistracia.Text = "Doba čakania: ";
            // 
            // labelDlzkaRaduRegistracia
            // 
            this.labelDlzkaRaduRegistracia.AutoSize = true;
            this.labelDlzkaRaduRegistracia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDlzkaRaduRegistracia.Location = new System.Drawing.Point(1, 18);
            this.labelDlzkaRaduRegistracia.Name = "labelDlzkaRaduRegistracia";
            this.labelDlzkaRaduRegistracia.Size = new System.Drawing.Size(112, 20);
            this.labelDlzkaRaduRegistracia.TabIndex = 0;
            this.labelDlzkaRaduRegistracia.Text = "Dĺžka radu: ";
            // 
            // tabulkaRegistracia
            // 
            this.tabulkaRegistracia.AllowUserToAddRows = false;
            this.tabulkaRegistracia.AllowUserToDeleteRows = false;
            this.tabulkaRegistracia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabulkaRegistracia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaRegistracia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabulkaRegistracia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cisloPracovnikaRegistracia,
            this.stavPracovnikaRegistracia,
            this.obedovalRegistracia,
            this.vytazenieRegistracia});
            this.tabulkaRegistracia.Location = new System.Drawing.Point(3, 64);
            this.tabulkaRegistracia.Name = "tabulkaRegistracia";
            this.tabulkaRegistracia.ReadOnly = true;
            this.tabulkaRegistracia.RowHeadersVisible = false;
            this.tabulkaRegistracia.RowHeadersWidth = 51;
            this.tabulkaRegistracia.RowTemplate.Height = 24;
            this.tabulkaRegistracia.Size = new System.Drawing.Size(1483, 616);
            this.tabulkaRegistracia.TabIndex = 0;
            // 
            // cisloPracovnikaRegistracia
            // 
            this.cisloPracovnikaRegistracia.HeaderText = "Číslo pracovníka";
            this.cisloPracovnikaRegistracia.MinimumWidth = 6;
            this.cisloPracovnikaRegistracia.Name = "cisloPracovnikaRegistracia";
            this.cisloPracovnikaRegistracia.ReadOnly = true;
            this.cisloPracovnikaRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // stavPracovnikaRegistracia
            // 
            this.stavPracovnikaRegistracia.HeaderText = "Stav";
            this.stavPracovnikaRegistracia.MinimumWidth = 6;
            this.stavPracovnikaRegistracia.Name = "stavPracovnikaRegistracia";
            this.stavPracovnikaRegistracia.ReadOnly = true;
            this.stavPracovnikaRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // obedovalRegistracia
            // 
            this.obedovalRegistracia.HeaderText = "Obedoval";
            this.obedovalRegistracia.MinimumWidth = 6;
            this.obedovalRegistracia.Name = "obedovalRegistracia";
            this.obedovalRegistracia.ReadOnly = true;
            this.obedovalRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vytazenieRegistracia
            // 
            this.vytazenieRegistracia.HeaderText = "Vyťaženie";
            this.vytazenieRegistracia.MinimumWidth = 6;
            this.vytazenieRegistracia.Name = "vytazenieRegistracia";
            this.vytazenieRegistracia.ReadOnly = true;
            this.vytazenieRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabVysetrenie
            // 
            this.tabVysetrenie.Controls.Add(this.vysetreniePanel);
            this.tabVysetrenie.Controls.Add(this.tabulkaVysetrenie);
            this.tabVysetrenie.Location = new System.Drawing.Point(4, 25);
            this.tabVysetrenie.Name = "tabVysetrenie";
            this.tabVysetrenie.Size = new System.Drawing.Size(1489, 676);
            this.tabVysetrenie.TabIndex = 2;
            this.tabVysetrenie.Text = "Vysetrenie";
            this.tabVysetrenie.UseVisualStyleBackColor = true;
            // 
            // vysetreniePanel
            // 
            this.vysetreniePanel.Controls.Add(this.labelVytazenieVysetrenie);
            this.vysetreniePanel.Controls.Add(this.labelDobaCakaniaVysetrenie);
            this.vysetreniePanel.Controls.Add(this.labelDlzkaRaduVysetrenie);
            this.vysetreniePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.vysetreniePanel.Location = new System.Drawing.Point(0, 0);
            this.vysetreniePanel.Name = "vysetreniePanel";
            this.vysetreniePanel.Size = new System.Drawing.Size(1489, 55);
            this.vysetreniePanel.TabIndex = 3;
            // 
            // labelVytazenieVysetrenie
            // 
            this.labelVytazenieVysetrenie.AutoSize = true;
            this.labelVytazenieVysetrenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVytazenieVysetrenie.Location = new System.Drawing.Point(707, 16);
            this.labelVytazenieVysetrenie.Name = "labelVytazenieVysetrenie";
            this.labelVytazenieVysetrenie.Size = new System.Drawing.Size(104, 20);
            this.labelVytazenieVysetrenie.TabIndex = 5;
            this.labelVytazenieVysetrenie.Text = "Vyťaženie: ";
            // 
            // labelDobaCakaniaVysetrenie
            // 
            this.labelDobaCakaniaVysetrenie.AutoSize = true;
            this.labelDobaCakaniaVysetrenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDobaCakaniaVysetrenie.Location = new System.Drawing.Point(359, 16);
            this.labelDobaCakaniaVysetrenie.Name = "labelDobaCakaniaVysetrenie";
            this.labelDobaCakaniaVysetrenie.Size = new System.Drawing.Size(135, 20);
            this.labelDobaCakaniaVysetrenie.TabIndex = 4;
            this.labelDobaCakaniaVysetrenie.Text = "Doba čakania: ";
            // 
            // labelDlzkaRaduVysetrenie
            // 
            this.labelDlzkaRaduVysetrenie.AutoSize = true;
            this.labelDlzkaRaduVysetrenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDlzkaRaduVysetrenie.Location = new System.Drawing.Point(3, 16);
            this.labelDlzkaRaduVysetrenie.Name = "labelDlzkaRaduVysetrenie";
            this.labelDlzkaRaduVysetrenie.Size = new System.Drawing.Size(112, 20);
            this.labelDlzkaRaduVysetrenie.TabIndex = 3;
            this.labelDlzkaRaduVysetrenie.Text = "Dĺžka radu: ";
            // 
            // tabulkaVysetrenie
            // 
            this.tabulkaVysetrenie.AllowUserToAddRows = false;
            this.tabulkaVysetrenie.AllowUserToDeleteRows = false;
            this.tabulkaVysetrenie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabulkaVysetrenie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaVysetrenie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabulkaVysetrenie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cisloPracovnikaVysetrenie,
            this.stavPracovnikaVysetrenie,
            this.obedovalVysetrenie,
            this.vytazenieVysetrenie});
            this.tabulkaVysetrenie.Location = new System.Drawing.Point(3, 61);
            this.tabulkaVysetrenie.Name = "tabulkaVysetrenie";
            this.tabulkaVysetrenie.ReadOnly = true;
            this.tabulkaVysetrenie.RowHeadersVisible = false;
            this.tabulkaVysetrenie.RowHeadersWidth = 51;
            this.tabulkaVysetrenie.RowTemplate.Height = 24;
            this.tabulkaVysetrenie.Size = new System.Drawing.Size(1483, 615);
            this.tabulkaVysetrenie.TabIndex = 1;
            // 
            // cisloPracovnikaVysetrenie
            // 
            this.cisloPracovnikaVysetrenie.HeaderText = "Číslo pracovníka";
            this.cisloPracovnikaVysetrenie.MinimumWidth = 6;
            this.cisloPracovnikaVysetrenie.Name = "cisloPracovnikaVysetrenie";
            this.cisloPracovnikaVysetrenie.ReadOnly = true;
            this.cisloPracovnikaVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // stavPracovnikaVysetrenie
            // 
            this.stavPracovnikaVysetrenie.HeaderText = "Stav";
            this.stavPracovnikaVysetrenie.MinimumWidth = 6;
            this.stavPracovnikaVysetrenie.Name = "stavPracovnikaVysetrenie";
            this.stavPracovnikaVysetrenie.ReadOnly = true;
            this.stavPracovnikaVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // obedovalVysetrenie
            // 
            this.obedovalVysetrenie.HeaderText = "Obedoval";
            this.obedovalVysetrenie.MinimumWidth = 6;
            this.obedovalVysetrenie.Name = "obedovalVysetrenie";
            this.obedovalVysetrenie.ReadOnly = true;
            this.obedovalVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vytazenieVysetrenie
            // 
            this.vytazenieVysetrenie.HeaderText = "Vyťaženie";
            this.vytazenieVysetrenie.MinimumWidth = 6;
            this.vytazenieVysetrenie.Name = "vytazenieVysetrenie";
            this.vytazenieVysetrenie.ReadOnly = true;
            this.vytazenieVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabOckovanie
            // 
            this.tabOckovanie.Controls.Add(this.ockovaniePanel);
            this.tabOckovanie.Controls.Add(this.tabulkaOckovanie);
            this.tabOckovanie.Location = new System.Drawing.Point(4, 25);
            this.tabOckovanie.Name = "tabOckovanie";
            this.tabOckovanie.Size = new System.Drawing.Size(1489, 676);
            this.tabOckovanie.TabIndex = 3;
            this.tabOckovanie.Text = "Ockovanie";
            this.tabOckovanie.UseVisualStyleBackColor = true;
            // 
            // ockovaniePanel
            // 
            this.ockovaniePanel.Controls.Add(this.labelVytazenieOckovanie);
            this.ockovaniePanel.Controls.Add(this.labelDobaCakaniaOckovanie);
            this.ockovaniePanel.Controls.Add(this.labelDlzkaRaduOckovanie);
            this.ockovaniePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ockovaniePanel.Location = new System.Drawing.Point(0, 0);
            this.ockovaniePanel.Name = "ockovaniePanel";
            this.ockovaniePanel.Size = new System.Drawing.Size(1489, 55);
            this.ockovaniePanel.TabIndex = 2;
            // 
            // labelVytazenieOckovanie
            // 
            this.labelVytazenieOckovanie.AutoSize = true;
            this.labelVytazenieOckovanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVytazenieOckovanie.Location = new System.Drawing.Point(752, 20);
            this.labelVytazenieOckovanie.Name = "labelVytazenieOckovanie";
            this.labelVytazenieOckovanie.Size = new System.Drawing.Size(104, 20);
            this.labelVytazenieOckovanie.TabIndex = 5;
            this.labelVytazenieOckovanie.Text = "Vyťaženie: ";
            // 
            // labelDobaCakaniaOckovanie
            // 
            this.labelDobaCakaniaOckovanie.AutoSize = true;
            this.labelDobaCakaniaOckovanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDobaCakaniaOckovanie.Location = new System.Drawing.Point(381, 20);
            this.labelDobaCakaniaOckovanie.Name = "labelDobaCakaniaOckovanie";
            this.labelDobaCakaniaOckovanie.Size = new System.Drawing.Size(135, 20);
            this.labelDobaCakaniaOckovanie.TabIndex = 4;
            this.labelDobaCakaniaOckovanie.Text = "Doba čakania: ";
            // 
            // labelDlzkaRaduOckovanie
            // 
            this.labelDlzkaRaduOckovanie.AutoSize = true;
            this.labelDlzkaRaduOckovanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDlzkaRaduOckovanie.Location = new System.Drawing.Point(5, 20);
            this.labelDlzkaRaduOckovanie.Name = "labelDlzkaRaduOckovanie";
            this.labelDlzkaRaduOckovanie.Size = new System.Drawing.Size(112, 20);
            this.labelDlzkaRaduOckovanie.TabIndex = 3;
            this.labelDlzkaRaduOckovanie.Text = "Dĺžka radu: ";
            // 
            // tabulkaOckovanie
            // 
            this.tabulkaOckovanie.AllowUserToAddRows = false;
            this.tabulkaOckovanie.AllowUserToDeleteRows = false;
            this.tabulkaOckovanie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabulkaOckovanie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaOckovanie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabulkaOckovanie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cisloPracovnikaOckovanie,
            this.stavPracovnikaOckovanie,
            this.obedovalOckovanie,
            this.vytazenieOckovanie,
            this.pocetStriekaciekOckovanie});
            this.tabulkaOckovanie.Location = new System.Drawing.Point(3, 61);
            this.tabulkaOckovanie.Name = "tabulkaOckovanie";
            this.tabulkaOckovanie.ReadOnly = true;
            this.tabulkaOckovanie.RowHeadersVisible = false;
            this.tabulkaOckovanie.RowHeadersWidth = 51;
            this.tabulkaOckovanie.RowTemplate.Height = 24;
            this.tabulkaOckovanie.Size = new System.Drawing.Size(1483, 612);
            this.tabulkaOckovanie.TabIndex = 1;
            // 
            // cisloPracovnikaOckovanie
            // 
            this.cisloPracovnikaOckovanie.HeaderText = "Číslo pracovníka";
            this.cisloPracovnikaOckovanie.MinimumWidth = 6;
            this.cisloPracovnikaOckovanie.Name = "cisloPracovnikaOckovanie";
            this.cisloPracovnikaOckovanie.ReadOnly = true;
            this.cisloPracovnikaOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // stavPracovnikaOckovanie
            // 
            this.stavPracovnikaOckovanie.HeaderText = "Stav";
            this.stavPracovnikaOckovanie.MinimumWidth = 6;
            this.stavPracovnikaOckovanie.Name = "stavPracovnikaOckovanie";
            this.stavPracovnikaOckovanie.ReadOnly = true;
            this.stavPracovnikaOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // obedovalOckovanie
            // 
            this.obedovalOckovanie.HeaderText = "Obedoval";
            this.obedovalOckovanie.MinimumWidth = 6;
            this.obedovalOckovanie.Name = "obedovalOckovanie";
            this.obedovalOckovanie.ReadOnly = true;
            this.obedovalOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vytazenieOckovanie
            // 
            this.vytazenieOckovanie.HeaderText = "Vyťaženie";
            this.vytazenieOckovanie.MinimumWidth = 6;
            this.vytazenieOckovanie.Name = "vytazenieOckovanie";
            this.vytazenieOckovanie.ReadOnly = true;
            this.vytazenieOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pocetStriekaciekOckovanie
            // 
            this.pocetStriekaciekOckovanie.HeaderText = "Počet striekačiek";
            this.pocetStriekaciekOckovanie.MinimumWidth = 6;
            this.pocetStriekaciekOckovanie.Name = "pocetStriekaciekOckovanie";
            this.pocetStriekaciekOckovanie.ReadOnly = true;
            this.pocetStriekaciekOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabZavislost
            // 
            this.tabZavislost.Controls.Add(this.grafZavislosti);
            this.tabZavislost.Location = new System.Drawing.Point(4, 25);
            this.tabZavislost.Name = "tabZavislost";
            this.tabZavislost.Padding = new System.Windows.Forms.Padding(3);
            this.tabZavislost.Size = new System.Drawing.Size(1489, 676);
            this.tabZavislost.TabIndex = 4;
            this.tabZavislost.Text = "Zavislost";
            this.tabZavislost.UseVisualStyleBackColor = true;
            // 
            // startPauseButton
            // 
            this.startPauseButton.Location = new System.Drawing.Point(9, 99);
            this.startPauseButton.Name = "startPauseButton";
            this.startPauseButton.Size = new System.Drawing.Size(82, 32);
            this.startPauseButton.TabIndex = 1;
            this.startPauseButton.Text = "Start";
            this.startPauseButton.UseVisualStyleBackColor = true;
            this.startPauseButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // casLabel
            // 
            this.casLabel.AutoSize = true;
            this.casLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.casLabel.Location = new System.Drawing.Point(1370, 45);
            this.casLabel.Name = "casLabel";
            this.casLabel.Size = new System.Drawing.Size(98, 25);
            this.casLabel.TabIndex = 2;
            this.casLabel.Text = "00:00:00";
            // 
            // trackBarSlider
            // 
            this.trackBarSlider.Location = new System.Drawing.Point(1313, 100);
            this.trackBarSlider.Name = "trackBarSlider";
            this.trackBarSlider.Size = new System.Drawing.Size(184, 56);
            this.trackBarSlider.TabIndex = 3;
            this.trackBarSlider.Scroll += new System.EventHandler(this.trackBarSlider_Scroll);
            // 
            // maxRychlostCHB
            // 
            this.maxRychlostCHB.AutoSize = true;
            this.maxRychlostCHB.Location = new System.Drawing.Point(1365, 73);
            this.maxRychlostCHB.Name = "maxRychlostCHB";
            this.maxRychlostCHB.Size = new System.Drawing.Size(113, 21);
            this.maxRychlostCHB.TabIndex = 4;
            this.maxRychlostCHB.Text = "Max. rýchlosť";
            this.maxRychlostCHB.UseVisualStyleBackColor = true;
            this.maxRychlostCHB.CheckedChanged += new System.EventHandler(this.maxRychlostCHB_CheckedChanged);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(97, 99);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(82, 32);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAutoSeed, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputSeed, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelSeed, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxZavislost, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.inputPocetPacientov, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputReplikacie, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelGuiUpdate, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelReplikacie, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelPocetObjednanych, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxDoktori, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSpecifickePrichody, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSestricky, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDoktori, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAdmini, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputAdmini, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputDoktori, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputSestricky, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputMaxDoktori, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputZavislostUpdate, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1251, 84);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // checkBoxZavislost
            // 
            this.checkBoxZavislost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxZavislost.AutoSize = true;
            this.checkBoxZavislost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxZavislost.Location = new System.Drawing.Point(627, 59);
            this.checkBoxZavislost.Name = "checkBoxZavislost";
            this.checkBoxZavislost.Size = new System.Drawing.Size(150, 22);
            this.checkBoxZavislost.TabIndex = 15;
            this.checkBoxZavislost.Text = "Závislosti";
            this.checkBoxZavislost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxZavislost.UseVisualStyleBackColor = true;
            this.checkBoxZavislost.CheckedChanged += new System.EventHandler(this.checkBoxZavislost_CheckedChanged);
            // 
            // inputPocetPacientov
            // 
            this.inputPocetPacientov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPocetPacientov.Location = new System.Drawing.Point(471, 31);
            this.inputPocetPacientov.Name = "inputPocetPacientov";
            this.inputPocetPacientov.Size = new System.Drawing.Size(150, 22);
            this.inputPocetPacientov.TabIndex = 13;
            // 
            // inputReplikacie
            // 
            this.inputReplikacie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputReplikacie.Location = new System.Drawing.Point(159, 31);
            this.inputReplikacie.Name = "inputReplikacie";
            this.inputReplikacie.Size = new System.Drawing.Size(150, 22);
            this.inputReplikacie.TabIndex = 12;
            // 
            // labelGuiUpdate
            // 
            this.labelGuiUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGuiUpdate.AutoSize = true;
            this.labelGuiUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGuiUpdate.Location = new System.Drawing.Point(627, 28);
            this.labelGuiUpdate.Name = "labelGuiUpdate";
            this.labelGuiUpdate.Size = new System.Drawing.Size(150, 28);
            this.labelGuiUpdate.TabIndex = 10;
            this.labelGuiUpdate.Text = "Bod závislosti:";
            this.labelGuiUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelReplikacie
            // 
            this.labelReplikacie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReplikacie.AutoSize = true;
            this.labelReplikacie.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelReplikacie.Location = new System.Drawing.Point(3, 28);
            this.labelReplikacie.Name = "labelReplikacie";
            this.labelReplikacie.Size = new System.Drawing.Size(150, 28);
            this.labelReplikacie.TabIndex = 9;
            this.labelReplikacie.Text = "Replikácie:";
            this.labelReplikacie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPocetObjednanych
            // 
            this.labelPocetObjednanych.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPocetObjednanych.AutoSize = true;
            this.labelPocetObjednanych.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPocetObjednanych.Location = new System.Drawing.Point(315, 28);
            this.labelPocetObjednanych.Name = "labelPocetObjednanych";
            this.labelPocetObjednanych.Size = new System.Drawing.Size(150, 28);
            this.labelPocetObjednanych.TabIndex = 8;
            this.labelPocetObjednanych.Text = "Počet pacientov:";
            this.labelPocetObjednanych.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaxDoktori
            // 
            this.labelMaxDoktori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxDoktori.AutoSize = true;
            this.labelMaxDoktori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMaxDoktori.Location = new System.Drawing.Point(627, 0);
            this.labelMaxDoktori.Name = "labelMaxDoktori";
            this.labelMaxDoktori.Size = new System.Drawing.Size(150, 28);
            this.labelMaxDoktori.TabIndex = 7;
            this.labelMaxDoktori.Text = "Max doktori:";
            this.labelMaxDoktori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxSpecifickePrichody
            // 
            this.checkBoxSpecifickePrichody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSpecifickePrichody.AutoSize = true;
            this.checkBoxSpecifickePrichody.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSpecifickePrichody.Location = new System.Drawing.Point(315, 59);
            this.checkBoxSpecifickePrichody.Name = "checkBoxSpecifickePrichody";
            this.checkBoxSpecifickePrichody.Size = new System.Drawing.Size(150, 22);
            this.checkBoxSpecifickePrichody.TabIndex = 14;
            this.checkBoxSpecifickePrichody.Text = "Skoršie príchody";
            this.checkBoxSpecifickePrichody.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSpecifickePrichody.UseVisualStyleBackColor = true;
            this.checkBoxSpecifickePrichody.CheckedChanged += new System.EventHandler(this.checkBoxSpecifickePrichody_CheckedChanged);
            // 
            // labelSestricky
            // 
            this.labelSestricky.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSestricky.AutoSize = true;
            this.labelSestricky.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSestricky.Location = new System.Drawing.Point(939, 0);
            this.labelSestricky.Name = "labelSestricky";
            this.labelSestricky.Size = new System.Drawing.Size(150, 28);
            this.labelSestricky.TabIndex = 2;
            this.labelSestricky.Text = "Sestričky:";
            this.labelSestricky.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDoktori
            // 
            this.labelDoktori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDoktori.AutoSize = true;
            this.labelDoktori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDoktori.Location = new System.Drawing.Point(315, 0);
            this.labelDoktori.Name = "labelDoktori";
            this.labelDoktori.Size = new System.Drawing.Size(150, 28);
            this.labelDoktori.TabIndex = 1;
            this.labelDoktori.Text = "Doktori:";
            this.labelDoktori.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAdmini
            // 
            this.labelAdmini.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdmini.AutoSize = true;
            this.labelAdmini.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAdmini.Location = new System.Drawing.Point(3, 0);
            this.labelAdmini.Name = "labelAdmini";
            this.labelAdmini.Size = new System.Drawing.Size(150, 28);
            this.labelAdmini.TabIndex = 0;
            this.labelAdmini.Text = "Admin:";
            this.labelAdmini.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputAdmini
            // 
            this.inputAdmini.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputAdmini.Location = new System.Drawing.Point(159, 3);
            this.inputAdmini.Name = "inputAdmini";
            this.inputAdmini.Size = new System.Drawing.Size(150, 22);
            this.inputAdmini.TabIndex = 3;
            // 
            // inputDoktori
            // 
            this.inputDoktori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDoktori.Location = new System.Drawing.Point(471, 3);
            this.inputDoktori.Name = "inputDoktori";
            this.inputDoktori.Size = new System.Drawing.Size(150, 22);
            this.inputDoktori.TabIndex = 4;
            // 
            // inputSestricky
            // 
            this.inputSestricky.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSestricky.Location = new System.Drawing.Point(1095, 3);
            this.inputSestricky.Name = "inputSestricky";
            this.inputSestricky.Size = new System.Drawing.Size(153, 22);
            this.inputSestricky.TabIndex = 5;
            // 
            // inputMaxDoktori
            // 
            this.inputMaxDoktori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputMaxDoktori.Location = new System.Drawing.Point(783, 3);
            this.inputMaxDoktori.Name = "inputMaxDoktori";
            this.inputMaxDoktori.Size = new System.Drawing.Size(150, 22);
            this.inputMaxDoktori.TabIndex = 6;
            // 
            // inputZavislostUpdate
            // 
            this.inputZavislostUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputZavislostUpdate.Location = new System.Drawing.Point(783, 31);
            this.inputZavislostUpdate.Name = "inputZavislostUpdate";
            this.inputZavislostUpdate.Size = new System.Drawing.Size(150, 22);
            this.inputZavislostUpdate.TabIndex = 11;
            // 
            // buttonPouziNastavenia
            // 
            this.buttonPouziNastavenia.Location = new System.Drawing.Point(1177, 100);
            this.buttonPouziNastavenia.Name = "buttonPouziNastavenia";
            this.buttonPouziNastavenia.Size = new System.Drawing.Size(82, 32);
            this.buttonPouziNastavenia.TabIndex = 7;
            this.buttonPouziNastavenia.Text = "Aplikuj";
            this.buttonPouziNastavenia.UseVisualStyleBackColor = true;
            this.buttonPouziNastavenia.Click += new System.EventHandler(this.buttonPouziNastavenia_Click);
            // 
            // labelSeed
            // 
            this.labelSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSeed.AutoSize = true;
            this.labelSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSeed.Location = new System.Drawing.Point(939, 28);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(150, 28);
            this.labelSeed.TabIndex = 16;
            this.labelSeed.Text = "Seed:";
            this.labelSeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputSeed
            // 
            this.inputSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputSeed.Location = new System.Drawing.Point(1095, 31);
            this.inputSeed.Name = "inputSeed";
            this.inputSeed.Size = new System.Drawing.Size(153, 22);
            this.inputSeed.TabIndex = 17;
            // 
            // checkBoxAutoSeed
            // 
            this.checkBoxAutoSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoSeed.AutoSize = true;
            this.checkBoxAutoSeed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoSeed.Location = new System.Drawing.Point(939, 59);
            this.checkBoxAutoSeed.Name = "checkBoxAutoSeed";
            this.checkBoxAutoSeed.Size = new System.Drawing.Size(150, 22);
            this.checkBoxAutoSeed.TabIndex = 18;
            this.checkBoxAutoSeed.Text = "AutoSeed";
            this.checkBoxAutoSeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAutoSeed.UseVisualStyleBackColor = true;
            // 
            // grafZavislosti
            // 
            this.grafZavislosti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafZavislosti.Location = new System.Drawing.Point(-4, -1);
            this.grafZavislosti.Name = "grafZavislosti";
            this.grafZavislosti.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.grafZavislosti.Size = new System.Drawing.Size(1493, 681);
            this.grafZavislosti.TabIndex = 0;
            this.grafZavislosti.Text = "plotView1";
            this.grafZavislosti.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.grafZavislosti.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.grafZavislosti.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 845);
            this.Controls.Add(this.buttonPouziNastavenia);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.maxRychlostCHB);
            this.Controls.Add(this.trackBarSlider);
            this.Controls.Add(this.casLabel);
            this.Controls.Add(this.startPauseButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "AppGUI";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppGUI_FormClosed);
            this.Load += new System.EventHandler(this.AppGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabReplikacie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaReplikacie)).EndInit();
            this.tabPacienti.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaPacienti)).EndInit();
            this.tabRegistracia.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaRegistracia)).EndInit();
            this.tabVysetrenie.ResumeLayout(false);
            this.vysetreniePanel.ResumeLayout(false);
            this.vysetreniePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaVysetrenie)).EndInit();
            this.tabOckovanie.ResumeLayout(false);
            this.ockovaniePanel.ResumeLayout(false);
            this.ockovaniePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOckovanie)).EndInit();
            this.tabZavislost.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPacienti;
        private System.Windows.Forms.TabPage tabRegistracia;
        private System.Windows.Forms.TabPage tabVysetrenie;
        private System.Windows.Forms.TabPage tabOckovanie;
        private System.Windows.Forms.TabPage tabReplikacie;
        private System.Windows.Forms.DataGridView tabulkaReplikacie;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tabulkaPacienti;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tabulkaRegistracia;
        private System.Windows.Forms.Panel vysetreniePanel;
        private System.Windows.Forms.DataGridView tabulkaVysetrenie;
        private System.Windows.Forms.Panel ockovaniePanel;
        private System.Windows.Forms.DataGridView tabulkaOckovanie;
        private System.Windows.Forms.TabPage tabZavislost;
        private System.Windows.Forms.Button startPauseButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieRegistracia;
        private System.Windows.Forms.Label casLabel;
        private System.Windows.Forms.TrackBar trackBarSlider;
        private System.Windows.Forms.CheckBox maxRychlostCHB;
        private System.Windows.Forms.DataGridViewTextBoxColumn statistika;
        private System.Windows.Forms.DataGridViewTextBoxColumn hodnota;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalySpolahlivostiReplikace;
        private System.Windows.Forms.Label labelVytazenieRegistracia;
        private System.Windows.Forms.Label labelDobaCakaniaRegistracia;
        private System.Windows.Forms.Label labelDlzkaRaduRegistracia;
        private System.Windows.Forms.Label labelVytazenieVysetrenie;
        private System.Windows.Forms.Label labelDobaCakaniaVysetrenie;
        private System.Windows.Forms.Label labelDlzkaRaduVysetrenie;
        private System.Windows.Forms.Label labelVytazenieOckovanie;
        private System.Windows.Forms.Label labelDobaCakaniaOckovanie;
        private System.Windows.Forms.Label labelDlzkaRaduOckovanie;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label labelDobaCakaniaCakaren;
        private System.Windows.Forms.Label labelLudiVCakarni;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxZavislost;
        private System.Windows.Forms.TextBox inputPocetPacientov;
        private System.Windows.Forms.TextBox inputReplikacie;
        private System.Windows.Forms.Label labelGuiUpdate;
        private System.Windows.Forms.Label labelReplikacie;
        private System.Windows.Forms.Label labelPocetObjednanych;
        private System.Windows.Forms.Label labelMaxDoktori;
        private System.Windows.Forms.Label labelSestricky;
        private System.Windows.Forms.Label labelDoktori;
        private System.Windows.Forms.Label labelAdmini;
        private System.Windows.Forms.TextBox inputAdmini;
        private System.Windows.Forms.TextBox inputDoktori;
        private System.Windows.Forms.TextBox inputSestricky;
        private System.Windows.Forms.TextBox inputMaxDoktori;
        private System.Windows.Forms.TextBox inputZavislostUpdate;
        private System.Windows.Forms.CheckBox checkBoxSpecifickePrichody;
        private System.Windows.Forms.Button buttonPouziNastavenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacienta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cinnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn casPrichodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieCakaren;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetStriekaciekOckovanie;
        private OxyPlot.WindowsForms.PlotView grafZavislosti;
        private System.Windows.Forms.CheckBox checkBoxAutoSeed;
        private System.Windows.Forms.TextBox inputSeed;
        private System.Windows.Forms.Label labelSeed;
    }
}

