   M S B A M L   `   `   `  ����K  GEasySaveVersion2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EasySaveVersion2.ViewEasySaveVersion2.View  5      2    ,EasySaveVersion2.View.ExecuteSpecificJobView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:EasySaveVersion2.View     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $
��264* �6   �� 5      $	��91* �6   �� 5      $
��106* �6   �� 5      $	��84* �6   �� 5      $
��255* �6    � RowDefinitions 5   
   �� 5      $	��21* �6   �� 5      $
��176* �6   �� 5      $	��28* �6   .+�5    
   � $��1��5!      $��0��5"      $��3��5#      $��52,0,0,0q�5$      .+�5&      �� -   5         ��Name$ Title��5'      $��Center=�5)      $��Center=�5*      $��24(�5+      $
��Bold"�5,      $��-33,10,-31,0q�5-      $	��293��5.      ��5(      ��  �� Path$ TbTitle�5.      51      � 56   
   -   5         �Name$ Selector��56      $��0��57      $��1��58      $��5��59      .+�5=      �� -   5         ��Name$ ListJob��5=       �� DisplayMemberPath$
 name��6(   $
��Left=�5>      $	��268��6,   $��
108,34,0,0q�69   $	��Top=�6M   $	��594��6e   $��Center=�6q   $��Disabled=�6�   ��6�   Z� ��6�   Z�  �� View 5@      �� 5A      .P�5B      �� -   5        
HHname����5B   9   �� $ HName� �� DisplayMemberBinding 6W   �� $
 Name��� 5C      -   5        HHsource����5C   ;   �� $ HSource� 6[   �� $ Source��� 5D      -   5        HHtarget����5D   ;   �� $ HTarget� 6[   �� $ Target��� 5E      -   5        
HHtype����5E   9   �� $ HType� 6W   �� $
 Type��� 5F      -   5        HHfoSof����5F   :   �� $ HfoSof� 6Y   �� $ FoSof�5G      5I      5M      � 5R   
   -	   5        $ 
ExecuteBtn��5R      $��2��5S      $��2��5T      .+�5V      �� -
   5        $��Button��5X      $��Center=�6"   $��Center=�6?   $��91��6Z   $��56��6e   $��	4,4,4,6.7q�6�   ��6q   Z� ��6�   Z� ��5Y      �� 5Z      	 �� ImageSource$6	 0/EasySaveVersion2;component/assets/on-button.png��6!   
 j� Stretch$
 Uniform=�6`   5\      5]      � 5`   
   $��4��6   .+�5b      �� -   5        $��Fr��5b   $   $��	96,0,90,2q�61   ��5c      �� 5d      $7	 1/EasySaveVersion2;component/assets/france (1).png��6!   $
 UniformToFill=�6a   5f      �� 5g      -   5        $��En��5g   $   $��
10,0,178,2q�61   ��5h      �� 5i      $;	 5/EasySaveVersion2;component/assets/united-kingdom.png��6!   $
 UniformToFill=�6e   5k      5l      5o      5s      