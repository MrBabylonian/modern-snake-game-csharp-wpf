   M S B A M L   `   `   `  ���� @  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake      Snake.MainWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:Snake     -     � Title$  Snake��$
��1000��$
��1000��$	��500��   BackgroundColor#��[    	TextColor#��[   MainFont#��[  � WindowStartupLocation$ CenterScreen=� � Icon$ Assets/icon.ico��.��(� .���  � RowDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ 	ScoreText��$��Center=�$��Center=�$��SCORE 0��$��22(�$��10q��� -    ��Name$ 
GridBorder��$��1��  GridLineColor#��[ $	��1.5q�$��Center=�$��Center=� �� EdgeMode$ Aliased=�$��20, 0, 20, 20q�._�A� -    A�Name$ GameGrid��$	��800��$	��800��  GridBackgroundColor#��[  J� SnapsToDevicePixels$
 True��	 �� BitmapScalingMode$	 HighQuality=��� -   $ Overlay��$��1��  OverlayColor#��[ $ Aliased=����� 
 �� Path$
 ActualWidth� �� ElementName$ 
GridBorder������ $
 ActualHeight�$ 
GridBorder������ $
 Margin�$ 
GridBorder��._��� -   $ OverlayText��$��Press ENTER to start��$��34(�$��Center=�$��Center=�$
��Wrap=�