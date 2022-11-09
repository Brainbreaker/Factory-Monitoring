using System;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class MainWindow : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        string abteilungskennzahl;
        int mitarbeiter_id;
        string mitarbeiter_vorname;
        string mitarbeiter_nachname;

        public MainWindow()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
        }

        //ändern der ansicht wenn die checkbox zum passwort ändern ausgewählt ist
        private void cbPasswortÄndern_Ausgewählt(object sender, RoutedEventArgs e)
        {
            txtNeuesPasswort.Visibility = Visibility.Visible;
            iconPasswortÄndern.Visibility = Visibility.Visible;
        }
        //ändern der ansicht wenn die checkbox zum passwort ändern nicht ausgewählt ist
        private void cbPasswortÄndern_NichtAusgewählt(object sender, RoutedEventArgs e)
        {
            txtNeuesPasswort.Visibility = Visibility.Collapsed;
            iconPasswortÄndern.Visibility = Visibility.Collapsed;
        }

        //drücken anmelden button
        private void btnAnmelden_Click(object sender, RoutedEventArgs e)
        {
            //überprüfung der eingegebenen Daten
            if (Anmeldeüberprüfung(txtBenutzername.Text, txtPasswort.Password))
            {//überprüfung erfolgreich
                dr.Close();
                //überprüfung ob der benutzer sein passwort ändern möchte
                if (cbPasswortÄndern.IsChecked == true)
                { //passwortänderung erwünscht
                    PasswortÄndern(txtBenutzername.Text, txtPasswort.Password);
                    öffneNächstenScreen();
                }
                else
                { //passwortänderung nicht erwünscht
                    öffneNächstenScreen();
                }
            }
            else
            {//überprüfung fehlerhaft
                dr.Close();
                MessageBox.Show("Benutzername oder Passwort falsch", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //drücken verlassen button
        private void btnVerlassen_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //--------------------------------------------------------------------------PRIVATE METHODEN-------------------------------------------------------------------------------------------
        private bool Anmeldeüberprüfung(string benutzername, string passwort)
        {
            //sql befehl
            com.CommandText = "select * from Mitarbeiter where Mitarbeiter_Kuerzel='" + benutzername + "' and Mitarbeiter_Passwort=HASHBYTES('SHA1','" + passwort + "')"; //<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                abteilungskennzahl = dr["Abteilung_ID"].ToString();
                mitarbeiter_id = Int32.Parse(dr["Mitarbeiter_ID"].ToString());
                mitarbeiter_vorname = dr["Mitarbeiter_Vorname"].ToString();
                mitarbeiter_nachname = dr["Mitarbeiter_Nachname"].ToString();
                //zugriff gewährt
                if (Convert.ToBoolean(dr["Zugriff_Status"]) == true) return true;
                //zugriff nicht gewährt
                return false;
            }
            //eingegebene daten wurden nicht gefunden
            return false;
        }

        private void PasswortÄndern(string benutzername, string passwort)
        {
            //sql befehl
            com.CommandText = "select Mitarbeiter_ID from Mitarbeiter where Mitarbeiter_Kuerzel='" + benutzername + "' and Mitarbeiter_Passwort=HASHBYTES('SHA1','" + passwort +"')";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
            //sql befehl ausführen und datareader öffnen
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                string neuesPasswort = txtNeuesPasswort.Password;
                //sql befehl
                com.CommandText = "update Mitarbeiter set Mitarbeiter_Passwort=HASHBYTES('SHA1', '" + neuesPasswort + "') where Mitarbeiter_ID='" + dr["Mitarbeiter_ID"] + "'";//<--------------------------------------------------SQL BEFEHL-MARKIERUNG
                //vorherigen datareader schließen
                dr.Close();
                //aktuellen sql befehl ausführen
                dr = com.ExecuteReader();
            }
        }

        private void öffneNächstenScreen()
        {
            //datenbankverbindung schließen
            con.Close();
            if (abteilungskennzahl == "1") //benutzer aus der abteilung büro
            {
                //auf nächsten screen wechseln
                Dashboard nextScreen = new Dashboard(mitarbeiter_id, mitarbeiter_vorname, mitarbeiter_nachname);
                this.Close();
                nextScreen.Show();
            }
            if (abteilungskennzahl == "2") //benutzer aus der abteilung lasergravieren
            {
                //auf nächsten screen wechseln
                HomescreenAbteilungLasergravieren nextScreen = new HomescreenAbteilungLasergravieren(mitarbeiter_id, mitarbeiter_vorname, mitarbeiter_nachname);
                this.Close();
                nextScreen.Show();
            }
        }

        //fenster verschieben
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
