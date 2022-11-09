using System.Windows;
using System;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragAusbuchen : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public AuftragAusbuchen()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            //Timer um jede Millisekunde eine Methode aufzurufen
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.001);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        //funktion die vom tier jede millisekunde aufgerufen wird
        void timer_Tick(object sender, EventArgs e)
        {
            {
                //der benutzer hat etwas eingegeben
                if (txtAuftragsnummer.Text != "")
                {
                    //zeige animation
                    MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnAusbuchen, true);
                }
                //der benutzer hat noch nichts eingegeben
                else
                {
                    //verstecke die animation
                    MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnAusbuchen, false);
                }
            }
        }

        //drücken schließen button
        private void btnSchließen_Click(object sender, RoutedEventArgs e)
        {
            //aktuelles fenster schließen
            this.Close();
        }

        //drücken ausbuchen button
        private void btnAusbuchen_Click(object sender, RoutedEventArgs e)
        {
            string auftragsnummer = txtAuftragsnummer.Text;
            //sql befehl
            com.CommandText = "select * from Warteschlange where Auftragsnummer='" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            //auftragnummer wurde in der warteschlange gefunden
            if (dr.Read())
            {
                //übertrag in tabelle abgeschlossene aufträge
                string ausgebucht_am = DateTime.Now.ToString("yyyy-MM-dd");
                string eingebucht_am = dr["Eingebucht_Am"].ToString();
                //sql befehl
                com.CommandText = "insert into AbgeschlosseneAuftraege values ('" + auftragsnummer + "', '" + ausgebucht_am + "', '" + eingebucht_am + "')";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                //datareader vonvorherigem sql befehl schließen
                dr.Close();
                //sql befehl ausführen
                dr = com.ExecuteReader();



                //sql befehl
                com.CommandText = "Delete Warteschlange where Auftragsnummer='" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                //datareader vonvorherigem sql befehl schließen
                dr.Close();
                //sql befehl ausführen und datareader öffnen
                dr = com.ExecuteReader();
                //datenbankverbindung schließen
                con.Close();

                //wechsle auf neuues fenster
                AuftragAusbuchenStückzahlerfassung auftragAusbuchenStückzahlerfassung = new AuftragAusbuchenStückzahlerfassung(auftragsnummer);
                auftragAusbuchenStückzahlerfassung.Show();

                //aktuelles fenster schließen
                this.Close();
            }
            //auftragsnummer wurde nicht in der warteschlange gefunden
            else
            {
                //zeige user dialog
                MessageBox.Show("Dieser Auftrag kann nicht ausgebucht werden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                //datareader schließen
                dr.Close();
            }
        }
    }
}
