   M S B A M L   `   `   `  ????T  PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord  5   	   C    =PichlerUndStroblDashbaord.AuftragAusbuchenStückzahlerfassung   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PichlerUndStroblDashbaord     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	??350??5	   	   $	??700??6     ? WindowStartupLocation$  CenterScreen=?6"    ? WindowStyle$
 None=?6G    ? 
ResizeMode$ NoResize=?6Z   .??5
      ? 
???   ?.+?5   
   ?? -   5         ??Name$ lblÜberschrift??5   ?   $*??$Füllen Sie die folgenden Felder aus??6   $
??Left=?6>   $??
130,31,0,0q?6Y   $	??Top=?6m   
???????$??30(?6?   6?   ? 5   
   $??5??6   $??	0,116,0,0q?6   $	??Top=?6-   ??5      ?? 5       ?? 
StartPoint$ 0.1,0&?6&    ?? EndPoint$ 0.9,1&?69   .??5      ?  ? Color$ 	#FF30B4E6??6#    ? Offset$ 1Q?65   ? 5      $ 	#FFFE04D1??6#   $ 0Q?65   5      5      ?? 5   
   $??Stückzahl Gut??6   $
??Left=?6(   $??
57,151,0,0q?6C   
???????$??24??6j   $	??Top=?6v   ?? 5   
    ?? Orientation$ 
Horizontal=?6   $??25,168,456,154q?6.   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$!	 CheckboxMarkedCircleOutline=?6&   $??25??6I   $??25??6T   
???????6`   ?? 5      -   5        
 ??Name$
 txtStückzahlGut??5      $
??10 0q?6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Stückzahl eingeben??6=   
???????$	??154??6?   
??????? ?? 
CaretBrush ?	#FFD94448 ?? SelectionBrush ?	#FFD94448.  (MaterialDesignThemes.Wpf.TextFieldAssist   
SuffixText$
 Stk.??6?   5      ?? 5    
   $??Stückzahl Schlecht??6   $
??Left=?6-   $??283,151,0,0q?6H   
???????$??24??6p   $	??Top=?6|   ?? 5!   
   $ 
Horizontal=?6   $??252,168,251,154q?6.   .+?5"        $	 DeleteCircleOutline=?6&   $??25??6A   $??25??6L   
???????6X   ?? 5#      -   5        $
 txtStückzahlSchlecht??5#      $
??10 0q?64   $ Stückzahl eingeben??6B   
???????$	??154??6?   
??????? ?	#FFD94448 ?	#FFD94448$
 Stk.??6?   5$      ?? 5'   
   $??Stückzahl Nacharbeit??6   $
??Left=?6/   $??506,151,0,0q?6J   
???????$??24??6r   $	??Top=?6~   ?? 5(   
   $ 
Horizontal=?6   $??475,168,28,154q?6.   .+?5)        $	 DeleteCircleOutline=?6&   $??25??6A   $??25??6L   
???????6X   ?? 5*      -   5        $
 txtStückzahlNacharbeit??5*      $
??10 0q?66   $ Stückzahl eingeben??6D   
???????$	??154??6?   
??????? ?	#FFD94448 ?	#FFD94448$
 Stk.??6?   5+      ? 5.   
   $??5??6   $??	0,227,0,0q?6   $	??Top=?6-   ??5/      ?? 50      $ 0.1,0&?6&   $ 0.9,1&?69   .??51      ? $ 	#FF30B4E6??6#   $ 1Q?65   ? 52      $ 	#FFFE04D1??6#   $ 0Q?65   53      55      ?? 57   
   -   5         ??Name$ btnSpeichern??57   ?   $??	Speichern??6   $
??Left=?6%   $??
50,259,0,0q?6@   $	??Top=?6T   $	??610??6l   $??60??6x   6?   58      59      