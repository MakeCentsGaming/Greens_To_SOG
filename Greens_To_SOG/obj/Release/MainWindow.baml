   M S B A M L   `   `   `  ���� H  DGreens_To_SOG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Greens_To_SOGGreens_To_SOG      Greens_To_SOG.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Greens_To_SOG     -     � Title$  Greens To SOG��$��498.5��$	��747�� � Icon$ GreensToSOG.ico��.��� ���	#FFACACAC � RowDefinitions �� $
��148* ��� $
��141* ��� $
��178* � � ColumnDefinitions �� $
��284* ��� $
��147* ��� $
��143* ��� $
��165* �.+�]� ��.  $��1��$��0.104,23.01,10.5,0.5q�$��1��$��3�����	#FFCDBBBB�� -    ��Name$ About��$��10(�$��0,-8.533,3,0q�$	��Top=�$��Right=�$��101.967��$��25.96��$��3������ *About+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ 	fileslist��$��10(�$��0,23.01,10.5,0q�$��3��$��1��$��1�����	#FF363636{��� *ControlsBusy+���� *	DirList+����  �� ImageSource$ dragndrop.png��	 j� Stretch$	 Uniform=��� -   
 ��Name$
 image1��$��10,8.666,5,1.834q�$
��Fill=�$��2������ *ConvertImage+ J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  �� -   $
 image1_Copy��$��2.104,10,8,2.184q�$
��Fill=�$��1������ *OConvertImage+   �� -   $
 image1_Copy1��$��1.033,10,5.967,2.184q�$
��Fill=�$��2������ *GConvertImage+   �� -   $
 image1_Copy2��$��4.137,10,15.208,2.184q�$
��Fill=�$��3������ *SConvertImage+   �� -    ��Name$ 
consolelog��$��2q�
���   �
�������" �� VerticalScrollBarVisibility$
 Auto=�$��4��$��10,23.509,9.467,13q� �� TextWrapping$ NoWrap=�$��2�����	#FF0078D7���� *consoleOutput+$ TwoWay=�$ PropertyChanged=��� $��Console Output��$
��Left=�$��10,0.549,0,0q�$��2��$	��Top=�$��25.96��$��93.657���� $��List of Image Paths��$
��Left=�$��0.25,1.05,0,0q�$	��Top=�$��1��$��1��$��25.96��$��109.71���� $	��Run��$��3��$��
0,0,34.5,7q�$��2��$��Right=�$��75��$��19.96��$��Bottom=�{��� *ControlsBusy+���� *	CmdRunSOG+    � DataContext !   Greens_To_SOG.MainViewModel  