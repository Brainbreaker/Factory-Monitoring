using System;
using System.Windows;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragsnummerSuchenBearbeiten : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public AuftragsnummerSuchenBearbeiten()
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

        //drücken Suche button
        private void btnSuche_Click(object sender, RoutedEventArgs e)
        {
            string auftragsnummer = txtAuftragsnummer.Text;
            //sql befehl
            com.CommandText = "select Auftragsnummer from Auftrag where Auftragsnummer='" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            //auftragsnummer wurde im auftragspool gefunden
            if (dr.Read())
            {
                //wechsle auf nächsten Screen
                AuftragBearbeiten auftragBearbeiten = new AuftragBearbeiten(auftragsnummer);
                auftragBearbeiten.Show();
                //datenbankverbindung schließen
                con.Close();
                //aktuelles fenster schließen
                this.Close();
            }
            //auftragsnummer wurde nicht im auftragspool gefunden
            else
            {
                //zeige user dialog
                MessageBox.Show("Auftragsnummer nicht gefunden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                //datareader schließen
                dr.Close();
            }
        }

        //funktion die vom tier jede millisekunde aufgerufen wird
        void timer_Tick(object sender, EventArgs e)
        {
            //der benutzer hat etwas eingegeben
            if (txtAuftragsnummer.Text != "")
            {
                //zeige animation
                MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnSuche, true);
            }
            //der benutzer hat noch nichts eingegeben
            else
            {
                //verstecke die animation
                MaterialDesignThemes.Wpf.ButtonProgressAssist.SetIsIndeterminate(btnSuche, false);
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