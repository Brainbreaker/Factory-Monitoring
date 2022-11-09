using System;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragHinzufügen : Window
    {
        int mitarbeiter_id;
        bool vollsändigkeit = false;
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public AuftragHinzufügen(int mitarbeiter_id)
        {
            this.mitarbeiter_id = mitarbeiter_id;
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
        }

        //drücken speichern button
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Vollständigkeitsüberprüfung();
            if (vollsändigkeit)
            {
                //variablen anlegen um daten in die datenbank zu übergeben
                string auftragsnummer = txtAuftragsnummer.Text;
                string artikelnummer = txtArtikelnummer.Text;
                int stückzahl = Int32.Parse(txtStückzahl.Text);

                DateTime dateLiefertermin = (DateTime)(dpLiefertermin.SelectedDate);
                string liefertermin = dateLiefertermin.ToString("yyyy-MM-dd");
                DateTime dateStartdatumProduktion = (DateTime)(dpStartdatumDerProduktion.SelectedDate);
                string startdatumProduktion = dateStartdatumProduktion.ToString("yyyy-MM-dd");

                int stückzahl_GUT = 0;
                int stückzahl_Schlecht = 0;
                int stückzahl_Nacharbeit = 0;
                string kommentar = txtKommentar.Text;
                string angelegt_am = DateTime.Now.ToString("yyyy-MM-dd");
                int angelegt_von = this.mitarbeiter_id;

                //sql befehl
                com.CommandText = "insert into Auftrag values ('" + auftragsnummer + "', '" + artikelnummer + "', " + stückzahl + ", '" + liefertermin + "', '" + startdatumProduktion + "', " + stückzahl_GUT + ", " + stückzahl_Schlecht + ", " + stückzahl_Nacharbeit + ", '" + kommentar + "', '" + angelegt_am + "', " + angelegt_von + ")";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                                                                                                                                                                                                                                                                                                                                                 //sql befehl ausführen
                dr = com.ExecuteReader();
                this.Close();
            }
        }

        //vollständigkeitsprüfung methode
        private void Vollständigkeitsüberprüfung()
        {
            vollsändigkeit = true;
            string[] txtBoxen = {txtAuftragsnummer.Text, txtArtikelnummer.Text, txtStückzahl.Text, dpLiefertermin.Text, dpStartdatumDerProduktion.Text};
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
