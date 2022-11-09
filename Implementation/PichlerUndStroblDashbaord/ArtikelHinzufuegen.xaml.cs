using System;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class ArtikelHinzufuegen : Window
    {
        int mitarbeiter_id;
        bool vollsändigkeit = false;
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public ArtikelHinzufuegen(int mitarbeiter_id)
        {
            this.mitarbeiter_id = mitarbeiter_id;
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
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
                //benutzer interaktionshinweis
                txtSucheZeichnung.Text = names;
                lblSucheZeichnung.Content = "PDF angefügt";
                lblSucheZeichnung.Foreground = new SolidColorBrush(Colors.Green);
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
                //benutzer interaktionshinweis
                txtSuche3DModell.Text = names;
                lblSuche3DModell.Content = "PDF angefügt";
                lblSuche3DModell.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        //drücken speichern button
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Vollständigkeitsüberprüfung();
            if (vollsändigkeit)
            {
                //variablen anlegen um daten in die datenbank zu übergeben
                string artikelname = txtArtikelname.Text;
                string artikelnummer = txtArtikelnummer.Text;
                int revision = Int32.Parse(txtRevision.Text);
                string zeichung = txtSucheZeichnung.Text;
                string modell = txtSuche3DModell.Text;
                int bearbeitungszeit_soll = Int32.Parse(txtBearbeitungszeitSoll.Text);
                int bearbeitungszeit_ist = 0;
                int preis = Int32.Parse(txtPreis.Text);
                string kommentar = txtKommentar.Text;
                string angelegt_am = DateTime.Now.ToString("yyyy-MM-dd");
                string kunden_id = coxKunde.Text;
                int angelegt_von = this.mitarbeiter_id;

                //sql befehl
                com.CommandText = "insert into Artikel values ('" + artikelname + "', '" + artikelnummer + "', " + revision + ", '" + zeichung + "', '" + modell + "', " + bearbeitungszeit_soll + ", " + bearbeitungszeit_ist + ", " + preis + ", '" + kommentar + "', '" + angelegt_am + "', '" + kunden_id + "',  " + angelegt_von + ")";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                //sql befehl ausführen
                dr = com.ExecuteReader();
                this.Close();
            }
        }

        //vollständigkeitsprüfung methode
        private void Vollständigkeitsüberprüfung()
        {
            vollsändigkeit = true;
            string[] txtBoxen = { txtArtikelname.Text, txtArtikelnummer.Text, txtPreis.Text, txtSucheZeichnung.Text, txtRevision.Text, coxKunde.Text, txtBearbeitungszeitSoll.Text, txtSuche3DModell.Text};
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
            //aktuelles fenster schließen
            this.Close();
        }
    }
}