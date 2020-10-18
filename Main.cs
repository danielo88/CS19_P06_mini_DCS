using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		struct scada
		{
			public object obiekt;           //wskaźnik do obiektu
			public object opis;				//wskaźnik do opisy (label)
			public Int32 nr_obiektu;		//nr porządkowy obiektu
			public Int32 pozycja_x;			//pozycja x na ekranie
			public Int32 pozycja_y;			//pozycja y na ekranie
			public Int32 typ;				//wejście czy wyjście
			public Int32 adres_bajt;		//który adres w mapie modbus (word)
			public Int32 adres_bit;			//od 0 do 15
			public Int32 wielkosc;          //bit, bajt, word, dword, qword
			public Int32 format;			//bigendian litendiand
		}

		scada[] ekran_scada = new scada[100];
		Int32 scada_nr=0;

		object kontrolka_zmiana;
		Int32 kontrolka_nr_parametry;

		public Main()
		{
			InitializeComponent();
		}

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

						(kontrolka_zmiana as Panel).Enabled = false;

					}
				}else if (kontrolka_zmiana != null)
				{
					(kontrolka_zmiana as Panel).Enabled = true;
					kontrolka_zmiana = null;

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
			scada_panel.Size = new System.Drawing.Size(50, 20);
			//określenie właściowości - automatyczne dopasowanie wielkości
			scada_panel.AutoSize = true;

			//dodanie nowej kontroli do kontenera
			scada_panel.Controls.Add(scada_button);
			//umiejscowienie w konterze nowej kontrolki
			scada_button.Location = new System.Drawing.Point(0, 0);
			//określenie rozmiarów kontrolki
			scada_button.Size = new System.Drawing.Size(50, 20);
			//zdarzenie od przycisku myszą
			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
			scada_button.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

			//dodanie opisu kontrolki do kontenera
			scada_panel.Controls.Add(scada_label);
			//umiejscowienie w kontenerze opisu
			scada_label.Location = new System.Drawing.Point(50, 4);
			//określenie rozmiarów opisu
			scada_label.Size = new System.Drawing.Size(41, 30);
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
			scada_panel.Size = new System.Drawing.Size(50, 20);
			//określenie właściowości - automatyczne dopasowanie wielkości
			scada_panel.AutoSize = true;

			//dodanie nowej kontroli do kontenera
			scada_panel.Controls.Add(scada_textbox);
			//umiejscowienie w konterze nowej kontrolki
			scada_textbox.Location = new System.Drawing.Point(0, 0);
			//określenie rozmiarów kontrolki
			scada_textbox.Size = new System.Drawing.Size(50, 20);
			//zdarzenie od przycisku myszą
			scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_scada_MouseDown);
			scada_textbox.MouseDown += new System.Windows.Forms.MouseEventHandler(kontrolka_parametry_MouseDown);

			//dodanie opisu kontrolki do kontenera
			scada_panel.Controls.Add(scada_label);
			//umiejscowienie w kontenerze opisu
			scada_label.Location = new System.Drawing.Point(50, 4);
			//określenie rozmiarów opisu
			scada_label.Size = new System.Drawing.Size(41, 30);
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

		private void wlasciwosci_nazwa_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				(ekran_scada[kontrolka_nr_parametry].opis as Label).Text = wlasciwosci_textBox_nazwa.Text;
			}
		}

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
