   M S B A M L   `   `   `  ????U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   T PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord 5   	   A   ;PichlerUndStroblDashbaord.HomescreenAbteilungLasergravieren   5   	   <lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:PichlerUndStroblDashbaord  5   	     ? Title$  	Dashboard??5
   	   $
??1400??5   	   $	??800??6    ? 
ResizeMode$ NoResize=?6#    ? WindowStartupLocation$ CenterScreen=?69    ? AllowsTransparency .  ? WindowStyle$
 None=?6x   .??5      ? ???	#FF502757.+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=?6#   $??16q?65   ???	#FF000102.??5      ]? $??
1300,0,0,0q?6   .+?5      ??  ?? Orientation$ 
Horizontal=?6   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+?5      ?? -   5         ??Name$ btnAbmelden??5   M   
?????? 	 ? ToolTip$	 Abmelden??6?   ??6   0  *MaterialDesignThemes.Wpf.PackIconExtension  
   Kind$
 Logout=?6?   5      5      5      ?? 5   
   -   5         ??Name$ 
lblUhrzeit??5   ?   $??Diesntag, 06.Juli.2021??6   $
??Left=?61   $??1121,14,0,0q?6L   $	??Top=?6a   
???????$??20(?6?   6?   ?? 5   
   $??Abteilung Lasergravieren??6   $
??Left=?63   $??	27,10,0,0q?6N   $	??Top=?6a   
???????$??30(?6?   6?   ?? 5   
   -   5        $ lblBenutzername??5   ?   $??Benutzername??6   $
??Left=?6'   $??
426,16,0,0q?6B   $	??Top=?6V   
???????$??20(?6?   6?   #  MaterialDesignThemes.Wpf.Card  5   
   
???   ? !  PrimaryHueDarkForegroundBrush#???   61   $??8q?6n      UniformCornerRadius$ 0Q?6z   $??0,64,1100,0q?6?   5        5    
   $??28,68,1123,20q?6   
?????? .??5!      ?? $??	0,0,0,-93q?6   .+?5#      ?? -   5        $ btnWarteschlangeAnzeigen??5#   ?    J? RenderTransformOrigin$ 0.244,0.594&?6   $??61??6=   $??5q?6I   
???????+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6g   .??5$      ?? .+?5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChartSankeyVariant=?62   $??24??6L   $??25??6W   
???   ?$??Center=?6v   ?? 5&       ?? TextAlignment$ Center=?6$   
???   ??? 6O   $?Warteschlange anzeigen??6S   6t   5'      5(      ?? 5*      -   5        $ btnAuftragEinbuchen??5*   ?   $ 0.5,0.5&?6   $??61??69   $??5q?6E   
???????$ 10??6c   .??5+      ?? .+?5,        $ 
QrcodeScan=?62   $??24??6D   $??25??6O   
???   ?$??Center=?6n   ?? 5-      $ Center=?6$   
???   ??? 6O   $?Auftrag einbuchen??6S   6o   5.      5/      ?? 51      -   5        $ btnAuftragAusbuchen??51   ?   $ 0.244,0.594&?6   $??61??6=   $??5q?6I   
???????$ 10??6g   .??52      ?? .+?53        $ 
QrcodeScan=?62   $??24??6D   $??25??6O   
???   ?$??Center=?6n   ?? 54      $ Center=?6$   
???   ??? 6O   $?Auftrag ausbuchen??6S   6o   55      56      ?? 58      -   5        $  btnAbgeschlosseneAufträge??58   ?   $ 0.244,0.594&?6   $??61??6=   $??5q?6I   
???????$ 10??6g   .??59      ?? .+?5:        $ Notebook=?62   $??24??6B   $??25??6M   
???   ?$??Center=?6l   ?? 5;      $ Center=?6$   
???   ??? 6O   $?Abgeschlossene Aufträge??6S   6u   5<      5=      5>      5?        5B   
   $
??Left=?6   $??357,120,0,0q?69   $	??Top=?6N   $	??300??6f   $	??450??6s   .??5C      #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=?6!   $
??Left=?6c   $	??330??6~   $??	10,10,0,0q?6?   $	??Top=?6?   $	??416??6?      Series 69   ?? *SeriesCollectionChart1+6?   5D        5G   
   $
??Left=?6   $??904,120,0,0q?69   $	??Top=?6N   $	??300??6f   $	??450??6s   .??5H        $
??Left=?6K   $	??330??6f   $??	10,10,0,0q?6s   $	??Top=?6?   $	??416??6?    6!   ?? *SeriesCollectionChart2+6?   5I        5L   
   $
??Left=?6   $??357,480,0,0q?69   $	??Top=?6N   $	??300??6f   $	??450??6s   .??5M      	   LiveCharts.Wpf.PieChart	  -   5        $ Bottom=?5M         	Hoverable .     DataTooltip 6c   Z?  5O      
   LiveCharts.Wpf.PieSeries
     LiveCharts.Wpf.Series   Title$ 
Carl Zeiss??6$      Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 6 67      
DataLabels .     
LabelPoint 5P       ?? *
PointLabel+
  5Q      $	 VAT??6$   $ 4 60    .   5R       ?? *
PointLabel+
  5S      $
 Audi??6$   $ 2 61    .   5T       ?? *
PointLabel+5V      5W        5Z   
   $
??Left=?6   $??904,480,0,0q?69   $	??Top=?6N   $	??300??6f   $	??450??6s   .??5[        $??1??6!    6.   ?? *SeriesCollectionChart4+5\      ?? 5_   
   $??Produktivität??6   $??Center=?6(   $??498,72,726,0q?6E   $	??Top=?6[   
???????$??30(?6?   ?? 5`   
   $??Preisentwicklung??6   $??Center=?6+   $??1016,72,154,0q?6H   $	??Top=?6_   
???????$??30(?6?   ?? 5a   
   $??Kunden??6   $??Center=?6!   $??529,432,761,0q?6>   $	??Top=?6U   
???????$??30(?6?   ?? 5b   
   $??Auftragsgrößen??6   $??Center=?6)   $??1030,432,154,0q?6F   $	??Top=?6^   
???????$??30(?6?   $	??216??6?   5d      5e      