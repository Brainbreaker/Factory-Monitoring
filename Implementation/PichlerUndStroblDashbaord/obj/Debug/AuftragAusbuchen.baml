   M S B A M L   `   `   `  ????T  PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord  5   	   0    *PichlerUndStroblDashbaord.AuftragAusbuchen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:PichlerUndStroblDashbaord  5   	     ? Title$  ArtikelnummerSuchen??5	   	   $	??500??5
   	   $	??400??6    ? 
ResizeMode$ NoResize=?6"    ? WindowStartupLocation$ CenterScreen=?68    ? AllowsTransparency .  ? WindowStyle$
 None=?6w   .??5      ? ???	#FF000102.+?5   
   ?? -   5        $??MyImage??5      $??Images/qrcode.png??6   $	??113??6:   $??Center=?6G    J? RenderTransformOrigin$ 	0.532,0.4&?6b   $??194,110,191,82q?6?   z?5      ?? 5      5      ?? 5   
   $??0q?6   .+?5      ?? $??Auftrag Ausbuchen??6   $
??Left=?60   $??
125,20,0,0q?6K   $	??Top=?6_   
???????$??30(?6?   ?? 5      $0??*Bitte scannen Sie den QR-Code des Auftrags??6   $
??Left=?6I   $??	45,40,0,0q?6d   $	??Top=?6w   
???????$??20(?6?   ?? 5      -   5         ??Name$ txtAuftragsnummer??5      $??202,120,196,0q?61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ QR-Code scannen??6H   
???????
??????? ?? 
CaretBrush ?	#FFD94448	 ?? SelectionBrush	 ?	#FFD94448$??Center=?6?   5      ?? 5   
   -   5        
 ??Name$
 btnSchließen??5   "   $??456,10,10,356q?5       &  "MaterialDesignFloatingActionButton#??[  6(    ? ToolTip$ Close??5      $??34??6S   $??34??6_   ??5   d   Z? .??5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6&   
???????$??30??6F   $??30??6Q   6_   5      ?? 5    
   -   5        $
 btnAusbuchen??5       #??[  5!      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible .    Value$ 20Q?5#         IsIndeterminate .  
?????? $??228,290,232,10q?5&      $??40??6%   $??40??60   ??5%      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ArrowUpBold=?5&   <   5'      5(      