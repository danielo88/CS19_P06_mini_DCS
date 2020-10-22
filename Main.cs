﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace CS19_P06_mini_DCS
{
	public partial class Main : Form
	{
		//zmienne

		string adres_ip;// = new string();
		int liczba_komorek_wysylanie = 0;
		int liczba_komorek_odbieranie = 0;
		int szerokosc_komorki = 60;
		int ilosc_wierszy = 10;
		int port;
		int dawaj = 0;
		int nowe = 0;
		int nr_mouse_enter;
		bool server_client = false; //0 gdy server, 1 gdy client
		UInt32 odbieranie_ilosc_danych = 1;
		object send_mouse_click, send_mouse_enter;
		Int32 from_cells_copy; //z której komórki ma kopiować
		bool przepisz = false;//czy aktywne jest przepisywanie
		int aktywuj_czas_potwierdzenia = 0; //jeżeli podczas zmiany nastawy nie zostanie wciśnięty enter to po ustawionym czasie automatycznie zostanie to potwierdzone

		Color color_textbox_background = Color.White;
		Color color_textbox_text = Color.Black;

		struct liczydlo
		{
			public object cells;
			public Int32 nr;
			public bool active;
			public Color background;
			public Color text;
			public Int32 send_to;  //wartosc komórki jest przepisywane do
			public bool przepisz_komorki;   //czy jest aktywne przepisywanie
			public bool nastawa;            //czy jest aktywna zmiana nastawy
			public bool zmiana_nastawy;     //czy nastąpiła zmiana nastawy
		}

		//tablica dynamiczn
		liczydlo[] licz_odbieranie;
		liczydlo[] licz_wysylanie;

		enum MyEnum
		{
			_bit=0,
			_bajt=8,
			_word=16,
			_dword_32,
			_qword=64
		}

		struct scada
		{
			public object obiekt;           //wskaźnik do obiektu
			public object opis;             //wskaźnik do opisy (label)
			public object kontrolka;        //wskaźnik do przycisku lub textboxa
			public string opis_text;
			public Int32 nr_obiektu;		//nr porządkowy obiektu
			public Int32 pozycja_x;			//pozycja x na ekranie
			public Int32 pozycja_y;         //pozycja y na ekranie
			public Int32 typ;				//0-wejście (z plc) czy 1-wyjście (do plc)
			public Int32 adres_bajt;		//który adres w mapie modbus (word)
			public Int32 adres_bit;			//od 0 do 15
			public Int32 wielkosc;          //0=bit, 1-bajt, 2-word, 3-dword, 4-qword
			public Int32 format;			//0-bigendian 1-litendiand
		}

		scada[] ekran_scada = new scada[100];
		Int32 scada_nr=0;

		object kontrolka_zmiana;
		Int32 kontrolka_nr_parametry;

		EasyModbus.ModbusServer modbus_server;
		EasyModbus.ModbusClient modbus_client;

		public Main()
		{
			InitializeComponent();
		}

		//wybranie danej kontrolki w celu m.in. określenia ich właściwości
		private void kontrolka_parametry_MouseDown(object sender, MouseEventArgs e)
		{
			if(sender.GetType() == typeof(Label))
			{
				string[] podzial = (sender as Label).Name.Split('_');
				kontrolka_nr_parametry = Convert.ToInt32(podzial[2]);

			}else if (sender.GetType() == typeof(Button))
			{
				string[] podzial = (sender as Button).Name.Split('_');
				kontrolka_nr_parametry = Convert.ToInt32(podzial[2]);

			}
			else if (sender.GetType() == typeof(TextBox))
			{
				string[] podzial = (sender as TextBox).Name.Split('_');
				kontrolka_nr_parametry = Convert.ToInt32(podzial[2]);
				
			}


			wlasciwosci_textBox_nazwa.Text = (ekran_scada[kontrolka_nr_parametry].opis as Label).Text;
			
			wlasciwosci_textBox_bajt.Text = ekran_scada[kontrolka_nr_parametry].adres_bajt.ToString();
			
			if (ekran_scada[kontrolka_nr_parametry].wielkosc == 0)
			{
				wlasciwosci_textBox_bit.Enabled = true;
				wlasciwosci_comboBox_wielkosc.Enabled = false;
				wlasciwosci_comboBox_format.Enabled = false;
				wlasciwosci_textBox_bit.Text = ekran_scada[kontrolka_nr_parametry].adres_bit.ToString();
				wlasciwosci_comboBox_wielkosc.SelectedItem = null;
				wlasciwosci_comboBox_format.SelectedItem = null;

			}
			else
			{
				wlasciwosci_textBox_bit.Enabled = false;
				wlasciwosci_comboBox_wielkosc.Enabled = true;
				wlasciwosci_comboBox_format.Enabled = true;
				wlasciwosci_textBox_bit.Text = "";
				wlasciwosci_comboBox_wielkosc.SelectedIndex = ekran_scada[kontrolka_nr_parametry].wielkosc-1;
				wlasciwosci_comboBox_format.SelectedIndex = ekran_scada[kontrolka_nr_parametry].format;

			}

			wlasciwosci_comboBox_typ.SelectedIndex = ekran_scada[kontrolka_nr_parametry].typ;



		}
		private void zmiana_bit_kontrolki(object sender, MouseEventArgs e)
		{
			if(ekran_scada[kontrolka_nr_parametry].typ == 1)
				(sender as Button).Text = (sender as Button).Text == "0" ? "1" : "0";
		}

		private void kontrolka_scada_MouseDown(object sender, MouseEventArgs e)
		{
			/*if(e.Button == MouseButtons.Right)
			{
				if (sender.GetType() != typeof(Panel))
				{
					if (kontrolka_zmiana == null)
					{
						kontrolka_zmiana = sender;
						if (kontrolka_zmiana.GetType() == typeof(TextBox))
						{
							(kontrolka_zmiana as TextBox).Enabled = false;
						}
						else if (kontrolka_zmiana.GetType() == typeof(Button))
						{
							(kontrolka_zmiana as Button).Enabled = false;
						}

					}
				}
				else if (kontrolka_zmiana != null)
				{

					if (kontrolka_zmiana.GetType() == typeof(TextBox))
					{
						(kontrolka_zmiana as TextBox).Enabled = true;
					}
					else if (kontrolka_zmiana.GetType() == typeof(Button))
					{
						(kontrolka_zmiana as Button).Enabled = true;
					}
					kontrolka_zmiana = null;
				}
			}*/

			if (e.Button == MouseButtons.Right)
			{
				if (sender.GetType() != typeof(Panel))
				{
					if (kontrolka_zmiana == null)
					{
						Int32 nr_temp = 0;
						if (sender.GetType() == typeof(TextBox))
						{
							string[] podzial = (sender as TextBox).Name.Split('_');
							nr_temp = Convert.ToInt32(podzial[2]);
						}
						else if (sender.GetType() == typeof(Button))
						{
							string[] podzial = (sender as Button).Name.Split('_');
							nr_temp = Convert.ToInt32(podzial[2]);
						}
							

						kontrolka_zmiana = ekran_scada[nr_temp].obiekt;
						kontrolka_nr_parametry = nr_temp;

						(kontrolka_zmiana as Panel).Enabled = false;

					}
				}else if (kontrolka_zmiana != null)
				{
					(kontrolka_zmiana as Panel).Enabled = true;
					kontrolka_zmiana = null;
					ekran_scada[kontrolka_nr_parametry].pozycja_x = Convert.ToInt32(toolStripStatusLabel_X.Text);
					ekran_scada[kontrolka_nr_parametry].pozycja_y = Convert.ToInt32(toolStripStatusLabel_Y.Text);
				}
			}
		}

		private void timer_1s_Tick(object sender, EventArgs e)
		{
			System.DateTime now = DateTime.Now;

			Int32 sekundy = now.Second;

			string znak = "|";
			Int32 sek_mod = sekundy % 2;

			switch (sek_mod)
			{
				case 0:
					znak = "|";
					break;
				case 1:
					znak = "-";
					break;
				default:
					break;
			}

			string minuty = now.Minute.ToString();

			toolStripStatusLabel_czas.Text = now.Hour.ToString() + ":";
			if(now.Minute <= 9)
			{
				toolStripStatusLabel_czas.Text = toolStripStatusLabel_czas.Text + "0"+ now.Minute.ToString() + " " + znak + " " + now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString() + " ";

			}else
				toolStripStatusLabel_czas.Text = toolStripStatusLabel_czas.Text + now.Minute.ToString() + " " + znak + " " + now.Year.ToString() + "-"  + now.Month.ToString() + "-" + now.Day.ToString() + " ";

		}

		private void toolStripMenuItem_zamknij_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button_ustaw_wysylanie_Click(object sender, EventArgs e)
		{
			liczba_komorek_wysylanie = Convert.ToInt32(textBox_wysylanie_liczba_danych.Text);

			//tablica dynamiczna dla potrzeb inkrementacji funkcji itp.
			licz_wysylanie = new liczydlo[liczba_komorek_wysylanie];

			//kolumny
			for (int i = 0, y = 0; i < liczba_komorek_wysylanie; y++)
			{

				//wiersze
				for (int x = 0; (x < ilosc_wierszy) && (i < liczba_komorek_wysylanie); x++, i++)
				{
					//tworzymy nową kontrolkę - textbox
					TextBox ntextbox = new TextBox();

					//umieszczanie na ekranie danej kontrolki
					ntextbox.Location = new System.Drawing.Point(2 + szerokosc_komorki * y, 25 + 20 * x);

					//określenie rozmiarów kontrolki
					ntextbox.Size = new System.Drawing.Size(szerokosc_komorki, 20);

					//przypisanie nazwy danej kontrolce
					ntextbox.Name = "d_" + (40000 + Convert.ToInt32(textBox_wysylanie_poczatek.Text) + i).ToString();

					//wpisanie początkowej wartości
					ntextbox.Text = "0";


					//ntextbox.

					//konfiguracja danej kontrolki - wyswietlany tekst, ewentualne ustawienia
					//nbutton.Text = "Przepisz";   //nazwa przycisku
					//nlabel.AutoSize = true;      //ustawienie automatycznego dopasowania szerokości

					//ustawienie zdarzenia dla przycisków
					//nbutton.Click += new System.EventHandler(Nbutton_Click);

					//dla kliknięcia na textbox
					//ntextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(Ntextbox_MouseClick);

					//->ntextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress_tylko_cyfra);
					//->ntextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(zmiana_nastawy);
					//ntextbox.Leave += new System.EventHandler(zmiana_nastawy);
					//ntextbox.TextChanged += new System.EventHandler(zmiana_nastawy);
					//ntextbox.Enter += new System.EventHandler(zmiana_nastawy);

					//zdarzenie dla najechania przycisku
					//->ntextbox.MouseEnter += textBox_cells_MouseEnter_zapis;

					//zdarzenie od zmiany wartości
					//ntextbox.TextChanged += Ntextbox_TextChanged;


					//ustawienie menu kontekstowego
					//->ntextbox.ContextMenuStrip = contextMenuStrip_tabele_wysylane;

					//dodanie kontrolek do formularza (do kolekcji - tablicy)
					//Controls.Add(ntextbox);
					//Controls.Add(nbutton);
					//Controls.Add(nlabel);

					//->toolTip_tabela.SetToolTip(ntextbox, (40000 + Convert.ToInt32(textBox_wysylanie_poczatek.Text) + i).ToString());

					panel_wysylanie.Controls.Add(ntextbox);

					licz_wysylanie[i].cells = ntextbox;
				}

			}

			//opis
			//kolumny
			for (int y = 0; y < (((liczba_komorek_wysylanie % 10) == 0) ? (liczba_komorek_wysylanie / 10) : (liczba_komorek_wysylanie / 10 + 1)); y++)
			{
				//tworzymy nową kontrolkę - textbox opis kolumny
				TextBox ntextbox_kol = new TextBox();

				//umieszczanie na ekranie danej kontrolki
				ntextbox_kol.Location = new System.Drawing.Point(2 + szerokosc_komorki * y, 5);

				//określenie rozmiarów kontrolki
				ntextbox_kol.Size = new System.Drawing.Size(szerokosc_komorki, 20);

				//przypisanie nazwy danej kontrolce
				ntextbox_kol.Name = "d_kol_z" + (40000 + Convert.ToInt32(textBox_wysylanie_poczatek.Text) + y * 10).ToString();

				//wpisanie początkowej wartości
				ntextbox_kol.Text = (40000 + Convert.ToInt32(textBox_wysylanie_poczatek.Text) + y * 10).ToString();
				ntextbox_kol.ReadOnly = true;
				ntextbox_kol.BackColor = Color.White;

				panel_wysylanie.Controls.Add(ntextbox_kol);
			}
		}

		private void button_wyczysc_odbieranie_Click(object sender, EventArgs e)
		{
			if (panel_odbieranie.Controls.Count > 0)
			{
				panel_odbieranie.Controls.Clear();
			}
		}

		private void button_wyczysc_wysylanie_Click(object sender, EventArgs e)
		{
			if (panel_wysylanie.Controls.Count > 0)
			{
				panel_wysylanie.Controls.Clear();
			}
		}

		private void button_dodaj_bit_Click(object sender, EventArgs e)
		{
			/*//tworzymy nową kontrolkę
			Button scada_button = new Button();

			//umieszczenie na ekranie nowej kontrolki
			scada_button.Location = new System.Drawing.Point(520, 0);

			//określenie rozmiarów kontrolki
			scada_button.Size = new System.Drawing.Size(50, 20);

			//przypisanie nazwy danej kontrolce
			scada_button.Name = "scada_" + scada_nr.ToString();

			//dodanie kontrolki do panelu
			panel_scada.Controls.Add(scada_button);

			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);

			ekran_scada[scada_nr++].obiekt = scada_button;*/

			//tworzymy nową kontrolkę
			Button scada_button = new Button();

			//tworzymy opis do kontrolki
			Label scada_label = new Label();

			//tworzymy panel w którym będą znajdować się kontrolki
			Panel scada_panel = new Panel();

			//dodanie utworzonego panelu, do istniejącego (kontener)
			panel_scada.Controls.Add(scada_panel);
			//umiejscowanie na ekranie utworzonego panelu
			scada_panel.Location = new System.Drawing.Point(520, 0);
			//określenie rozmiaru
			scada_panel.Size = new System.Drawing.Size(51, 20);
			//określenie właściowości - automatyczne dopasowanie wielkości
			scada_panel.AutoSize = true;
			scada_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;


			//dodanie nowej kontroli do kontenera
			scada_panel.Controls.Add(scada_button);
			//umiejscowienie w konterze nowej kontrolki
			scada_button.Location = new System.Drawing.Point(0, 0);
			//określenie rozmiarów kontrolki
			scada_button.Size = new System.Drawing.Size(50, 20);
			//zdarzenie od przycisku myszą
			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);
			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(zmiana_bit_kontrolki);
			//opis początkowy
			scada_button.Text = "0";

			//dodanie opisu kontrolki do kontenera
			scada_panel.Controls.Add(scada_label);
			//umiejscowienie w kontenerze opisu
			scada_label.Location = new System.Drawing.Point(50, 4);
			//określenie rozmiarów opisu
			scada_label.Size = new System.Drawing.Size(41, 5);
			//auto doposaowanie do zawartości
			scada_label.AutoSize = true;
			//zdarzenie od przycisku myszą
			scada_label.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

			//przypisanie nazwy danej kontrolce
			scada_button.Name = "scada_button_" + scada_nr.ToString();
			scada_label.Name = "scada_label_" + scada_nr.ToString();
			scada_panel.Name = "scada_panel_" + scada_nr.ToString();

			//przypisanie zawartości opisu
			scada_label.Text = "opis kontrolki";

			ekran_scada[scada_nr].typ = 0;
			ekran_scada[scada_nr].wielkosc = 0;
			ekran_scada[scada_nr].adres_bajt = 0;

			ekran_scada[scada_nr].kontrolka = scada_button;
			ekran_scada[scada_nr].opis = scada_label;
			ekran_scada[scada_nr++].obiekt = scada_panel;


		}

		private void button_pole_bajt_Click(object sender, EventArgs e)
		{
			//tworzymy nową kontrolkę
			TextBox scada_textbox = new TextBox();
			
			//tworzymy opis do kontrolki
			Label scada_label = new Label();

			//tworzymy panel w którym będą znajdować się kontrolki
			Panel scada_panel = new Panel();

			//dodanie utworzonego panelu, do istniejącego (kontener)
			panel_scada.Controls.Add(scada_panel);
			//umiejscowanie na ekranie utworzonego panelu
			scada_panel.Location = new System.Drawing.Point(520, 0);
			//określenie rozmiaru
			scada_panel.Size = new System.Drawing.Size(51, 20);
			//określenie właściowości - automatyczne dopasowanie wielkości
			scada_panel.AutoSize = true;
			scada_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

			//dodanie nowej kontroli do kontenera
			scada_panel.Controls.Add(scada_textbox);
			//umiejscowienie w konterze nowej kontrolki
			scada_textbox.Location = new System.Drawing.Point(0, 0);
			//określenie rozmiarów kontrolki
			scada_textbox.Size = new System.Drawing.Size(50, 20);
			//wpisanie tekstu domyślnego
			scada_textbox.Text = "0";
			//zdarzenie od przycisku myszą
			scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
			scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

			//dodanie opisu kontrolki do kontenera
			scada_panel.Controls.Add(scada_label);
			//umiejscowienie w kontenerze opisu
			scada_label.Location = new System.Drawing.Point(50, 4);
			//określenie rozmiarów opisu
			scada_label.Size = new System.Drawing.Size(1, 30);
			//auto doposaowanie do zawartości
			scada_label.AutoSize = true;

			//zdarzenie od przycisku myszą
			scada_label.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

			//przypisanie nazwy danej kontrolce
			scada_textbox.Name = "scada_box_" + scada_nr.ToString();
			scada_label.Name = "scada_label_" + scada_nr.ToString();
			scada_panel.Name = "scada_panel_" + scada_nr.ToString();

			//przypisanie zawartości opisu
			scada_label.Text = "opis kontrolki";


			ekran_scada[scada_nr].typ = 0;
			ekran_scada[scada_nr].wielkosc = 1;
			ekran_scada[scada_nr].adres_bajt = 0;
			//ekran_scada[scada_nr].adres_bit = 0;

			ekran_scada[scada_nr].kontrolka = scada_textbox;
			ekran_scada[scada_nr].opis = scada_label;
			ekran_scada[scada_nr++].obiekt = scada_panel;

			

		}

		private void panel_scada_MouseMove(object sender, MouseEventArgs e)
		{
			toolStripStatusLabel_X.Text = e.X.ToString();
			toolStripStatusLabel_Y.Text = e.Y.ToString();

			if (kontrolka_zmiana != null)
			{
				if(kontrolka_zmiana.GetType() == typeof(TextBox))
				{
					(kontrolka_zmiana as TextBox).Location = new System.Drawing.Point(e.X, e.Y);
				}else if(kontrolka_zmiana.GetType() == typeof(Button))
				{
					(kontrolka_zmiana as Button).Location = new System.Drawing.Point(e.X, e.Y);
				}
				else if (kontrolka_zmiana.GetType() == typeof(Panel))
				{
					(kontrolka_zmiana as Panel).Location = new System.Drawing.Point(e.X, e.Y);
				}

			}
		}

		//w oknie właściwości wciśnięcie enter potwierdza wpisane dane
		private void wlasciwosci_nazwa_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				(ekran_scada[kontrolka_nr_parametry].opis as Label).Text = wlasciwosci_textBox_nazwa.Text;
				ekran_scada[kontrolka_nr_parametry].opis_text = wlasciwosci_textBox_nazwa.Text;
			}
		}

		private void wlasciwosci_typ_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				ekran_scada[kontrolka_nr_parametry].typ = wlasciwosci_comboBox_typ.SelectedIndex;
			}
		}

		private void wlasciwosci_bajt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				ekran_scada[kontrolka_nr_parametry].adres_bajt = Convert.ToInt32(wlasciwosci_textBox_bajt.Text);
			}
		}

		private void wlasciwosci_bit_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				ekran_scada[kontrolka_nr_parametry].adres_bit = Convert.ToInt32(wlasciwosci_textBox_bit.Text);
			}
		}

		private void wlasciwosci_wielkosc_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				ekran_scada[kontrolka_nr_parametry].wielkosc = wlasciwosci_comboBox_wielkosc.SelectedIndex+1;
			}
		}

		private void wlasciwosci_format_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				ekran_scada[kontrolka_nr_parametry].format = wlasciwosci_comboBox_format.SelectedIndex;
			}
		}

		private void button_polacz_modbus_Click(object sender, EventArgs e)
		{
			//praca jako klient

			try
			{
				modbus_client = new EasyModbus.ModbusClient(textBox_adres_ip.Text, Convert.ToInt16(textBox_port.Text));
				modbus_client.UnitIdentifier = Convert.ToByte(textBox_id.Text);
				modbus_client.Connect();
				timer_client.Enabled = true;
			}
			catch (Exception ex)
			{
				richTextBox_tekst.AppendText(ex.Message + "\n");
				richTextBox_tekst.AppendText(ex.ToString() + "\n");
				//throw;
			}
		}

		private void button_rozlacz_modbus_Click(object sender, EventArgs e)
		{
			try
			{
				if(modbus_client != null)
				{
					modbus_client.Disconnect();
				}

				timer_client.Enabled = false;
				
			}
			catch (Exception ex)
			{
				richTextBox_tekst.AppendText(ex.ToString() + "\n");
				throw;
			}
		}

		private void timer_client_Tick(object sender, EventArgs e)
		{
			timer_client.Enabled = false;

			try
			{
				int[] tab = new int[liczba_komorek_wysylanie];
				// tab[Convert.ToInt16(textBox_odczyt_liczba_danych.Text)] = { 10, 32, 0, 1, 2, 3, 4, 5, 6, 7 };

				for (int i = 0; i < liczba_komorek_wysylanie; i++)
				{
					//sprawdzanie czy przesyłana jest nastawa
					if (licz_wysylanie[i].nastawa == false)
					{
						tab[i] = Convert.ToInt16((licz_wysylanie[i].cells as TextBox).Text);

					}
					else if (licz_wysylanie[i].nastawa == true)
					{
						//sprawdzanie czy zmianie uległa nastawa
						if (licz_wysylanie[i].zmiana_nastawy == true)
						{
							tab[i] = Convert.ToInt16((licz_wysylanie[i].cells as TextBox).Text);

						}
						else
						{
							tab[i] = 9999;// Convert.ToInt16(textBox_nastawa.Text);
						}
					}


				}
				int poczatek = (Convert.ToInt16(textBox_wysylanie_poczatek.Text) - 1);
				modbus_client.WriteMultipleRegisters(poczatek, tab);

				int[] readHoldingRegisters = modbus_client.ReadHoldingRegisters((Convert.ToInt16(textBox_odbieranie_poczatek.Text) - 1), liczba_komorek_odbieranie);    //Read 10 Holding Registers from Server, starting with Address 1

				for (int i = 0; i < liczba_komorek_odbieranie; i++)
				{
					(licz_odbieranie[i].cells as TextBox).Text = readHoldingRegisters[i].ToString();
				}

				for (int i = 0; i < scada_nr; i++)
				{
					if ( (ekran_scada[i].wielkosc != 0))// && (ekran_scada[i].adres_bajt != null) )
					{
						if (ekran_scada[i].typ == 0)
						{
							(ekran_scada[i].kontrolka as TextBox).Text = readHoldingRegisters[ekran_scada[i].adres_bajt + (Convert.ToInt16(textBox_odbieranie_poczatek.Text) - 1)].ToString();
						}
						else
							(licz_wysylanie[ekran_scada[i].adres_bajt].cells as TextBox).Text = (ekran_scada[i].kontrolka as TextBox).Text;
					}
					else if ((ekran_scada[i].wielkosc == 0))// && (ekran_scada[i].adres_bajt != null))
					{
						if (ekran_scada[i].typ == 0)
						{
							(ekran_scada[i].kontrolka as Button).Text = ( (readHoldingRegisters[ekran_scada[i].adres_bajt + (Convert.ToInt16(textBox_odbieranie_poczatek.Text) - 1)] >> ekran_scada[i].adres_bit) &0x001 ).ToString();
						}
						else
						{
							int i_but = Convert.ToInt32( (ekran_scada[i].kontrolka as Button).Text);
							if(i_but == 1)
								(licz_wysylanie[ekran_scada[i].adres_bajt].cells as TextBox).Text = (Convert.ToInt32((licz_wysylanie[ekran_scada[i].adres_bajt].cells as TextBox).Text) | (0x00 | (1 << ekran_scada[i].adres_bit) )).ToString();
							else
								(licz_wysylanie[ekran_scada[i].adres_bajt].cells as TextBox).Text = (Convert.ToInt32((licz_wysylanie[ekran_scada[i].adres_bajt].cells as TextBox).Text) & ~(0x00 | (1 << ekran_scada[i].adres_bit) )).ToString();

						}
					}
				}

			}
			catch (Exception ex)
			{
				richTextBox_tekst.AppendText(ex.ToString() + "\n");
				button_rozlacz_modbus_Click(null, null);
				return;
				//throw;
			}



			timer_client.Enabled = true;
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (modbus_client != null)
				{
					modbus_client.Disconnect();
				}
				
				timer_client.Enabled = false;

			}
			catch (Exception ex)
			{
				richTextBox_tekst.AppendText(ex.ToString() + "\n");
				throw;
			}
		}

		private void toolStripMenuItem_zapisz_Click(object sender, EventArgs e)
		{
			if (saveFileDialog_1.ShowDialog() == DialogResult.OK)
			{
				string plik = saveFileDialog_1.FileName;

				XmlWriterSettings xml_settings = new XmlWriterSettings();
				xml_settings.NewLineOnAttributes = true;
				xml_settings.Indent = true;

				XmlWriter xml_write = XmlWriter.Create(plik, xml_settings);

				xml_write.WriteStartDocument();
				xml_write.WriteStartElement("mini_SCADA");

				//parametry modbusa
				xml_write.WriteStartElement("modbus");

				xml_write.WriteStartElement("ip_address");
				xml_write.WriteString(textBox_adres_ip.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("port");
				xml_write.WriteString(textBox_port.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("ID");
				xml_write.WriteString(textBox_id.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("liczba_odebranych");
				xml_write.WriteString(textBox_odbieranie_liczba_danych.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("liczba_wysylanych");
				xml_write.WriteString(textBox_wysylanie_liczba_danych.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("odbieranie_poczatek");
				xml_write.WriteString(textBox_odbieranie_poczatek.Text);
				xml_write.WriteEndElement();

				xml_write.WriteStartElement("wysylanie_poczatek");
				xml_write.WriteString(textBox_wysylanie_poczatek.Text);
				xml_write.WriteEndElement();

				xml_write.WriteEndElement(); //modbus

				//parametry scada

				for(int i=0; i < scada_nr; i++)
				{
					xml_write.WriteStartElement("scada");

					xml_write.WriteStartElement("opis");
					xml_write.WriteString(ekran_scada[i].opis_text);
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("nr_obiektu");
					xml_write.WriteString(ekran_scada[i].nr_obiektu.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("pozycja_x");
					xml_write.WriteString(ekran_scada[i].pozycja_x.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("pozycja_y");
					xml_write.WriteString(ekran_scada[i].pozycja_y.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("typ");
					xml_write.WriteString(ekran_scada[i].typ.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("format");
					xml_write.WriteString(ekran_scada[i].format.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("wielkosc");
					xml_write.WriteString(ekran_scada[i].wielkosc.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("adres_bajt");
					xml_write.WriteString(ekran_scada[i].adres_bajt.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteStartElement("adres_bit");
					xml_write.WriteString(ekran_scada[i].adres_bit.ToString());
					xml_write.WriteEndElement();

					xml_write.WriteEndElement();
				}

				xml_write.WriteEndElement();    //mini_scada
				xml_write.WriteEndDocument();
				xml_write.Close();

			}
		}

		private void toolStripMenuItem_otworz_Click(object sender, EventArgs e)
		{
			if(openFileDialog_1.ShowDialog() == DialogResult.OK)
			{
				string plik = openFileDialog_1.FileName;
				XmlDocument xml_doc = new XmlDocument();

				try
				{

					xml_doc.Load(plik);

					//ustawienia modbus

					textBox_adres_ip.Text = xml_doc.GetElementsByTagName("ip_address").Item(0).InnerText;
					textBox_port.Text = xml_doc.GetElementsByTagName("port").Item(0).InnerText;
					textBox_id.Text = xml_doc.GetElementsByTagName("ID").Item(0).InnerText;
					textBox_odbieranie_liczba_danych.Text = xml_doc.GetElementsByTagName("liczba_odebranych").Item(0).InnerText;
					textBox_wysylanie_liczba_danych.Text = xml_doc.GetElementsByTagName("liczba_wysylanych").Item(0).InnerText;
					textBox_odbieranie_poczatek.Text = xml_doc.GetElementsByTagName("odbieranie_poczatek").Item(0).InnerText;
					textBox_wysylanie_poczatek.Text = xml_doc.GetElementsByTagName("wysylanie_poczatek").Item(0).InnerText;


					//ustawienia scada
					scada_nr = xml_doc.GetElementsByTagName("scada").Count;

					for(int i = 0; i < scada_nr; i++)
					{
						ekran_scada[i].opis_text = xml_doc.GetElementsByTagName("opis").Item(i).InnerText;
						ekran_scada[i].nr_obiektu = Convert.ToInt32(xml_doc.GetElementsByTagName("nr_obiektu").Item(i).InnerText);
						ekran_scada[i].pozycja_x = Convert.ToInt32(xml_doc.GetElementsByTagName("pozycja_x").Item(i).InnerText);
						ekran_scada[i].pozycja_y = Convert.ToInt32(xml_doc.GetElementsByTagName("pozycja_y").Item(i).InnerText);
						ekran_scada[i].typ = Convert.ToInt32(xml_doc.GetElementsByTagName("typ").Item(i).InnerText);
						ekran_scada[i].format = Convert.ToInt32(xml_doc.GetElementsByTagName("format").Item(i).InnerText);
						ekran_scada[i].wielkosc = Convert.ToInt32(xml_doc.GetElementsByTagName("wielkosc").Item(i).InnerText);
						ekran_scada[i].adres_bajt = Convert.ToInt32(xml_doc.GetElementsByTagName("adres_bajt").Item(i).InnerText);
						ekran_scada[i].adres_bit = Convert.ToInt32(xml_doc.GetElementsByTagName("adres_bit").Item(i).InnerText);

					}
					

				}
				catch(XmlException ex)
				{
					MessageBox.Show(ex.Message);
				}


			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(panel_scada.Controls.Count > 0)
			{
				panel_scada.Controls.Clear();
			}



			for (int i=0; i < scada_nr; i++)
			{
				//tworzymy nową kontrolkę
				Button scada_button = new Button();

				//tworzymy opis do kontrolki
				Label scada_label = new Label();

				//tworzymy panel w którym będą znajdować się kontrolki
				Panel scada_panel = new Panel();

				//tworzymy nową kontrolkę
				TextBox scada_textbox = new TextBox();

				if (ekran_scada[i].typ == 0)	//button
				{
					//dodanie utworzonego panelu, do istniejącego (kontener)
					panel_scada.Controls.Add(scada_panel);
					//umiejscowanie na ekranie utworzonego panelu
					scada_panel.Location = new System.Drawing.Point(ekran_scada[i].pozycja_x, ekran_scada[i].pozycja_y);
					//określenie rozmiaru
					scada_panel.Size = new System.Drawing.Size(51, 20);
					//określenie właściowości - automatyczne dopasowanie wielkości
					scada_panel.AutoSize = true;
					scada_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;


					//dodanie nowej kontroli do kontenera
					scada_panel.Controls.Add(scada_button);
					//umiejscowienie w konterze nowej kontrolki
					scada_button.Location = new System.Drawing.Point(0, 0);
					//określenie rozmiarów kontrolki
					scada_button.Size = new System.Drawing.Size(50, 20);
					//zdarzenie od przycisku myszą
					scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
					scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);
					scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(zmiana_bit_kontrolki);
					//opis początkowy
					scada_button.Text = "0";

					//dodanie opisu kontrolki do kontenera
					scada_panel.Controls.Add(scada_label);
					//umiejscowienie w kontenerze opisu
					scada_label.Location = new System.Drawing.Point(50, 4);
					//określenie rozmiarów opisu
					scada_label.Size = new System.Drawing.Size(41, 5);
					//auto doposaowanie do zawartości
					scada_label.AutoSize = true;
					//zdarzenie od przycisku myszą
					scada_label.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

					//przypisanie nazwy danej kontrolce
					scada_button.Name = "scada_button_" + i.ToString();
					scada_label.Name = "scada_label_" + i.ToString();
					scada_panel.Name = "scada_panel_" + i.ToString();

					//przypisanie zawartości opisu
					scada_label.Text = ekran_scada[i].opis_text;

					ekran_scada[i].kontrolka = scada_button;
					ekran_scada[i].opis = scada_label;
					ekran_scada[i].obiekt = scada_panel;
				}
				else if(ekran_scada[i].typ != 0) //textbox
				{


					//dodanie utworzonego panelu, do istniejącego (kontener)
					panel_scada.Controls.Add(scada_panel);
					//umiejscowanie na ekranie utworzonego panelu
					scada_panel.Location = new System.Drawing.Point(ekran_scada[i].pozycja_x, ekran_scada[i].pozycja_y);
					//określenie rozmiaru
					scada_panel.Size = new System.Drawing.Size(51, 20);
					//określenie właściowości - automatyczne dopasowanie wielkości
					scada_panel.AutoSize = true;
					scada_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

					//dodanie nowej kontroli do kontenera
					scada_panel.Controls.Add(scada_textbox);
					//umiejscowienie w konterze nowej kontrolki
					scada_textbox.Location = new System.Drawing.Point(0, 0);
					//określenie rozmiarów kontrolki
					scada_textbox.Size = new System.Drawing.Size(50, 20);
					//wpisanie tekstu domyślnego
					scada_textbox.Text = "0";
					//zdarzenie od przycisku myszą
					scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
					scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

					//dodanie opisu kontrolki do kontenera
					scada_panel.Controls.Add(scada_label);
					//umiejscowienie w kontenerze opisu
					scada_label.Location = new System.Drawing.Point(50, 4);
					//określenie rozmiarów opisu
					scada_label.Size = new System.Drawing.Size(1, 30);
					//auto doposaowanie do zawartości
					scada_label.AutoSize = true;

					//zdarzenie od przycisku myszą
					scada_label.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

					//przypisanie nazwy danej kontrolce
					scada_textbox.Name = "scada_box_" + i.ToString();
					scada_label.Name = "scada_label_" + i.ToString();
					scada_panel.Name = "scada_panel_" + i.ToString();

					//przypisanie zawartości opisu
					scada_label.Text = ekran_scada[i].opis_text;

					ekran_scada[i].adres_bit = 0;

					ekran_scada[i].kontrolka = scada_textbox;
					ekran_scada[i].opis = scada_label;
					ekran_scada[i].obiekt = scada_panel;
				}

			}

		}

		//-----
		private void button_ustaw_odbieranie_Click(object sender, EventArgs e)
		{
			liczba_komorek_odbieranie = Convert.ToInt32(textBox_odbieranie_liczba_danych.Text);

			//tablica dynamiczna dla potrzeb inkrementacji funkcji itp.
			licz_odbieranie = new liczydlo[liczba_komorek_odbieranie];

			//kolumny
			for (int i = 0, y = 0; i < liczba_komorek_odbieranie; y++)
			{
				//wiersze
				for (int x = 0; (x < ilosc_wierszy) && (i < liczba_komorek_odbieranie); x++, i++)
				{
					//tworzymy nową kontrolkę - textbox
					TextBox ntextbox = new TextBox();

					//umieszczanie na ekranie danej kontrolki
					ntextbox.Location = new System.Drawing.Point(2 + szerokosc_komorki * y, 25 + 20 * x);

					//określenie rozmiarów kontrolki
					ntextbox.Size = new System.Drawing.Size(szerokosc_komorki, 20);

					//przypisanie nazwy danej kontrolce
					ntextbox.Name = "d_" + (40000 + Convert.ToInt32(textBox_odbieranie_poczatek.Text) + i).ToString();

					//wpisanie początkowej wartości
					ntextbox.Text = "0";


					//ntextbox.

					//konfiguracja danej kontrolki - wyswietlany tekst, ewentualne ustawienia
					//nbutton.Text = "Przepisz";   //nazwa przycisku
					//nlabel.AutoSize = true;      //ustawienie automatycznego dopasowania szerokości

					//ustawienie zdarzenia dla przycisków
					//nbutton.Click += new System.EventHandler(Nbutton_Click);

					//dla kliknięcia na textbox
					//ntextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(Ntextbox_MouseClick);

					//->ntextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_KeyPress_tylko_cyfra);

					//zdarzenie dla najechania przycisku
					//->ntextbox.MouseEnter += textBox_cells_MouseEnter_odczyt;

					//zdarzenie od zmiany wartości
					//ntextbox.TextChanged += Ntextbox_TextChanged;


					//ustawienie menu kontekstowego
					//->ntextbox.ContextMenuStrip = contextMenuStrip_tabele_odebrane;

					//dodanie kontrolek do formularza (do kolekcji - tablicy)
					//Controls.Add(ntextbox);
					//Controls.Add(nbutton);
					//Controls.Add(nlabel);

					//->toolTip_tabela.SetToolTip(ntextbox, (40000 + Convert.ToInt32(textBox_odbieranie_poczatek.Text) + i).ToString());

					panel_odbieranie.Controls.Add(ntextbox);

					licz_odbieranie[i].cells = ntextbox;
					if (licz_odbieranie[i].cells.GetType() == typeof(Label))
					{
					//	int a = 0;
					}
				}
			}


			//opis
			//kolumny
			for (int y = 0; y < (((liczba_komorek_odbieranie % 10) == 0) ? (liczba_komorek_odbieranie / 10) : (liczba_komorek_odbieranie / 10 + 1)); y++)
			{
				//tworzymy nową kontrolkę - textbox opis kolumny
				TextBox ntextbox_kol = new TextBox();

				//umieszczanie na ekranie danej kontrolki
				ntextbox_kol.Location = new System.Drawing.Point(2 + szerokosc_komorki * y, 5);

				//określenie rozmiarów kontrolki
				ntextbox_kol.Size = new System.Drawing.Size(szerokosc_komorki, 20);

				//przypisanie nazwy danej kontrolce
				ntextbox_kol.Name = "d_kol_o" + (40000 + Convert.ToInt32(textBox_odbieranie_poczatek.Text) + y * 10).ToString();

				//wpisanie początkowej wartości
				ntextbox_kol.Text = (40000 + Convert.ToInt32(textBox_odbieranie_poczatek.Text) + y * 10).ToString();
				ntextbox_kol.ReadOnly = true;
				ntextbox_kol.BackColor = Color.White;

				panel_odbieranie.Controls.Add(ntextbox_kol);
			}
		}
	}
}
