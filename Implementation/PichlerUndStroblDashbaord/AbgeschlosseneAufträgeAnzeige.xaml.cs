using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PichlerUndStroblDashbaord
{
    public partial class AbgeschlosseneAufträgeAnzeige : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public AbgeschlosseneAufträgeAnzeige()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            //sql befehl
            com.CommandText = "select Auftragsnummer,Ausgebucht_Am,Eingebucht_Am from AbgeschlosseneAuftraege";
            dr = com.ExecuteReader();
            //daten aus der datenbank in die gridview schreiben
            SqlDataAdapter dataAdp = new SqlDataAdapter(com);
            DataTable dt = new DataTable("AbgeschlosseneAuftraege");
            dr.Close();
            dataAdp.Fill(dt);
            dgAbgeschlosseneAufträge.ItemsSource = dt.DefaultView;
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