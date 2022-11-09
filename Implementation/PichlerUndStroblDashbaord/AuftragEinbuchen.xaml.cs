using System.Windows;
using System;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragEinbuchen : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public AuftragEinbuchen()
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
                    MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnEinbuchen, true);
                }
                //der benutzer hat noch nichts eingegeben
                else
                {
                    //verstecke die animation
                    MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnEinbuchen, false);
                }
            }
        }

        //drücken schließen button
        private void btnSchließen_Click(object sender, RoutedEventArgs e)
        {
            //aktuelles fenster schließen
            this.Close();
        }

        //drücken einbuchen button
        private void btnEinbuchen_Click(object sender, RoutedEventArgs e)
        {
            //QR-Code wurde gescannt
            if (txtAuftragsnummer.Text != "")
            {
                //buche Auftrag ein
                string auftragsnummer = txtAuftragsnummer.Text;
                int standzeit = 0;
                string eingebucht_am = DateTime.Now.ToString("yyyy-MM-dd");
                //sql befehl
                com.CommandText = "insert into Warteschlange values ('" + auftragsnummer + "', " + standzeit + ", '" + eingebucht_am + "')";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                //sql befehl ausführen
                dr = com.ExecuteReader();
                //datenbankverbindung schließen
                con.Close();
                //aktuelles fenster schließen
                this.Close();
            }
        }
    }
}
