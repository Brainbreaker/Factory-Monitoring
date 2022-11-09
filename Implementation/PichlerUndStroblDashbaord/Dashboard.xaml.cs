using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Media;
using Microsoft.Win32;
using System.ComponentModel;

namespace PichlerUndStroblDashbaord
{
    public partial class Dashboard : Window
    {
        int mitarbeiter_id;
        string mitarbeiter_vorname;
        string mitarbeiter_nachname;

        //defintionen für die datenbankverbindung
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public Dashboard(int mitarbeiter_id, string mitarbeiter_vorname, string mitarbeiter_nachname)
        {
            InitializeComponent();
            //datenbankverbindung öffnen
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
            con.Open();
            com.Connection = con;

            //Timer um jede Millisekunde eine Methode aufzurufen
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //Variable Benutzername zum weitergben an andere Screen
            this.mitarbeiter_id = mitarbeiter_id;
            this.mitarbeiter_vorname = mitarbeiter_vorname;
            this.mitarbeiter_nachname = mitarbeiter_nachname;
            lblBenutzername.Content = "Benutzer: " + mitarbeiter_vorname + " " + mitarbeiter_nachname;

            //---------------Code-Behind für Statistik 1 Balkendiagramm BESTELLÜBERSICHT-------------
           SeriesCollectionChart1 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Neue Artikel",
                    Values = new ChartValues<double> { 0, 0, 3, 4, 3, 2, 4, 0, 0, 2}
                },
                 new ColumnSeries
                {
                    Title = "Neue Aufträge",
                    Values = new ChartValues<double> { 0, 0, 4, 2, 4, 1, 1, 0, 0, 2}
                }
            };
            
            LabelsChart1 = new[] { "A", "B", "C", "D" };
            FormatterChart1 = value => value.ToString("N");

            DataContext = this;
            //------------------------------------------------------------------------------------------------
            //---------------Code-Behind für Statistik 2 BALKENDIAGRAMM BESTELLWERT-----------
            SeriesCollectionChart2 = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Bestellpreis",
                    Values = new ChartValues<double> { 0, 0, 16000, 20000 ,10000, 18000, 14000, 0, 0, 5000}
                },
            };

            Labels2 = new[] { "Jan", "Feb", "Mär", "Apr", "Mai" };
            Formatter2 = value => value.ToString("C");

            DataContext = this;
            //------------------------------------------------------------------------------------------------

            //---------------Code-Behind für Chart 3 TORTENDIAGRAMM---------------
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

            //---------------Code-Behind für Chart 4 BLASENDIAGRAMM---------------
            SeriesCollectionChart4 = new SeriesCollection
            {
                new ScatterSeries
                {
                    Values = new ChartValues<ScatterPoint>
                    {
                        new ScatterPoint(5, 5, 20),
                        new ScatterPoint(3, 4, 80),
                        new ScatterPoint(7, 2, 20),
                        new ScatterPoint(2, 6, 60),
                        new ScatterPoint(8, 2, 70)
                    },
                    MinPointShapeDiameter = 15,
                    MaxPointShapeDiameter = 45
                },
                new ScatterSeries
                {
                    Values = new ChartValues<ScatterPoint>
                    {
                        new ScatterPoint(7, 5, 1),
                        new ScatterPoint(2, 2, 1),
                        new ScatterPoint(1, 1, 1),
                        new ScatterPoint(6, 3, 1),
                        new ScatterPoint(8, 8, 1)
                    },
                    PointGeometry = DefaultGeometries.Triangle,
                    MinPointShapeDiameter = 15,
                    MaxPointShapeDiameter = 45
                }
            };

            DataContext = this;
        }

        //Binding zu den XAML Koponenten
        //Chart 1
        public SeriesCollection SeriesCollectionChart1 { get; set; }
        public string[] LabelsChart1 { get; set; }
        public Func<double, string> FormatterChart1 { get; set; }

        //Chart 2
        public SeriesCollection SeriesCollectionChart2 { get; set; }
        public string[] Labels2 { get; set; }
        public Func<double, string> Formatter2 { get; set; }

        //Chart 3
        public Func<ChartPoint, string> PointLabel { get; set; }

        //Chart4
        public SeriesCollection SeriesCollectionChart4 { get; set; }



        //Klickfunktion für das Tortendiagramm Chart 3
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear ausgewähltes Stück.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

 //-----------------------------------------------------------------------------------------BUTTONS------------------------------------------------------------------------------
        private void btnArtikelHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            ArtikelHinzufuegen artikelHinzufuegen = new ArtikelHinzufuegen(mitarbeiter_id);
            artikelHinzufuegen.Show();
        }

        private void btnArtikelBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            ArtikelnummerSuchenBearbeiten artikelnummerSuchenBearbeiten = new ArtikelnummerSuchenBearbeiten();
            artikelnummerSuchenBearbeiten.Show();
        }

        private void btnArtikelLöschen_Click(object sender, RoutedEventArgs e)
        {
            ArtikelnummerSuchenLöschen artikelnummerSuchenLöschen = new ArtikelnummerSuchenLöschen();
            artikelnummerSuchenLöschen.Show();
        }

        private void btnAuftragHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            AuftragHinzufügen auftragHinzufügen = new AuftragHinzufügen(mitarbeiter_id);
            auftragHinzufügen.Show();
        }

        private void btnAuftragBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            AuftragsnummerSuchenBearbeiten auftragsnummerSuchenBearbeiten = new AuftragsnummerSuchenBearbeiten();
            auftragsnummerSuchenBearbeiten.Show();
        }

        private void btnAuftragLöschen_Click(object sender, RoutedEventArgs e)
        {
            AuftragsnummerSuchenLöschen auftragsnummerSuchenLöschen = new AuftragsnummerSuchenLöschen();
            auftragsnummerSuchenLöschen.Show();
        }

        private void btnAbmelden_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnArtikelpoolanzeigen_Click(object sender, RoutedEventArgs e)
        {
            ArtikelpoolAnzeige artikelpoolAnzeige = new ArtikelpoolAnzeige();
            artikelpoolAnzeige.Show();
        }

        private void btnAuftragspoolanzeigen_Click(object sender, RoutedEventArgs e)
        {
            AuftragspoolAnzeige auftragspoolAnzeige = new AuftragspoolAnzeige();
            auftragspoolAnzeige.Show();
        }

        //funktion die vom timer jede millisekunde aufgerufen wird
        void timer_Tick(object sender, EventArgs e)
        {
            lblUhrzeit.Content = DateTime.Now.ToString("D");
        }
    }
}