   M S B A M L   `   `   `  ????T  PPichlerUndStroblDashbaord, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PichlerUndStroblDashbaordPichlerUndStroblDashbaord  5   	   *    $PichlerUndStroblDashbaord.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3local'clr-namespace:PichlerUndStroblDashbaord  5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? WindowStartupLocation$ CenterScreen=?65    ? WindowStyle$
 None=?6Z    ? 
ResizeMode$ NoResize=?6m   .??5
      ? -   5        ??5   
   ?? 5       ?? 
StartPoint$ 0.1,0&?6"    ?? EndPoint$ 0.9,1&?65   .??5      ?  ? Color$ 	#FF30B4E6??6    ? Offset$ 1Q?61   ? 5      $ 	#FFFE04D1??6   $ 0Q?61   5      .+?5   
   ?? $	??390??6   $	??Top=?6    ?? CornerRadius$ 	0 0 180 0??66   
???   ?._?5      ?? $??Factory Monitoring??6   
???????$??40(?6D   $??Century Gothic)?6R   $??Center=?6n   $??0,390,0,-400q?6?   5      ?? 5   
   	 ?? Orientation$	 
Horizontal=?6   .+?5      ?? $	??350??6   .+?5      ?? $??30 60q?6   .+?5      ?? $??Anmelden??6    $??10q?60   
???????
 ?? TextAlignment$
 Center=?6O   $??50(?6f   $??Arial)?6t   6?   ?? 5      $	 
Horizontal=?6!   $??10q?6:   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=?62   $??25??6>   $??25??6I   
???????6U   ?? 5      -   5         ??Name$ txtBenutzername??5   "   $
??10 0q?6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Benutzername eingeben??6I   
???????$	??250??6?   
??????? ?? 
CaretBrush ?	#FFD94448 ?? SelectionBrush ?	#FFD944486?   5      ?? 5      $	 
Horizontal=?6!   $??10q?6:   .+?5        $
 Lock=?62   $??25??6>   $??25??6I   
???????6U   G? 5      -   5         G?Name$ txtPasswort??5   &   $
??10 0q?6;   $ Passwort eingeben??6I   
???????$	??250??6?   
??????? G? 
CaretBrush ?	#FFD94448 G? SelectionBrush ?	#FFD944486?   5      ?? 5       $	 
Horizontal=?6!   $??
13,5,10,10q?6:   .+?5!      ?? -   5         ??Name$ cbPasswortÄndern??5!   S   
???????$??   Passwort ändern??66   $??0q?6?    ? 	Resources 5"         MaterialDesignCheckBoxOff ?? Color  PrimaryHueMidBrush??%Z   &	        &	 #     ?? 5#   "   $ 	#FFA62CAC??6T   ?? 5$   "   $ 	#FFA62CAC??6M   5%      5&      5'      ?? 5(      $	 
Horizontal=?6!   $
??10,0q?6:   .+?5)        -   5          Name$ iconPasswortÄndern??5)   h   $
 Lock=?62   $??25??6>   $??25??6I   
???????$y?Hidden=?6?   G? 5*      -   5        $ txtNeuesPasswort??5*   &   $
??10 0q?6@   $ Neues Passwort eingeben??6N   
???????$	??250??6?   
??????? ?	#FFD94448 ?	#FFD94448$y?Hidden=?6?   5+      ?? 5,      $??10q?6!   $??Center=?6-   .+?5-      ?? -   5         ??Name$ btnAnmelden??5.   [   $	??100??5-   !   $??40??6-     MaterialDesignRaisedButton#??[ 69   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6m   $??2q?6?   ???	#FFA62CAC???	#FFA62CAC
??????? ? ToolTip$ Login??5.   K   $??Login??6?   5/      50      51      52      ?? 53      $	??350??6   .+?55      ?? -   5        $??MyImage??55      $(??"Images/login-image-slideshow-1.jpg??6'   $	??335??6S   $	??335??6_   $??Center=?6l    J? RenderTransformOrigin$ 0.5, 0.5&?6?   $
??10 0q?6?   z?56      ?? 57      59      5:      ?? 5;      $	??100??6   .+?5<      ?? -	   5        $ btnVerlassen??5<   z   $??10 20q?6    & "MaterialDesignFloatingActionButton#??[ 6(   ??6d   Z? .??5=        $ Close=?6.   
???????$??30??6N   $??30??6Y   6g   5>      5?      5@      ?? 5A   
   $??10q?6   .+?5B      ?? -
   5        $??MyRectangle??5B      $??0??6+   $??0??65   
????  ? ? Triggers 5C      :? 5E       :? RoutedEvent$ Rectangle.Loaded??6#   .[?5F      ?? .??5G      ?? .??5H   "   W?  ?? 
TargetName$ MyImage??62    ?? TargetProperty$9 3(UIElement.RenderTransform).(RotateTransform.Angle)?6R    W? From$ 0X?5I   !   	  W? To$	  360X?6*   ! g? Duration$! 0:0:20D?63   " g? AutoReverse" . # g? RepeatBehavior$# Forever??6X   5J      5K      5L      5N      5O      5P      5Q      