   M S B A M L   `   `   `  ????T  PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord  5   	   =    7PichlerUndStroblDashbaord.ArtikelnummerSuchenBearbeiten   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:PichlerUndStroblDashbaord  5   	     ? Title$  ArtikelnummerSuchen??5	   	   $	??500??5
   	   $	??150??6    ? 
ResizeMode$ NoResize=?6"    ? WindowStartupLocation$ CenterScreen=?68    ? AllowsTransparency .  ? WindowStyle$
 None=?6w   .??5      ? ???	#FF000102.+?5   
   ?? $??0q?6   .+?5      ?? $.??(Welchen Artikel möchten Sie bearbeiten???6   $
??Left=?6F   $??	40,20,0,0q?6a   $	??Top=?6t   
???????$??20(?6?   ?? 5       ?? Orientation$ 
Horizontal=?6   $??
40,20,0,10q?62   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=?6*   $??25??68   $??24??6C   
???????$??0q?6b   ?? 5      -   5         ??Name$ txtArtikelnummer??5      $??0q?64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Artikelnummer eingeben??6?   
???????$	??250??6?   
???????	 ?? 
CaretBrush	 ?	#FFD94448
 ?? SelectionBrush
 ?	#FFD944486?   5      5      ?? 5   
   -   5         ??Name$ btnSchließen??5   "   $??456,10,10,110q?5       &  "MaterialDesignFloatingActionButton#??[  6(    ? ToolTip$ Close??5      $
??Auto??6S   $
??Auto??6a   ??5   d   Z? .??5        $ Close=?6&   
???????$??30??6F   $??30??6Q   6_   5      ?? 5   
   -   5        $ btnSuche??5      #??[  5      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible .    Value$ 20Q?5         IsIndeterminate .  $??250,40,33,0q?5      $??40??6"   $??40??6-   ??5      0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ArrowRightBold=?5   9   5      5      