   M S B A M L   `   `   `  ����G  CSimpleTimers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SimpleTimersSimpleTimers  5   	   =#clr-namespace:SimpleTimers.ControlsSimpleTimers.Controls  5   	       SimpleTimers.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SimpleTimers     5   	   8controls#clr-namespace:SimpleTimers.Controls     5   	     � Title$  
MainWindow��5	   	    � WindowStartupLocation$ Manual=�5
   	    � Left$ 0��6(   
 � Top$ 0��61    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � Topmost$
 True��5   	    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	   $
��1920��5   	   $��28��5   	   	 � 	Resources	 5      
 �� MergedDictionaries �� Source�� 5   
   
 5      �� 5      $ Styles/ButtonStyles.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $��* �6   �� 5      $	��400 �6   �� 5       $��* �6   �� 5!      $	��400 �6   .+�5#   
   �� $	��Top=�6   $��0��6-   .+�5$      �� $
��auto��6   $��28��6&    �� Orientation$ 
Horizontal=�62   $��0,0,0,10q�6K   .+�5%      �� -   5        $��CloseButton��5%      $	��✕��6,   $
��Left=�68   $	��Top=�6S   $��24��6k   5&      �� 5'      -   5        $��SettingsButton��5'      $	��⚙��6/   $
��Left=�6;   $	��Top=�6V   $��24��6n   5(      �� 5)      $��5,2,1,1q�6   
�������$��12(�6=   $y�Hidden=�6K   .��6_   Simple Timers6n   5*      5+      5,      5-      