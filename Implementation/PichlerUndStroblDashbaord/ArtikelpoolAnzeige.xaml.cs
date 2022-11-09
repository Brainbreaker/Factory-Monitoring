using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PichlerUndStroblDashbaord
{
    public partial class ArtikelpoolAnzeige : Window
    {
        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public ArtikelpoolAnzeige()
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;
            //sql befehl
            com.CommandText = "select Artikelname,Artikelnummer,Revision,Bearbeitungszeit_Soll,Bearbeitungszeit_Ist,Preis,Kommentar,Angelegt_Am,Kundenname from Artikel";
            dr = com.ExecuteReader();
            //daten aus der datenbank in die gridview schreiben
            SqlDataAdapter dataAdp = new SqlDataAdapter(com);
            DataTable dt = new DataTable("Artikel");
            dr.Close();
            dataAdp.Fill(dt);
            dgArtikelpool.ItemsSource = dt.DefaultView;
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