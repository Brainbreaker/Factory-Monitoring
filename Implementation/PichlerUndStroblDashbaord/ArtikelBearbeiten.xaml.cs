using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class ArtikelBearbeiten : Window
    {
        int artikel_id = 0;
        bool vollsändigkeit = false;
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public ArtikelBearbeiten(string artikelnummer)
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;

            //benutzer interaktionshinweise
            lblSucheZeichnung.Content = "PDF angefügt";
            lblSucheZeichnung.Foreground = new SolidColorBrush(Colors.Green);
            lblSuche3DModell.Content = "PDF angefügt";
            lblSuche3DModell.Foreground = new SolidColorBrush(Colors.Green);

            //sql befehl
            com.CommandText = "select * from Artikel where Artikelnummer='"+artikelnummer+"'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                //daten aus der datenbank am bildschirm anzeigen
                txtArtikelname.Text = dr["Artikelname"].ToString();
                txtArtikelnummer.Text = dr["Artikelnummer"].ToString();
                txtRevision.Text = dr["Revision"].ToString();
                txtBearbeitungszeitSoll.Text = dr["Bearbeitungszeit_Soll"].ToString();
                txtPreis.Text = dr["Preis"].ToString();
                coxKunde.Text = dr["Kundenname"].ToString();
                txtKommentar.Text = dr["Kommentar"].ToString();
                txtSucheZeichnung.Text = dr["Zeichnung"].ToString();
                txtSuche3DModell.Text = dr["DreiD_Modell"].ToString();
                artikel_id = Int32.Parse(dr["Artikel_ID"].ToString());
            }
            //datareader schließen
            dr.Close();
        }

        //drücken SucheZeichnung button
        private void btnSucheZeichnung_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf files (*.pdf)|*.pdf";
            Nullable<bool> ok = dialog.ShowDialog();
            if (ok == true)
            {
                string names = "";
                foreach (string filename in dialog.FileNames)
                {
                    names += ";" + filename;
                }
                names = names.Substring(1);
                txtSucheZeichnung.Text = names;
            }
        }

        //drücken Suche3DModell button
        private void btnSuche3DModell_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Pdf files (*.pdf)|*.pdf";
            Nullable<bool> ok = dialog.ShowDialog();
            if (ok == true)
            {
                string names = "";
                foreach (string filename in dialog.FileNames)
                {
                    names += ";" + filename;
                }
                names = names.Substring(1);
                txtSuche3DModell.Text = names;
            }
        }
        //drücken speichern button
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Vollständigkeitsüberprüfung();
            if (vollsändigkeit)
            {
                string artikelname = txtArtikelname.Text;
                string artikelnummer = txtArtikelnummer.Text;
                int revision = Int32.Parse(txtRevision.Text);
                string zeichnung = txtSucheZeichnung.Text;
                string modell = txtSuche3DModell.Text;
                int bearbeitungszeit_soll = Int32.Parse(txtBearbeitungszeitSoll.Text);
                int preis = Int32.Parse(txtPreis.Text);
                string kommentar = txtKommentar.Text;
                string kunden_id = coxKunde.Text;

                //sql befehl
                com.CommandText = "update Artikel set Artikelname ='" + artikelname + "', Artikelnummer ='" + artikelnummer + "', Revision ='" + revision + "', Zeichnung ='" + zeichnung + "', DreiD_Modell='" + modell + "', Bearbeitungszeit_Soll='" + bearbeitungszeit_soll + "', Preis='" + preis + "', Kommentar='" + kommentar + "', Kundenname='" + kunden_id + "' where Artikelnummer = '" + artikelnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                                                                                                                                                                                                                                                                                                                                                                                                                          //sql befehl ausführen und datareade öffnen
                dr = com.ExecuteReader();
                //fenster schließen nach update
                this.Close();
            }
        }

        //vollständigkeitsprüfung methode
        private void Vollständigkeitsüberprüfung()
        {
            vollsändigkeit = true;
            string[] txtBoxen = { txtArtikelname.Text, txtArtikelnummer.Text, txtPreis.Text, txtSucheZeichnung.Text, txtRevision.Text, coxKunde.Text, txtBearbeitungszeitSoll.Text, txtSuche3DModell.Text };
            for (int i = 0; i < txtBoxen.Length; i++)
            {
                if (txtBoxen[i] != null && string.IsNullOrWhiteSpace(txtBoxen[i]))
                {
                    vollsändigkeit = false;
                    lblVollständigkeit.Visibility = Visibility.Visible;
                }
            }
        }

        //drücken schließen button
        private void btnSchließen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}