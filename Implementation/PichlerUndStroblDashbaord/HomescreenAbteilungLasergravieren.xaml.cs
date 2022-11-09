using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Windows.Threading;
using System.Data.SqlClient;
using System.Configuration;

namespace PichlerUndStroblDashbaord
{
    public partial class HomescreenAbteilungLasergravieren : Window
    {
        int mitarbeiter_id;
        string mitarbeiter_vorname;
        string mitarbeiter_nachname;
        public HomescreenAbteilungLasergravieren(int mitarbeiter_id, string mitarbeiter_vorname, string mitarbeiter_nachname)
        {
            InitializeComponent();
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

            //---------------Code-Behind für Statistik 1 Balkendiagramm-------------
            SeriesCollectionChart1 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Neue Artikel",
                    Values = new ChartValues<double> { 10, 50, 25, 55 }
                },
                 new ColumnSeries
                {
                    Title = "Neue Aufträge",
                    Values = new ChartValues<double> { 8, 55, 10, 40 }
                }
            };

            LabelsChart1 = new[] { "A", "B", "C", "D" };
            FormatterChart1 = value => value.ToString("N");

            DataContext = this;
            //------------------------------------------------------------------------------------------------
            //---------------Code-Behind für Statistik 2 BALKENDIAGRAMM-----------
            SeriesCollectionChart2 = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Preis von XY1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Preis von XY2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Preis von XY3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
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
        

        private void btnAbmelden_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //funktion die vom tier jede millisekunde aufgerufen wird
        void timer_Tick(object sender, EventArgs e)
        {
            lblUhrzeit.Content = DateTime.Now.ToString("D");
        }


        private void btnWarteschlangeAnzeigen_Click(object sender, RoutedEventArgs e)
        {
            WarteschlangeAnzeige warteschlangeAnzeige = new WarteschlangeAnzeige();
            warteschlangeAnzeige.Show();
        }

        private void btnAuftragEinbuchen_Click(object sender, RoutedEventArgs e)
        {
            AuftragEinbuchen auftragEinbuchen = new AuftragEinbuchen();
            auftragEinbuchen.Show();
        }

        private void btnAuftragAusbuchen_Click(object sender, RoutedEventArgs e)
        {
            AuftragAusbuchen auftragAusbuchen = new AuftragAusbuchen();
            auftragAusbuchen.Show();
        }

        private void btnAbgeschlosseneAufträge_Click(object sender, RoutedEventArgs e)
        {
            AbgeschlosseneAufträgeAnzeige abgeschlosseneAufträgeAnzeige = new AbgeschlosseneAufträgeAnzeige();
            abgeschlosseneAufträgeAnzeige.Show();
        }
    }
}