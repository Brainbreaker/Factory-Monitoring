using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PichlerUndStroblDashbaord
{
    public partial class WarteschlangeAnzeige : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public WarteschlangeAnzeige()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            //sql befehl
            com.CommandText = "select Auftragsnummer,Standzeit,Eingebucht_Am from Warteschlange";
            dr = com.ExecuteReader();
            //daten aus der datenbank in die gridview schreiben
            SqlDataAdapter dataAdp = new SqlDataAdapter(com);
            DataTable dt = new DataTable("Warteschlange");
            dr.Close();
            dataAdp.Fill(dt);
            dgWarteschlange.ItemsSource = dt.DefaultView;
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