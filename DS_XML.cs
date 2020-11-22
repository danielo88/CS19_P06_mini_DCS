using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

namespace CS19_P06_mini_DCS
{
	public class DS_XML
	{
		//zmienne
		public int asda;
		//metody
		public int DS_read_XML(string plik)
		{
			XmlDocument xml_doc = new XmlDocument();

			
			xml_doc.Load(plik);

			//ustawienia okna
			Main.ActiveForm.Size = new Size(Convert.ToInt32(xml_doc.GetElementsByTagName("rozmiar_okna_szerokosc").Item(0).InnerText), Convert.ToInt32(xml_doc.GetElementsByTagName("rozmiar_okna_wysokosc").Item(0).InnerText));

			//ustawienia modbus

			/*textBox_adres_ip.Text = polaczenie_modbus[liczba_polaczen - 1].adres_ip;
			textBox_port.Text = xml_doc.GetElementsByTagName("port").Item(0).InnerText;
			textBox_id.Text = xml_doc.GetElementsByTagName("ID").Item(0).InnerText;
			textBox_odbieranie_liczba_danych.Text = polaczenie_modbus[liczba_polaczen - 1].liczba_komorek_odbieranych
			textBox_wysylanie_liczba_danych.Text = polaczenie_modbus[liczba_polaczen - 1].liczba_komorek_wysylanych;
			textBox_odbieranie_poczatek.Text = polaczenie_modbus[liczba_polaczen - 1].poczatek_odbierania;
			textBox_wysylanie_poczatek.Text = polaczenie_modbus[liczba_polaczen - 1].poczatek_wysylania;
			
			Main.polaczenie_modbus[liczba_polaczen - 1].adres_ip = xml_doc.GetElementsByTagName("ip_address").Item(0).InnerText; 
			polaczenie_modbus[liczba_polaczen - 1].port = xml_doc.GetElementsByTagName("port").Item(0).InnerText; 
			//ID
			polaczenie_modbus[liczba_polaczen - 1].liczba_komorek_odbieranych = xml_doc.GetElementsByTagName("liczba_odebranych").Item(0).InnerText;
			polaczenie_modbus[liczba_polaczen - 1].liczba_komorek_wysylanych = xml_doc.GetElementsByTagName("liczba_wysylanych").Item(0).InnerText;
			polaczenie_modbus[liczba_polaczen - 1].poczatek_odbierania = xml_doc.GetElementsByTagName("odbieranie_poczatek").Item(0).InnerText;
			polaczenie_modbus[liczba_polaczen - 1].poczatek_wysylania = xml_doc.GetElementsByTagName("wysylanie_poczatek").Item(0).InnerText;

			//ustawienia scada
			scada_nr = xml_doc.GetElementsByTagName("scada").Count;

			for (int i = 0; i < scada_nr; i++)
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

			}*/

			return -1;	//błąd
		}

		public int DS_write_XML()
		{

			return -1;	//błąd
		}

	}
}
