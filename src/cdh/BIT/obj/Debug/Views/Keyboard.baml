   M S B A M L   `   `   `  ����>  :BIT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BITBIT  5          BIT.Views.Keyboard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      !BITclr-namespace:BIT     5      T PMahApps.Metro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /resources/Icons.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   .+�5    
   �� $��0��6   $��0��6%   .+�5!      �  5"      �� 5#      $��* �6'    5%      �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   .+�5)      �� $��Gesture��5*         DescriptionHeaderStyle#���   5+      �� 5,      -   5         ��Name$ Key_listBox1��5,      $��1��60   $��1q�5-      $��1q�5.      $	��400��5/       �� SelectedIndex$ 0��50      51      52      53      �� 54   
   $��1��6   .+�55      �  56      �� 57      $��* �6'    59      �� 5:      $	��550 �6$   .+�5<      �� -   5         ��Name$ 
Key_Button��5<      $��50��6-   $��50��5=      $��Center=�5>        MetroCircleButtonStyle#���  5?      .��5@      �� $��20��6    $��20��5A      ��5B      ��  �� Path$ 
Foreground�	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 �� J� OpacityMask 5C      !� 5D       j� Stretch$
 Fill=�6*     
appbar_add !� Visual# �  5E   &   5G      5H      5J      5K      �� 5L   
   $��2��6   .+�5M      �  5N      �� 5O      $��* �6'    5Q      �� 5R      $
��Auto �6$   �� 5S      $
��Auto �6$   .+�5U      �� $��Function��5V      #���   5W      �� 5X      -   5        $ Key_listBox2��5X      $��1��60   $��1q�5Y      $��1q�5Z      $	��400��5[      $ 0��5\      5]      5_      5a      �� 5b   
   $��3��6   .+�5c      �  5d      �� 5e      $��* �6'    5g      �� 5h      $	��550 �6$   .+�5j      d� $��50��6   $��50��5k      $��Center=�5l         MetroCircleToggleButtonStyle#���  5m      .��5n      �� $��20��6    $��20��5o      ��5p      �� $ 
Foreground�	 �� *FindAncestor+"
 d� 5q      !� 5r      $
 Fill=�6*     appbar_arrow_right# �  5s   &   5u      5v      5w      5x      �� 5y   
   $��4��6   .+�5z      �  5{      �� 5|      $��* �6'    5~      �� 5      $
��Auto �6$   �� 5�      $
��Auto �6$   .+�5�      �� *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $��0, 10, 0, 0q�5�      $ 0��5�       �� 
IsEditable . .@�5�      �� $��Set 1��6#   �� 5�      $��Set 2��6#   �� 5�      $(��"Very long Item 3 for MahApps.Metro��6#   �� 5�      $��Set 4��6#   5�      �� 5�      $��1��6   $��1q�5�      $��1,0,1,1q�5�      $	��400��5�      $ 0��5�      $��Bottom=�6,    �� View 5�      �� 5�      .P�5�      �� $��Gesture��5�   )    �� DisplayMemberBinding 5�   -   �� *Keyboard_list+5�   )   �� 5�      $��
  Function��5�   )    5�   -   �� *
Function+5�   )   5�      5�      �� 5�      -   5        $ Key_listBox3��5�      $��1��60   $��1q�5�      $��
1,25,122,1q�5�      $ 0��5�      �� 5�      -   5        $ Key_listBox4��5�      $��1��60   $��1q�5�      $��
68,25,57,1q�5�      $ 0��5�      5�      5�      5�      5�      