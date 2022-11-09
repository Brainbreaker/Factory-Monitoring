using System;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{

    public partial class AuftragBearbeiten : Window
    {
        int auftrag_id = 0;
        bool vollsändigkeit = false;
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public AuftragBearbeiten(string auftragsnummer)
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;

            //sql befehl
            com.CommandText = "select * from Auftrag where Auftragsnummer='" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                //daten aus der datenbank am bildschirm anzeigen
                txtAuftragsnummer.Text = dr["Auftragsnummer"].ToString();
                txtArtikelnummer.Text = dr["Artikelnummer"].ToString();
                txtStückzahl.Text = dr["Stueckzahl"].ToString();
                dpLiefertermin.SelectedDate = (DateTime)dr["Liefertermin"];
                dpStartdatumDerProduktion.SelectedDate = (DateTime)dr["Startdatum_Produktion"];
                txtKommentar.Text = dr["Kommentar"].ToString();
                auftrag_id = Int32.Parse(dr["Auftrag_ID"].ToString());
            }
            //datareader schließen
            dr.Close();
        }

        //drücken speichern button
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Vollständigkeitsüberprüfung();
            if (vollsändigkeit)
            {
                string auftragsnummer = txtAuftragsnummer.Text;
                string artikelnummer = txtArtikelnummer.Text;
                int stückzahl = Int32.Parse(txtStückzahl.Text);
                DateTime dateLiefertermin = (DateTime)(dpLiefertermin.SelectedDate);
                string liefertermin = dateLiefertermin.ToString("yyyy-MM-dd");
                DateTime dateStartdatumProduktion = (DateTime)(dpStartdatumDerProduktion.SelectedDate);
                string startdatumProduktion = dateStartdatumProduktion.ToString("yyyy-MM-dd");
                string kommentar = txtKommentar.Text;
                string angelegt_am = DateTime.Now.ToString("yyyy-MM-dd");

                //sql befehl
                com.CommandText = "update Auftrag set Auftragsnummer ='" + auftragsnummer + "', Artikelnummer ='" + artikelnummer + "', Stueckzahl =" + stückzahl + ", Liefertermin ='" + liefertermin + "', Startdatum_Produktion='" + startdatumProduktion + "', Kommentar='" + kommentar + "'where Auftragsnummer = '" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
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
            string[] txtBoxen = { txtAuftragsnummer.Text, txtArtikelnummer.Text, txtStückzahl.Text, dpLiefertermin.Text, dpStartdatumDerProduktion.Text };
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
