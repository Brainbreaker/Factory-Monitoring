using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragAusbuchenStückzahlerfassung : Window
    {
        string auftragsnummer;
        bool vollsändigkeit = false;
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public AuftragAusbuchenStückzahlerfassung(string auftragsnummer)
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            this.auftragsnummer = auftragsnummer;
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Vollständigkeitsüberprüfung();
            if (vollsändigkeit)
            {
                int stückzahlGut = Int32.Parse(txtStückzahlGut.Text);
                int stückzahlSchlecht = Int32.Parse(txtStückzahlSchlecht.Text);
                int stückzahlNacharbeit = Int32.Parse(txtStückzahlNacharbeit.Text);

                //sql befehl
                com.CommandText = "update Auftrag set Stueckzahl_Gut =" + stückzahlGut + ", Stueckzahl_Schlecht =" + stückzahlSchlecht + ", Stueckzahl_Nacharbeit =" + stückzahlNacharbeit + "where Auftragsnummer = '" + auftragsnummer + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG                                                                                                                                                                                                                                                                                                                                                                         //sql befehl ausführen und datareade öffnen
                dr = com.ExecuteReader();
                //fenster schließen nach update
                this.Close();
            }
        }

        //vollständigkeitsprüfung methode
        private void Vollständigkeitsüberprüfung()
        {
            vollsändigkeit = true;
            string[] txtBoxen = { txtStückzahlGut.Text, txtStückzahlSchlecht.Text, txtStückzahlNacharbeit.Text};
            for (int i = 0; i < txtBoxen.Length; i++)
            {
                if (txtBoxen[i] != null && string.IsNullOrWhiteSpace(txtBoxen[i]))
                {
                    vollsändigkeit = false;
                    lblÜberschrift.Content = "Sie müssen alle Felder ausfüllen!";
                    lblÜberschrift.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
