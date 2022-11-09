using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PichlerUndStroblDashbaord
{
    public partial class AuftragspoolAnzeige : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public AuftragspoolAnzeige()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            //sql befehl
            com.CommandText = "select Auftragsnummer,Artikelnummer,Stueckzahl,Liefertermin,Angelegt_Am,Kommentar,Stueckzahl_Gut, Stueckzahl_Schlecht, Stueckzahl_Nacharbeit from Auftrag";
            dr = com.ExecuteReader();
            //daten aus der datenbank in die gridview schreiben
            SqlDataAdapter dataAdp = new SqlDataAdapter(com);
            DataTable dt = new DataTable("Auftrag");
            dr.Close();
            dataAdp.Fill(dt);
            dgAuftragspool.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);
        }

        //drücken schließen button
        private void btnSchließen_Click(object sender, RoutedEventArgs e)
        {
            //aktuelles fenster schließen
            this.Close();
        }
    }
}