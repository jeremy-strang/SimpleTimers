   M S B A M L   `   `   `  ����G  CSimpleTimers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SimpleTimers.ControlsSimpleTimers.Controls  5      )    #SimpleTimers.Controls.TimerSettings   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:SimpleTimers.Controls     5      .��5	      � $	��350��6     � 	Resources  5
   
    �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��Padding$ 0,0,1,1q�6,   5      5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��23 �6   �� 5      $��23 �6   �� 5      $��23 �6   �� 5      $��23 �6   .+�5   
   �� $��0��6   $��0��6   ._�5      �� -   5        $��timerNameLabel��5      $��Timer��6*   $
��Bold"�6:   $��1,1,1,1q�6L   5      �� 5    
   $��0��6   $��1��6   ._�5!      �� -   5        $��enableTimer1CheckBox��5!      $��Enabled��63    d� 	IsChecked$
 TrueY�6E   $
��Left=�5"      $��Center=�62   5#      �� 5%   
   $��1��6   $��0��6   ._�5&      �� $��Label��6   $��1,1,1,1q�6$   5'      �� 5)   
   $��1��6   $��1��6   $��2��6.   ._�5*      �� -   5        $��timer1LabelTextBox��5*      $�� ��60   5+      �� 5-   
   $��2��6   $��0��6   ._�5.      �� $��Duration��6   $��1,1,1,1q�6'   5/      �� 50   
   $��2��6   $��1��6   ._�51      �� -   5        $��timer1DurationTextBox��51      .��53   F     54      )  #System.Windows.Input.CommandBinding   timer1Paste   Command��%D   &	          56      -   5        $ Paste��56   9   58      59      .��6%   5:      5;      �� 5<   
   $��2��6   $��3��6   ._�5=      �� $��seconds��6   $��1,1,1,1q�6&   5>      �� 5@   
   $��3��6   $��0��6   ._�5A      �� $��Hotkey��6   $��1,1,1,1q�6%   5B      �� 5C   
   $��3��6   $��1��6   $��2��6.   ._�5D      '   !SimpleTimers.Controls.HotkeyInput  6"   5E      5F      5G      