   M S B A M L   `   `   `  ????T  PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord  5   	   >    8PichlerUndStroblDashbaord.AbgeschlosseneAufträgeAnzeige   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PichlerUndStroblDashbaord     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	??800??5	   	   $
??1400??6     ? WindowStartupLocation$  CenterScreen=?6#    ? WindowStyle$
 None=?6H    ? 
ResizeMode$ NoResize=?6[    ? 	Resources 5         clBr ?? Color??%)   &	        ?? 5   
   $ Green??6'   5      .??5      ? 
???   ?.+?5   
   ?? $??Abgeschlossene Aufträge??6   $
??Left=?62   $??
500,31,0,0q?6M   $	??Top=?6a   
???????$??40(?6?   ? 5   
   $??5??6   $??
0,98,0,661q?6   ??5      ?? 5       ?? 
StartPoint$ 0.1,0&?6&    ?? EndPoint$ 0.9,1&?69   .??5      ?  ? Color$ 	#FF30B4E6??6#    ? Offset$ 1Q?65   ? 5      $ 	#FFFE04D1??6#   $ 0Q?65   5      5      ?? 5   
   $?? ??6   $
??Left=?6   $??100,137,0,0q?66   $	??Top=?6K   
???????$??20(?6v   
???????$
??1200??6?   $??20??6?   	 J? Opacity$	 1Q?6?   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dgAbgeschlosseneAufträge??5   u   $
??Left=?6   $	??556??6.   $??100,126,0,0q?6;   $	??Top=?6P   $
??1200??6h      AutoGenerateColumns . 
?????? 
???????6?   ? 5!   
   $??5??6   $??
0,602,0,22q?6   ??5"      ?? 5#      $ 0.1,0&?6&   $ 0.9,1&?69   .??5$      ? $ 	#FF30B4E6??6#   $ 1Q?65   ? 5%      $ 	#FFFE04D1??6#   $ 0Q?65   5&      5(      ?? 5,   
   -   5         ??Name$ btnSchließen??5,   ?   $??1324,20,20,724q?6    & "MaterialDesignFloatingActionButton#??[ 6)    ? ToolTip$ 
Schließen??6{   ??6e   Z? .??5-      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6&   
???????$??30??6F   $??30??6Q   6_   5.      50      51      