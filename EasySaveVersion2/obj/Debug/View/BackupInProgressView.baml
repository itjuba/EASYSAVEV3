   M S B A M L   `   `   `  ����K  GEasySaveVersion2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EasySaveVersion2.ViewEasySaveVersion2.View  5      0    *EasySaveVersion2.View.BackupInProgressView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:EasySaveVersion2.View     5      .��5	      � 
�������  � ColumnDefinitions  5   
   �� 5      $
��323* �6   �� 5      $	��77* �6    � RowDefinitions 5   
   �� 5      .+�5   
   � $��0��5      .+�5      � -   5         �Name$ Progress��5      $
��Left=�5      $��19��5      $��	33,10,0,0q�5      $	��Top=�5      $	��584��5      6   �� 5!      -   5         ��Name$ ListJob��5!       �� DisplayMemberPath$
 name��6,   $
��Left=�5"      $	��268��60   $��	23,70,0,0q�6=   $	��Top=�6P   $	��594��6h   $��Center=�6t   $��Disabled=�6�   ��6�   Z� ��6�   Z�  �� View 5$      �� 5%      .P�5&      �� -   5        
HHname����5&   =   ��  �� Path$ HName� �� DisplayMemberBinding 6[   �� $
 Name��� 5'      -   5        HHsource����5'   ?   �� $ HSource� 6_   �� $ Source��� 5(      -   5        HHtarget����5(   ?   �� $ HTarget� 6_   �� $ Target�5)      5+      5,      � 5.   
   $��1��5/      .+�52      �� -   5         ��Name$ Pause��53      $��pause��54      $
��Left=�55      $��
10,116,0,0q�56      $	��Top=�57      $��37��58      $��28��6   �� 5;      -   5        $
 Play��5<      $
��play��5=      $
��Left=�5>      $��
52,116,0,0q�5?      $	��Top=�5@      $��37��5A      $��28��6    5B      �� 5D      -   5        $
 Stop��5E      $
��stop��5F      $
��Left=�5G      $��
94,116,0,0q�5H      $	��Top=�5I      $��41��5J      $��28��5K      5M      5O      5P      