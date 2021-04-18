
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
            this.tabPacienti = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.tabulkaRegistracia = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsluhovanyPacientRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieRegistracia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabVysetrenie = new System.Windows.Forms.TabPage();
            this.vysetreniePanel = new System.Windows.Forms.Panel();
            this.tabulkaVysetrenie = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsluhovanyPacientVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieVysetrenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabOckovanie = new System.Windows.Forms.TabPage();
            this.ockovaniePanel = new System.Windows.Forms.Panel();
            this.tabulkaOckovanie = new System.Windows.Forms.DataGridView();
            this.cisloPracovnikaOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stavPracovnikaOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsluhovanyPacientOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pocetStriekaciekOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obedovalOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vytazenieOckovanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabZavislost = new System.Windows.Forms.TabPage();
            this.startStopButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabReplikacie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaReplikacie)).BeginInit();
            this.tabPacienti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaPacienti)).BeginInit();
            this.tabRegistracia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaRegistracia)).BeginInit();
            this.tabVysetrenie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaVysetrenie)).BeginInit();
            this.tabOckovanie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOckovanie)).BeginInit();
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
            this.tabControl1.Location = new System.Drawing.Point(-1, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1083, 595);
            this.tabControl1.TabIndex = 0;
            // 
            // tabReplikacie
            // 
            this.tabReplikacie.Controls.Add(this.tabulkaReplikacie);
            this.tabReplikacie.Location = new System.Drawing.Point(4, 25);
            this.tabReplikacie.Name = "tabReplikacie";
            this.tabReplikacie.Size = new System.Drawing.Size(1075, 566);
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
            this.hodnota});
            this.tabulkaReplikacie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabulkaReplikacie.Location = new System.Drawing.Point(0, 0);
            this.tabulkaReplikacie.Name = "tabulkaReplikacie";
            this.tabulkaReplikacie.ReadOnly = true;
            this.tabulkaReplikacie.RowHeadersVisible = false;
            this.tabulkaReplikacie.RowHeadersWidth = 51;
            this.tabulkaReplikacie.RowTemplate.Height = 24;
            this.tabulkaReplikacie.Size = new System.Drawing.Size(1075, 566);
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
            // tabPacienti
            // 
            this.tabPacienti.Controls.Add(this.panel2);
            this.tabPacienti.Controls.Add(this.tabulkaPacienti);
            this.tabPacienti.Location = new System.Drawing.Point(4, 25);
            this.tabPacienti.Name = "tabPacienti";
            this.tabPacienti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPacienti.Size = new System.Drawing.Size(1075, 566);
            this.tabPacienti.TabIndex = 0;
            this.tabPacienti.Text = "Pacienti";
            this.tabPacienti.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1069, 55);
            this.panel2.TabIndex = 3;
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
            this.tabulkaPacienti.Size = new System.Drawing.Size(1069, 501);
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
            // 
            // cakanieRegistracia
            // 
            this.cakanieRegistracia.HeaderText = "Čakanie - Registracia";
            this.cakanieRegistracia.MinimumWidth = 6;
            this.cakanieRegistracia.Name = "cakanieRegistracia";
            this.cakanieRegistracia.ReadOnly = true;
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
            this.tabRegistracia.Size = new System.Drawing.Size(1075, 566);
            this.tabRegistracia.TabIndex = 1;
            this.tabRegistracia.Text = "Registracia";
            this.tabRegistracia.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 55);
            this.panel1.TabIndex = 3;
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
            this.obsluhovanyPacientRegistracia,
            this.obedovalRegistracia,
            this.vytazenieRegistracia});
            this.tabulkaRegistracia.Location = new System.Drawing.Point(3, 64);
            this.tabulkaRegistracia.Name = "tabulkaRegistracia";
            this.tabulkaRegistracia.ReadOnly = true;
            this.tabulkaRegistracia.RowHeadersVisible = false;
            this.tabulkaRegistracia.RowHeadersWidth = 51;
            this.tabulkaRegistracia.RowTemplate.Height = 24;
            this.tabulkaRegistracia.Size = new System.Drawing.Size(1069, 502);
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
            // obsluhovanyPacientRegistracia
            // 
            this.obsluhovanyPacientRegistracia.HeaderText = "Obsluhovaný pacient";
            this.obsluhovanyPacientRegistracia.MinimumWidth = 6;
            this.obsluhovanyPacientRegistracia.Name = "obsluhovanyPacientRegistracia";
            this.obsluhovanyPacientRegistracia.ReadOnly = true;
            this.obsluhovanyPacientRegistracia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.tabVysetrenie.Size = new System.Drawing.Size(1075, 566);
            this.tabVysetrenie.TabIndex = 2;
            this.tabVysetrenie.Text = "Vysetrenie";
            this.tabVysetrenie.UseVisualStyleBackColor = true;
            // 
            // vysetreniePanel
            // 
            this.vysetreniePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.vysetreniePanel.Location = new System.Drawing.Point(0, 0);
            this.vysetreniePanel.Name = "vysetreniePanel";
            this.vysetreniePanel.Size = new System.Drawing.Size(1075, 55);
            this.vysetreniePanel.TabIndex = 3;
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
            this.obsluhovanyPacientVysetrenie,
            this.obedovalVysetrenie,
            this.vytazenieVysetrenie});
            this.tabulkaVysetrenie.Location = new System.Drawing.Point(3, 61);
            this.tabulkaVysetrenie.Name = "tabulkaVysetrenie";
            this.tabulkaVysetrenie.ReadOnly = true;
            this.tabulkaVysetrenie.RowHeadersVisible = false;
            this.tabulkaVysetrenie.RowHeadersWidth = 51;
            this.tabulkaVysetrenie.RowTemplate.Height = 24;
            this.tabulkaVysetrenie.Size = new System.Drawing.Size(1072, 505);
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
            // obsluhovanyPacientVysetrenie
            // 
            this.obsluhovanyPacientVysetrenie.HeaderText = "Obsluhovaný pacient";
            this.obsluhovanyPacientVysetrenie.MinimumWidth = 6;
            this.obsluhovanyPacientVysetrenie.Name = "obsluhovanyPacientVysetrenie";
            this.obsluhovanyPacientVysetrenie.ReadOnly = true;
            this.obsluhovanyPacientVysetrenie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // 
            // tabOckovanie
            // 
            this.tabOckovanie.Controls.Add(this.ockovaniePanel);
            this.tabOckovanie.Controls.Add(this.tabulkaOckovanie);
            this.tabOckovanie.Location = new System.Drawing.Point(4, 25);
            this.tabOckovanie.Name = "tabOckovanie";
            this.tabOckovanie.Size = new System.Drawing.Size(1075, 566);
            this.tabOckovanie.TabIndex = 3;
            this.tabOckovanie.Text = "Ockovanie";
            this.tabOckovanie.UseVisualStyleBackColor = true;
            // 
            // ockovaniePanel
            // 
            this.ockovaniePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ockovaniePanel.Location = new System.Drawing.Point(0, 0);
            this.ockovaniePanel.Name = "ockovaniePanel";
            this.ockovaniePanel.Size = new System.Drawing.Size(1075, 55);
            this.ockovaniePanel.TabIndex = 2;
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
            this.obsluhovanyPacientOckovanie,
            this.pocetStriekaciekOckovanie,
            this.obedovalOckovanie,
            this.vytazenieOckovanie});
            this.tabulkaOckovanie.Location = new System.Drawing.Point(3, 61);
            this.tabulkaOckovanie.Name = "tabulkaOckovanie";
            this.tabulkaOckovanie.ReadOnly = true;
            this.tabulkaOckovanie.RowHeadersVisible = false;
            this.tabulkaOckovanie.RowHeadersWidth = 51;
            this.tabulkaOckovanie.RowTemplate.Height = 24;
            this.tabulkaOckovanie.Size = new System.Drawing.Size(1072, 505);
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
            // obsluhovanyPacientOckovanie
            // 
            this.obsluhovanyPacientOckovanie.HeaderText = "Obsluhovaný pacient";
            this.obsluhovanyPacientOckovanie.MinimumWidth = 6;
            this.obsluhovanyPacientOckovanie.Name = "obsluhovanyPacientOckovanie";
            this.obsluhovanyPacientOckovanie.ReadOnly = true;
            this.obsluhovanyPacientOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pocetStriekaciekOckovanie
            // 
            this.pocetStriekaciekOckovanie.HeaderText = "Počet striekačiek";
            this.pocetStriekaciekOckovanie.MinimumWidth = 6;
            this.pocetStriekaciekOckovanie.Name = "pocetStriekaciekOckovanie";
            this.pocetStriekaciekOckovanie.ReadOnly = true;
            this.pocetStriekaciekOckovanie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // 
            // tabZavislost
            // 
            this.tabZavislost.Location = new System.Drawing.Point(4, 25);
            this.tabZavislost.Name = "tabZavislost";
            this.tabZavislost.Padding = new System.Windows.Forms.Padding(3);
            this.tabZavislost.Size = new System.Drawing.Size(1075, 566);
            this.tabZavislost.TabIndex = 4;
            this.tabZavislost.Text = "Zavislost";
            this.tabZavislost.UseVisualStyleBackColor = true;
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(14, 23);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(82, 32);
            this.startStopButton.TabIndex = 1;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // AppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 692);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "AppGUI";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabReplikacie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaReplikacie)).EndInit();
            this.tabPacienti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaPacienti)).EndInit();
            this.tabRegistracia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaRegistracia)).EndInit();
            this.tabVysetrenie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaVysetrenie)).EndInit();
            this.tabOckovanie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOckovanie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPacienti;
        private System.Windows.Forms.TabPage tabRegistracia;
        private System.Windows.Forms.TabPage tabVysetrenie;
        private System.Windows.Forms.TabPage tabOckovanie;
        private System.Windows.Forms.TabPage tabReplikacie;
        private System.Windows.Forms.DataGridView tabulkaReplikacie;
        private System.Windows.Forms.DataGridViewTextBoxColumn statistika;
        private System.Windows.Forms.DataGridViewTextBoxColumn hodnota;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tabulkaPacienti;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPacienta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cinnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn casPrichodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cakanieCakaren;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tabulkaRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsluhovanyPacientRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalRegistracia;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieRegistracia;
        private System.Windows.Forms.Panel vysetreniePanel;
        private System.Windows.Forms.DataGridView tabulkaVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsluhovanyPacientVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalVysetrenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieVysetrenie;
        private System.Windows.Forms.Panel ockovaniePanel;
        private System.Windows.Forms.DataGridView tabulkaOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn cisloPracovnikaOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn stavPracovnikaOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsluhovanyPacientOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn pocetStriekaciekOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn obedovalOckovanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn vytazenieOckovanie;
        private System.Windows.Forms.TabPage tabZavislost;
        private System.Windows.Forms.Button startStopButton;
    }
}

