   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5          Snake.MainWindow   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      %localclr-namespace:Snake     5      -   5          � Title$  Snake��5	      $
��1000��6   $
��1000��6!   $	��500��5
         BackgroundColor#��[  5        	TextColor#��[ 5        MainFont#��[ 5       � WindowStartupLocation$ CenterScreen=�5       � Icon$ Assets/icon.ico��5      .��5      (� .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $��* �6    6-   .+�5      �� -   5         ��Name$ 	ScoreText��5      $��Center=�5      $��Center=�5      $��SCORE 0��5      $��22(�5      $��10q�5      �� 5      -   5         ��Name$ 
GridBorder��5      $��1��5         GridLineColor#��[ 5!      $	��1.5q�5"      $��Center=�5#      $��Center=�5$       �� EdgeMode$ Aliased=�5%      $��20, 0, 20, 20q�5&      ._�5(      A� -   5         A�Name$ GameGrid��5)      $	��800��5*      $	��800��5+        GridBackgroundColor#��[ 5,       J� SnapsToDevicePixels$
 True��5-      	 �� BitmapScalingMode$	 HighQuality=�5.      5/      50      �� 51      -   5        $ Overlay��52      $��1��53        OverlayColor#��[ 54      $ Aliased=�58      ��55      �� 
 �� Path$
 ActualWidth� �� ElementName$ 
GridBorder����56      �� $
 ActualHeight�$ 
GridBorder����57      �� $
 Margin�$ 
GridBorder��._�59      �� -   5        $ OverlayText��5:      $��Press ENTER to start��5;      $��34(�5<      $��Center=�5=      $��Center=�5>      $
��Wrap=�5?      5@      5A      5B      5C      5D      