   M S B A M L   `   `   `  ����G  CSimpleTimers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SimpleTimers.WindowsSimpleTimers.Windows  5   	   =#clr-namespace:SimpleTimers.ControlsSimpleTimers.Controls  5   	   )    #SimpleTimers.Windows.SettingsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:SimpleTimers.Windows     5   	   8controls#clr-namespace:SimpleTimers.Controls     5   	     � Title$  SettingsWindow��5	   	   $	��600��5
   	   $	��800��6   .��5      � $	��600��6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��Padding$ 0,0,1,1q�6,   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   ._�5       )   #SimpleTimers.Controls.TimerSettings  -   5          Name$ timer1Settings��5    %      	TimerName$ Timer 1��6=   $��0,0,0,1q�6Q   
�������$��0,0,0,4q�6�   5!      �� 5"   
   $��1��6   $��0��6   ._�5#        -   5        $ timer2Settings��5#   %   $ Timer 2��6=   $��0,0,0,1q�6Q   
�������$��0,0,0,4q�6�   5$      �� 5%   
   $��2��6   $��0��6   ._�5&        -   5        $ timer3Settings��5&   %   $ Timer 3��6=   $��0,0,0,1q�6Q   
�������$��0,0,0,4q�6�   5'      �� 5(   
   $��3��6   $��0��6   ._�5)        -   5        $ timer4Settings��5)   %   $ Timer 4��6=   $��0,0,0,1q�6Q   
�������$��0,0,0,4q�6�   5*      �� 5+   
   $��4��6   $��0��6   ._�5,        -   5        $ timer5Settings��5,   %   $ Timer 5��6=   $��0,0,0,1q�6Q   
�������$��0,0,0,4q�6�   5-      �� 5/   
   $��0��6   $��2��6   $��2��6.   $��5��6B   ._�50      � $��Visible=�6   $
��True��6H    51      ��%_   '��       �� 52      " ��6   .�53      ��  �@��Padding$ 0,0,1,1q�64   54      55       57      �� 58      $��23 �6$   �� 59      $��23 �6$   �� 5:      $��23 �6$   �� 5;      $��23 �6$   �� 5<      $��23 �6$   �� 5=      $��23 �6$   �� 5>      $��23 �6$   �� 5?      $��* �6$    5A      �� 5B      $	��150 �6'   �� 5C      $
��Auto �6'   .+�5F      �� $��0��6   $��0��6&   ._�5G      �� $��Enable Image Overlay?��6   5H      �� 5J      $��1��6   $��0��6&   ._�5K      �� $��Show image numbers?��6   5L      �� 5N      $��2��6   $��0��6&   ._�5O      �� $��Overlay Image Opacity��6   $��1,1,1,1q�6<   5P      �� 5Q      $��2��6   $��1��6&   ._�5R      �� -   5        $ ��overlayImageOpacityTextBox��5R      $��40��5U      $
��Left=�6)   .��6D    5V      )  #System.Windows.Input.CommandBinding #  overlayImageOpacityTextBoxPaste	   Command��%D   &	          5X      -   5        $	 Paste��5X   U   5Z   -   5[      .��6-   5\      5]      �� 5_      $��3��6   $��0��6&   ._�5`      �� $��Previous Image Hotkey��6   $��1,1,1,1q�6<   5a      �� 5b      $��3��6   $��1��6&   ._�5c      '   !SimpleTimers.Controls.HotkeyInput  6-   5d      �� 5f      $��4��6   $��0��6&   ._�5g      �� $��Next Image Hotkey��6   $��1,1,1,1q�68   5h      �� 5i      $��4��6   $��1��6&   ._�5j        6-   5k      �� 5m      $��5��6   $��0��6&   ._�5n      �� $��Show/Hide Overlay Hotkey��6   $��1,1,1,1q�6?   5o      �� 5p      $��5��6   $��1��6&   ._�5q        6-   5r      �� 5t      $��6��6   $��0��6&   $��2��66   ._�5u      �� $-��'Overlay Image File Paths (One Per Line)��6   $��1,1,1,1q�6N   5v      �� 5w      $��7��6   $��0��6&   $��2��66   ._�5x      �� 
 �� TextWrapping$
 NoWrap=�6    �� AcceptsReturn$
 True��64   $	��200��6I   $	��Top=�6V   5y      5z      5{      5|      5}      