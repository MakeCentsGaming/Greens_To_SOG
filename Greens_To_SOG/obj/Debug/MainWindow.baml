   M S B A M L   `   `   `  ����H  DGreens_To_SOG, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Greens_To_SOGGreens_To_SOG  5   	       Greens_To_SOG.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Greens_To_SOG     5   	   -   5          � Title$  Greens To SOG��5   	   $��498.5��6   $	��747��6.    � Icon$ GreensToSOG.ico��6Q   .��5	      � ���	#FFACACAC � RowDefinitions 5
   
   �� 5      $
��148* �6   �� 5      $
��141* �6   �� 5      $
��178* �6    � ColumnDefinitions 5   
   �� 5      $
��284* �6   �� 5      $
��147* �6   �� 5      $
��143* �6   �� 5      $
��165* �6   .+�5   
   ]� ��.  $��1��6*   $��0.104,23.01,10.5,0.5q�6:   $��1��6X   $��3��6e   ���	#FFCDBBBB6y   �� 5   
   -   5         ��Name$ About��5      $��10(�6   $��0,-8.533,3,0q�6y   $	��Top=�6�   $��Right=�6�   $��101.967��6�   $��25.96��6�   $��3��6�   ��6-   �� *About+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ 	fileslist��5   c   $��10(�65   $��0,23.01,10.5,0q�6v   $��3��6�   $��1��6�   $��1��6�   ���	#FF363636{�6   �� *ControlsBusy+��6C   �� *	DirList+��5      �� 5       �� ImageSource$ dragndrop.png��6   	 j� Stretch$	 Uniform=�69   5      �� 5   
   -   5        
 ��Name$
 image1��5   J   $��10,8.666,5,1.834q�60   $
��Fill=�6Z   $��2��6i   ��6   �� *ConvertImage+ J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5       5"      �� 5#   
   -   5        $
 image1_Copy��5#   K   $��2.104,10,8,2.184q�61   $
��Fill=�6`   $��1��6o   ��6   �� *OConvertImage+ 5$        5%      5'      �� 5(   
   -   5        $
 image1_Copy1��5(   O   $��1.033,10,5.967,2.184q�61   $
��Fill=�6e   $��2��6t   ��6   �� *GConvertImage+ 5)        5*      5,      �� 5-   
   -   5        $
 image1_Copy2��5-   P   $��4.137,10,15.208,2.184q�61   $
��Fill=�6f   $��3��6u   ��6   �� *SConvertImage+ 5.        5/      51      �� 52   
   -   5         ��Name$ 
consolelog��52   K   $��2q�6   
���   �
�������" �� VerticalScrollBarVisibility$
 Auto=�6_   $��4��6�   $��10,23.509,9.467,13q�6�    �� TextWrapping$ NoWrap=�6  $��2��6  ���	#FF0078D7��6�   �� *consoleOutput+$ TwoWay=�$ PropertyChanged=�6H  �� 53   
   $��Console Output��6   $
��Left=�6)   $��10,0.549,0,0q�6D   $��2��6Z   $	��Top=�6g   $��25.96��6   $��93.657��6�   �� 55   
   $��List of Image Paths��6   $
��Left=�6.   $��0.25,1.05,0,0q�6I   $	��Top=�6`   $��1��6x   $��1��6�   $��25.96��6�   $��109.71��6�   �� 56   
   $	��Run��6R   $��3��6`   $��
0,0,34.5,7q�6p   $��2��6�   $��Right=�6�   $��75��6�   $��19.96��6�   $��Bottom=�6�   {�6   �� *ControlsBusy+��64   �� *	CmdRunSOG+ 57        58      5:      5<       � DataContext 5=      !   Greens_To_SOG.MainViewModel  5>   
   5@      