   M S B A M L   `   `   `  ????G  CGUI_v0.1.2-b, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GUI_v0._1._2_bGUI_v0._1._2_b  5   	   M+clr-namespace:GUI_v0._1._2_b.MVVM.ViewModelGUI_v0._1._2_b.MVVM.ViewModel  5	   	       GUI_v0._1._2_b.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GUI_v0._1._2_b     5   	   A	viewModel+clr-namespace:GUI_v0._1._2_b.MVVM.ViewModel     5	   	   $	??650??5   	   $
??1200??6   ???#36393F  ? WindowStyle$
  None=?68    ? AllowsTransparency .  ? 
ResizeMode$ CanResizeWithGrip=?6e    ? DataContext 5      1  +GUI_v0._1._2_b.MVVM.ViewModel.MainViewModel  5   
   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      $	??200 ?6   ?? 5      .+?5   
   ?? -   5        $??2??5      ???#252525._?5      ? $??Stretch=?6   .+?5      ?? $??Dawa IDE??6   
???????$??SemiBold"?6>   $??8,0,0,0q?6T   ?? 5       $??Right=?6    ?? Orientation$ 
Horizontal=?69   .+?5!      ?? -   5        $??20??5!      $??20??6(   $??_??64   
?????? $??0q?6Y   
???????$
??Bold"?6   $??0,0,0,3q?6?   5"      ?? 5#      -   5        $??20??5#      $??20??6(   $	??☐??64   
?????? $??0q?6Y   
???????$
??Bold"?6   5$      ?? 5%      -   5        $??20??5%      $??20??6(   $	??╳??64   
?????? $??0q?6Y   
???????$
??Bold"?6   $??0,0,8,0q?6?   5&      5'      5(      5)      ? 5,   
   $??1??6   .+?5-      ?? $??Center=?6   $??Center=?66   $ 
Horizontal=?6Q   .+?5.      o? 
?????? .@?5/      m? $??Project??6   ???#FEFEFE$??25??6E   $??12(?6Q   .@?50      m? $??Create??6#   ???#292B2F63   m? 51      $??Open Project??6#   ???#292B2F69   m? 52      $??Close Project??6#   ???#292B2F6:   53      m? 54      $
??File??6   ???#FEFEFE$??25??6B   $??12(?6N   .@?55      m? $	??New??6#   ???#292B2F m? Command 6E   ?? *FileViewCommand+m? 56      $
??Open??6#   ???#292B2F 6F   ?? *OpenFileCommand+m? 57      $??
Close File??6#   ???#292B2F 6L   ?? *HomeViewCommand+m? 58      $
??Save??6#   ???#292B2F 6F   ?? *SaveFileCommand+m? 59      $??Save As??6#   ???#292B2F 6I   ?? *SaveAsFileCommand+5:      m? 5;      $
??Edit??6   ???#FEFEFE$??25??6B   $??12(?6N   .@?5<      m? $??Search??6#   ???#292B2F 6H   ?? *SearchCommand+m? 5=      $??Replace??6#   ???#292B2F 6I   ?? *ReplaceCommand+m? 5>      $
??Copy??6#   ???#292B2F61   m? 5?      $	??Cut??6#   ???#292B2F60   m? 5@      $??Paste??6#   ???#292B2F62   5A      m? 5B      $
??Help??6   ???#FEFEFE$??25??6B   $??12(?6N   .@?5C      m? $??See Simbols??6#   ???#292B2F 6M   ?? *SeeSimbolCommand+5D      5E      5F      5G      ? 5J   
   ???#2F3136$??1??6$    5K      ?? 5L      $??50 ?6    ?? 5M      ?? 5N      $??60 ?6    .+?5Q      ?? $??Project??6   $??Center=?6&   $??Medium"?6A   
???????$??8,0,0,0q?6g   ?? 5S      $??2??6   $ 
Horizontal=?6&   ???#292B2F.+?5T      ??  ?? CornerRadius$ 25??6   $??30??6+   $??30??66   ???#3bff6f$??18,0,0,0q?6W   ?? 5U      $??Center=?6   .+?5V      ?? $
??Eddy??6   
???????$??SemiBold"?6>   $??10(?6T   $??	0,-5,0,-5q?6b   ?? 5W      $??GitHub: Online??6   
???????$??SemiBold"?6G   $??10(?6]   $??	0,-8,0,-5q?6k   5X      ?? 5Y      $??About Us??6   ???#3F88C5$??SemiBold"?6A   $??10(?6W   $??15??6e   $??	25,35,0,0q?6q   5Z      5[      ?? 5^   
   $??1??6   $??1??6)   
???????$??10q?6I   ??6U   ?? *CurrentView+5`      5b      5c      