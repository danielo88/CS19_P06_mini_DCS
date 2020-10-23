namespace CS19_P06_mini_DCS
{
	partial class Main
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_status = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_X = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_Y = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_czas = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem_Plik = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_otworz = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_zapisz = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_polacz = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_rozlacz = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_zamknij = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Edycja = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Pomoc = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_about = new System.Windows.Forms.ToolStripMenuItem();
			this.timer_1s = new System.Windows.Forms.Timer(this.components);
			this.tabControl_okna = new System.Windows.Forms.TabControl();
			this.tabPage_polaczenie = new System.Windows.Forms.TabPage();
			this.button_ustaw_wysylanie = new System.Windows.Forms.Button();
			this.button_wyczysc_wysylanie = new System.Windows.Forms.Button();
			this.button_ustaw_odbieranie = new System.Windows.Forms.Button();
			this.button_wyczysc_odbieranie = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_wysylanie_poczatek = new System.Windows.Forms.TextBox();
			this.textBox_wysylanie_liczba_danych = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox_odbieranie_poczatek = new System.Windows.Forms.TextBox();
			this.textBox_odbieranie_liczba_danych = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_id = new System.Windows.Forms.TextBox();
			this.textBox_port = new System.Windows.Forms.TextBox();
			this.textBox_adres_ip = new System.Windows.Forms.TextBox();
			this.label_ID = new System.Windows.Forms.Label();
			this.label_port = new System.Windows.Forms.Label();
			this.label_adres_ip = new System.Windows.Forms.Label();
			this.button_rozlacz_modbus = new System.Windows.Forms.Button();
			this.button_polacz_modbus = new System.Windows.Forms.Button();
			this.tabPage_mapa = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel_wysylanie = new System.Windows.Forms.Panel();
			this.panel_odbieranie = new System.Windows.Forms.Panel();
			this.tabPage_DCS = new System.Windows.Forms.TabPage();
			this.panel_scada = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.wlasciwosci_comboBox_format = new System.Windows.Forms.ComboBox();
			this.wlasciwosci_comboBox_wielkosc = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.wlasciwosci_textBox_bit = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.wlasciwosci_textBox_bajt = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.wlasciwosci_comboBox_typ = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.wlasciwosci_textBox_nazwa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button_kreska_poz = new System.Windows.Forms.Button();
			this.button_kreska_pion = new System.Windows.Forms.Button();
			this.button_pole_bajt = new System.Windows.Forms.Button();
			this.button_dodaj_bit = new System.Windows.Forms.Button();
			this.richTextBox_tekst = new System.Windows.Forms.RichTextBox();
			this.timer_client = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog_1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog_1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.tabControl_okna.SuspendLayout();
			this.tabPage_polaczenie.SuspendLayout();
			this.tabPage_mapa.SuspendLayout();
			this.tabPage_DCS.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_status,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_X,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel_Y,
            this.toolStripStatusLabel_czas});
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
			// 
			// toolStripStatusLabel2
			// 
			resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
			// 
			// toolStripStatusLabel_status
			// 
			resources.ApplyResources(this.toolStripStatusLabel_status, "toolStripStatusLabel_status");
			this.toolStripStatusLabel_status.Name = "toolStripStatusLabel_status";
			// 
			// toolStripStatusLabel5
			// 
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			resources.ApplyResources(this.toolStripStatusLabel5, "toolStripStatusLabel5");
			this.toolStripStatusLabel5.Spring = true;
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			resources.ApplyResources(this.toolStripStatusLabel4, "toolStripStatusLabel4");
			// 
			// toolStripStatusLabel_X
			// 
			resources.ApplyResources(this.toolStripStatusLabel_X, "toolStripStatusLabel_X");
			this.toolStripStatusLabel_X.Name = "toolStripStatusLabel_X";
			// 
			// toolStripStatusLabel7
			// 
			this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			resources.ApplyResources(this.toolStripStatusLabel7, "toolStripStatusLabel7");
			// 
			// toolStripStatusLabel_Y
			// 
			resources.ApplyResources(this.toolStripStatusLabel_Y, "toolStripStatusLabel_Y");
			this.toolStripStatusLabel_Y.Name = "toolStripStatusLabel_Y";
			// 
			// toolStripStatusLabel_czas
			// 
			resources.ApplyResources(this.toolStripStatusLabel_czas, "toolStripStatusLabel_czas");
			this.toolStripStatusLabel_czas.Name = "toolStripStatusLabel_czas";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Plik,
            this.toolStripMenuItem_Edycja,
            this.toolStripMenuItem_Pomoc});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// toolStripMenuItem_Plik
			// 
			this.toolStripMenuItem_Plik.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_otworz,
            this.toolStripMenuItem_zapisz,
            this.toolStripSeparator1,
            this.toolStripMenuItem_polacz,
            this.toolStripMenuItem_rozlacz,
            this.toolStripSeparator2,
            this.toolStripMenuItem_zamknij});
			this.toolStripMenuItem_Plik.Name = "toolStripMenuItem_Plik";
			resources.ApplyResources(this.toolStripMenuItem_Plik, "toolStripMenuItem_Plik");
			// 
			// toolStripMenuItem_otworz
			// 
			this.toolStripMenuItem_otworz.Name = "toolStripMenuItem_otworz";
			resources.ApplyResources(this.toolStripMenuItem_otworz, "toolStripMenuItem_otworz");
			this.toolStripMenuItem_otworz.Click += new System.EventHandler(this.toolStripMenuItem_otworz_Click);
			// 
			// toolStripMenuItem_zapisz
			// 
			this.toolStripMenuItem_zapisz.Name = "toolStripMenuItem_zapisz";
			resources.ApplyResources(this.toolStripMenuItem_zapisz, "toolStripMenuItem_zapisz");
			this.toolStripMenuItem_zapisz.Click += new System.EventHandler(this.toolStripMenuItem_zapisz_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// toolStripMenuItem_polacz
			// 
			this.toolStripMenuItem_polacz.Name = "toolStripMenuItem_polacz";
			resources.ApplyResources(this.toolStripMenuItem_polacz, "toolStripMenuItem_polacz");
			// 
			// toolStripMenuItem_rozlacz
			// 
			this.toolStripMenuItem_rozlacz.Name = "toolStripMenuItem_rozlacz";
			resources.ApplyResources(this.toolStripMenuItem_rozlacz, "toolStripMenuItem_rozlacz");
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// toolStripMenuItem_zamknij
			// 
			this.toolStripMenuItem_zamknij.Name = "toolStripMenuItem_zamknij";
			resources.ApplyResources(this.toolStripMenuItem_zamknij, "toolStripMenuItem_zamknij");
			this.toolStripMenuItem_zamknij.Click += new System.EventHandler(this.toolStripMenuItem_zamknij_Click);
			// 
			// toolStripMenuItem_Edycja
			// 
			this.toolStripMenuItem_Edycja.Name = "toolStripMenuItem_Edycja";
			resources.ApplyResources(this.toolStripMenuItem_Edycja, "toolStripMenuItem_Edycja");
			// 
			// toolStripMenuItem_Pomoc
			// 
			this.toolStripMenuItem_Pomoc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_about});
			this.toolStripMenuItem_Pomoc.Name = "toolStripMenuItem_Pomoc";
			resources.ApplyResources(this.toolStripMenuItem_Pomoc, "toolStripMenuItem_Pomoc");
			// 
			// toolStripMenuItem_about
			// 
			this.toolStripMenuItem_about.Name = "toolStripMenuItem_about";
			resources.ApplyResources(this.toolStripMenuItem_about, "toolStripMenuItem_about");
			// 
			// timer_1s
			// 
			this.timer_1s.Enabled = true;
			this.timer_1s.Interval = 1000;
			this.timer_1s.Tick += new System.EventHandler(this.timer_1s_Tick);
			// 
			// tabControl_okna
			// 
			resources.ApplyResources(this.tabControl_okna, "tabControl_okna");
			this.tabControl_okna.Controls.Add(this.tabPage_polaczenie);
			this.tabControl_okna.Controls.Add(this.tabPage_mapa);
			this.tabControl_okna.Controls.Add(this.tabPage_DCS);
			this.tabControl_okna.Name = "tabControl_okna";
			this.tabControl_okna.SelectedIndex = 0;
			// 
			// tabPage_polaczenie
			// 
			this.tabPage_polaczenie.Controls.Add(this.groupBox3);
			this.tabPage_polaczenie.Controls.Add(this.groupBox2);
			this.tabPage_polaczenie.Controls.Add(this.button_ustaw_wysylanie);
			this.tabPage_polaczenie.Controls.Add(this.button_wyczysc_wysylanie);
			this.tabPage_polaczenie.Controls.Add(this.button_ustaw_odbieranie);
			this.tabPage_polaczenie.Controls.Add(this.button_wyczysc_odbieranie);
			this.tabPage_polaczenie.Controls.Add(this.label9);
			this.tabPage_polaczenie.Controls.Add(this.label8);
			this.tabPage_polaczenie.Controls.Add(this.label6);
			this.tabPage_polaczenie.Controls.Add(this.textBox_wysylanie_poczatek);
			this.tabPage_polaczenie.Controls.Add(this.textBox_wysylanie_liczba_danych);
			this.tabPage_polaczenie.Controls.Add(this.label7);
			this.tabPage_polaczenie.Controls.Add(this.label5);
			this.tabPage_polaczenie.Controls.Add(this.textBox_odbieranie_poczatek);
			this.tabPage_polaczenie.Controls.Add(this.textBox_odbieranie_liczba_danych);
			this.tabPage_polaczenie.Controls.Add(this.label4);
			resources.ApplyResources(this.tabPage_polaczenie, "tabPage_polaczenie");
			this.tabPage_polaczenie.Name = "tabPage_polaczenie";
			this.tabPage_polaczenie.UseVisualStyleBackColor = true;
			// 
			// button_ustaw_wysylanie
			// 
			resources.ApplyResources(this.button_ustaw_wysylanie, "button_ustaw_wysylanie");
			this.button_ustaw_wysylanie.Name = "button_ustaw_wysylanie";
			this.button_ustaw_wysylanie.UseVisualStyleBackColor = true;
			this.button_ustaw_wysylanie.Click += new System.EventHandler(this.button_ustaw_wysylanie_Click);
			// 
			// button_wyczysc_wysylanie
			// 
			resources.ApplyResources(this.button_wyczysc_wysylanie, "button_wyczysc_wysylanie");
			this.button_wyczysc_wysylanie.Name = "button_wyczysc_wysylanie";
			this.button_wyczysc_wysylanie.UseVisualStyleBackColor = true;
			this.button_wyczysc_wysylanie.Click += new System.EventHandler(this.button_wyczysc_wysylanie_Click);
			// 
			// button_ustaw_odbieranie
			// 
			resources.ApplyResources(this.button_ustaw_odbieranie, "button_ustaw_odbieranie");
			this.button_ustaw_odbieranie.Name = "button_ustaw_odbieranie";
			this.button_ustaw_odbieranie.UseVisualStyleBackColor = true;
			this.button_ustaw_odbieranie.Click += new System.EventHandler(this.button_ustaw_odbieranie_Click);
			// 
			// button_wyczysc_odbieranie
			// 
			resources.ApplyResources(this.button_wyczysc_odbieranie, "button_wyczysc_odbieranie");
			this.button_wyczysc_odbieranie.Name = "button_wyczysc_odbieranie";
			this.button_wyczysc_odbieranie.UseVisualStyleBackColor = true;
			this.button_wyczysc_odbieranie.Click += new System.EventHandler(this.button_wyczysc_odbieranie_Click);
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// textBox_wysylanie_poczatek
			// 
			resources.ApplyResources(this.textBox_wysylanie_poczatek, "textBox_wysylanie_poczatek");
			this.textBox_wysylanie_poczatek.Name = "textBox_wysylanie_poczatek";
			// 
			// textBox_wysylanie_liczba_danych
			// 
			resources.ApplyResources(this.textBox_wysylanie_liczba_danych, "textBox_wysylanie_liczba_danych");
			this.textBox_wysylanie_liczba_danych.Name = "textBox_wysylanie_liczba_danych";
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// textBox_odbieranie_poczatek
			// 
			resources.ApplyResources(this.textBox_odbieranie_poczatek, "textBox_odbieranie_poczatek");
			this.textBox_odbieranie_poczatek.Name = "textBox_odbieranie_poczatek";
			// 
			// textBox_odbieranie_liczba_danych
			// 
			resources.ApplyResources(this.textBox_odbieranie_liczba_danych, "textBox_odbieranie_liczba_danych");
			this.textBox_odbieranie_liczba_danych.Name = "textBox_odbieranie_liczba_danych";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// textBox_id
			// 
			resources.ApplyResources(this.textBox_id, "textBox_id");
			this.textBox_id.Name = "textBox_id";
			// 
			// textBox_port
			// 
			resources.ApplyResources(this.textBox_port, "textBox_port");
			this.textBox_port.Name = "textBox_port";
			// 
			// textBox_adres_ip
			// 
			resources.ApplyResources(this.textBox_adres_ip, "textBox_adres_ip");
			this.textBox_adres_ip.Name = "textBox_adres_ip";
			// 
			// label_ID
			// 
			resources.ApplyResources(this.label_ID, "label_ID");
			this.label_ID.Name = "label_ID";
			// 
			// label_port
			// 
			resources.ApplyResources(this.label_port, "label_port");
			this.label_port.Name = "label_port";
			// 
			// label_adres_ip
			// 
			resources.ApplyResources(this.label_adres_ip, "label_adres_ip");
			this.label_adres_ip.Name = "label_adres_ip";
			// 
			// button_rozlacz_modbus
			// 
			resources.ApplyResources(this.button_rozlacz_modbus, "button_rozlacz_modbus");
			this.button_rozlacz_modbus.Name = "button_rozlacz_modbus";
			this.button_rozlacz_modbus.UseVisualStyleBackColor = true;
			this.button_rozlacz_modbus.Click += new System.EventHandler(this.button_rozlacz_modbus_Click);
			// 
			// button_polacz_modbus
			// 
			resources.ApplyResources(this.button_polacz_modbus, "button_polacz_modbus");
			this.button_polacz_modbus.Name = "button_polacz_modbus";
			this.button_polacz_modbus.UseVisualStyleBackColor = true;
			this.button_polacz_modbus.Click += new System.EventHandler(this.button_polacz_modbus_Click);
			// 
			// tabPage_mapa
			// 
			this.tabPage_mapa.Controls.Add(this.label2);
			this.tabPage_mapa.Controls.Add(this.label1);
			this.tabPage_mapa.Controls.Add(this.panel_wysylanie);
			this.tabPage_mapa.Controls.Add(this.panel_odbieranie);
			resources.ApplyResources(this.tabPage_mapa, "tabPage_mapa");
			this.tabPage_mapa.Name = "tabPage_mapa";
			this.tabPage_mapa.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// panel_wysylanie
			// 
			resources.ApplyResources(this.panel_wysylanie, "panel_wysylanie");
			this.panel_wysylanie.BackColor = System.Drawing.Color.Transparent;
			this.panel_wysylanie.Name = "panel_wysylanie";
			// 
			// panel_odbieranie
			// 
			resources.ApplyResources(this.panel_odbieranie, "panel_odbieranie");
			this.panel_odbieranie.BackColor = System.Drawing.Color.Transparent;
			this.panel_odbieranie.Name = "panel_odbieranie";
			// 
			// tabPage_DCS
			// 
			this.tabPage_DCS.Controls.Add(this.panel_scada);
			this.tabPage_DCS.Controls.Add(this.tabControl1);
			this.tabPage_DCS.Controls.Add(this.groupBox1);
			resources.ApplyResources(this.tabPage_DCS, "tabPage_DCS");
			this.tabPage_DCS.Name = "tabPage_DCS";
			this.tabPage_DCS.UseVisualStyleBackColor = true;
			// 
			// panel_scada
			// 
			resources.ApplyResources(this.panel_scada, "panel_scada");
			this.panel_scada.BackColor = System.Drawing.Color.LightGray;
			this.panel_scada.Name = "panel_scada";
			this.panel_scada.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_scada_MouseMove);
			this.panel_scada.MouseUp += new System.Windows.Forms.MouseEventHandler(this.kontrolka_scada_MouseDown);
			// 
			// tabControl1
			// 
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.wlasciwosci_comboBox_format);
			this.tabPage1.Controls.Add(this.wlasciwosci_comboBox_wielkosc);
			this.tabPage1.Controls.Add(this.label14);
			this.tabPage1.Controls.Add(this.wlasciwosci_textBox_bit);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.wlasciwosci_textBox_bajt);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.wlasciwosci_comboBox_typ);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.wlasciwosci_textBox_nazwa);
			this.tabPage1.Controls.Add(this.label3);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// wlasciwosci_comboBox_format
			// 
			this.wlasciwosci_comboBox_format.FormattingEnabled = true;
			this.wlasciwosci_comboBox_format.Items.AddRange(new object[] {
            resources.GetString("wlasciwosci_comboBox_format.Items"),
            resources.GetString("wlasciwosci_comboBox_format.Items1")});
			resources.ApplyResources(this.wlasciwosci_comboBox_format, "wlasciwosci_comboBox_format");
			this.wlasciwosci_comboBox_format.Name = "wlasciwosci_comboBox_format";
			this.wlasciwosci_comboBox_format.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_format_KeyPress);
			// 
			// wlasciwosci_comboBox_wielkosc
			// 
			this.wlasciwosci_comboBox_wielkosc.FormattingEnabled = true;
			this.wlasciwosci_comboBox_wielkosc.Items.AddRange(new object[] {
            resources.GetString("wlasciwosci_comboBox_wielkosc.Items"),
            resources.GetString("wlasciwosci_comboBox_wielkosc.Items1"),
            resources.GetString("wlasciwosci_comboBox_wielkosc.Items2"),
            resources.GetString("wlasciwosci_comboBox_wielkosc.Items3")});
			resources.ApplyResources(this.wlasciwosci_comboBox_wielkosc, "wlasciwosci_comboBox_wielkosc");
			this.wlasciwosci_comboBox_wielkosc.Name = "wlasciwosci_comboBox_wielkosc";
			this.wlasciwosci_comboBox_wielkosc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_wielkosc_KeyPress);
			// 
			// label14
			// 
			resources.ApplyResources(this.label14, "label14");
			this.label14.Name = "label14";
			// 
			// wlasciwosci_textBox_bit
			// 
			resources.ApplyResources(this.wlasciwosci_textBox_bit, "wlasciwosci_textBox_bit");
			this.wlasciwosci_textBox_bit.Name = "wlasciwosci_textBox_bit";
			this.wlasciwosci_textBox_bit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_bit_KeyPress);
			// 
			// label13
			// 
			resources.ApplyResources(this.label13, "label13");
			this.label13.Name = "label13";
			// 
			// label12
			// 
			resources.ApplyResources(this.label12, "label12");
			this.label12.Name = "label12";
			// 
			// wlasciwosci_textBox_bajt
			// 
			resources.ApplyResources(this.wlasciwosci_textBox_bajt, "wlasciwosci_textBox_bajt");
			this.wlasciwosci_textBox_bajt.Name = "wlasciwosci_textBox_bajt";
			this.wlasciwosci_textBox_bajt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_bajt_KeyPress);
			// 
			// label11
			// 
			resources.ApplyResources(this.label11, "label11");
			this.label11.Name = "label11";
			// 
			// wlasciwosci_comboBox_typ
			// 
			this.wlasciwosci_comboBox_typ.FormattingEnabled = true;
			this.wlasciwosci_comboBox_typ.Items.AddRange(new object[] {
            resources.GetString("wlasciwosci_comboBox_typ.Items"),
            resources.GetString("wlasciwosci_comboBox_typ.Items1")});
			resources.ApplyResources(this.wlasciwosci_comboBox_typ, "wlasciwosci_comboBox_typ");
			this.wlasciwosci_comboBox_typ.Name = "wlasciwosci_comboBox_typ";
			this.wlasciwosci_comboBox_typ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_typ_KeyPress);
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// wlasciwosci_textBox_nazwa
			// 
			resources.ApplyResources(this.wlasciwosci_textBox_nazwa, "wlasciwosci_textBox_nazwa");
			this.wlasciwosci_textBox_nazwa.Name = "wlasciwosci_textBox_nazwa";
			this.wlasciwosci_textBox_nazwa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wlasciwosci_nazwa_KeyPress);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// tabPage2
			// 
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.button_kreska_poz);
			this.groupBox1.Controls.Add(this.button_kreska_pion);
			this.groupBox1.Controls.Add(this.button_pole_bajt);
			this.groupBox1.Controls.Add(this.button_dodaj_bit);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button_kreska_poz
			// 
			resources.ApplyResources(this.button_kreska_poz, "button_kreska_poz");
			this.button_kreska_poz.Name = "button_kreska_poz";
			this.button_kreska_poz.UseVisualStyleBackColor = true;
			// 
			// button_kreska_pion
			// 
			resources.ApplyResources(this.button_kreska_pion, "button_kreska_pion");
			this.button_kreska_pion.Name = "button_kreska_pion";
			this.button_kreska_pion.UseVisualStyleBackColor = true;
			// 
			// button_pole_bajt
			// 
			resources.ApplyResources(this.button_pole_bajt, "button_pole_bajt");
			this.button_pole_bajt.Name = "button_pole_bajt";
			this.button_pole_bajt.UseVisualStyleBackColor = true;
			this.button_pole_bajt.Click += new System.EventHandler(this.button_pole_bajt_Click);
			// 
			// button_dodaj_bit
			// 
			resources.ApplyResources(this.button_dodaj_bit, "button_dodaj_bit");
			this.button_dodaj_bit.Name = "button_dodaj_bit";
			this.button_dodaj_bit.UseVisualStyleBackColor = true;
			this.button_dodaj_bit.Click += new System.EventHandler(this.button_dodaj_bit_Click);
			// 
			// richTextBox_tekst
			// 
			resources.ApplyResources(this.richTextBox_tekst, "richTextBox_tekst");
			this.richTextBox_tekst.BackColor = System.Drawing.SystemColors.Window;
			this.richTextBox_tekst.Name = "richTextBox_tekst";
			this.richTextBox_tekst.ReadOnly = true;
			// 
			// timer_client
			// 
			this.timer_client.Tick += new System.EventHandler(this.timer_client_Tick);
			// 
			// saveFileDialog_1
			// 
			resources.ApplyResources(this.saveFileDialog_1, "saveFileDialog_1");
			// 
			// openFileDialog_1
			// 
			this.openFileDialog_1.FileName = "openFileDialog1";
			resources.ApplyResources(this.openFileDialog_1, "openFileDialog_1");
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox_adres_ip);
			this.groupBox2.Controls.Add(this.button_polacz_modbus);
			this.groupBox2.Controls.Add(this.button_rozlacz_modbus);
			this.groupBox2.Controls.Add(this.label_adres_ip);
			this.groupBox2.Controls.Add(this.label_port);
			this.groupBox2.Controls.Add(this.label_ID);
			this.groupBox2.Controls.Add(this.textBox_port);
			this.groupBox2.Controls.Add(this.textBox_id);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// Main
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.richTextBox_tekst);
			this.Controls.Add(this.tabControl_okna);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl_okna.ResumeLayout(false);
			this.tabPage_polaczenie.ResumeLayout(false);
			this.tabPage_polaczenie.PerformLayout();
			this.tabPage_mapa.ResumeLayout(false);
			this.tabPage_mapa.PerformLayout();
			this.tabPage_DCS.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Plik;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edycja;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Pomoc;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_otworz;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zapisz;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_polacz;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_rozlacz;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_zamknij;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_about;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_status;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_czas;
		private System.Windows.Forms.Timer timer_1s;
		private System.Windows.Forms.TabControl tabControl_okna;
		private System.Windows.Forms.TabPage tabPage_polaczenie;
		private System.Windows.Forms.TabPage tabPage_mapa;
		private System.Windows.Forms.Button button_ustaw_wysylanie;
		private System.Windows.Forms.Button button_wyczysc_wysylanie;
		private System.Windows.Forms.Button button_ustaw_odbieranie;
		private System.Windows.Forms.Button button_wyczysc_odbieranie;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_wysylanie_poczatek;
		private System.Windows.Forms.TextBox textBox_wysylanie_liczba_danych;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox_odbieranie_poczatek;
		private System.Windows.Forms.TextBox textBox_odbieranie_liczba_danych;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_id;
		private System.Windows.Forms.TextBox textBox_port;
		private System.Windows.Forms.TextBox textBox_adres_ip;
		private System.Windows.Forms.Label label_ID;
		private System.Windows.Forms.Label label_port;
		private System.Windows.Forms.Label label_adres_ip;
		private System.Windows.Forms.Button button_rozlacz_modbus;
		private System.Windows.Forms.Button button_polacz_modbus;
		private System.Windows.Forms.TabPage tabPage_DCS;
		private System.Windows.Forms.Panel panel_wysylanie;
		private System.Windows.Forms.Panel panel_odbieranie;
		private System.Windows.Forms.RichTextBox richTextBox_tekst;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button_kreska_poz;
		private System.Windows.Forms.Button button_kreska_pion;
		private System.Windows.Forms.Button button_pole_bajt;
		private System.Windows.Forms.Button button_dodaj_bit;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ComboBox wlasciwosci_comboBox_format;
		private System.Windows.Forms.ComboBox wlasciwosci_comboBox_wielkosc;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox wlasciwosci_textBox_bit;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox wlasciwosci_textBox_bajt;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox wlasciwosci_comboBox_typ;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox wlasciwosci_textBox_nazwa;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Panel panel_scada;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_X;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Y;
		private System.Windows.Forms.Timer timer_client;
		private System.Windows.Forms.SaveFileDialog saveFileDialog_1;
		private System.Windows.Forms.OpenFileDialog openFileDialog_1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.HelpProvider helpProvider1;
	}
}

