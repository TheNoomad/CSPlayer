   M S B A M L   `   `   `  ���� C  ?CSplayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CSplayerCSplayer      CSplayer.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:CSplayer       � Title$  CSPlayer��$	��565��$	��728��$	��800��$	��600�� � 	Resources    ButtonImage �� ImageSource �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value��%  &	        '��      7   �� $ /playlist.png���� " ��.���  � ��8   ��  � �� �� " ��.R��� #��z��#��z��#��z��._��� #��z��#��z��#��z��# z $
��True�� P� 	 �@J�IsMouseOver$

 True��. ���  � ��
 ��  ���  �@�Cursor$
 Hand��.��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black��� $ Black�� � Offset$ 1Q�.+�]� -    ]�Name$ 	mainBlock��$��8��.+�� -    �Name$ 
bottomMenu��$��Bottom=�$��70������ $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#FF4F4F4F��$ 1Q� � ColumnDefinitions �� $	��14* ��� $��0* ��� $
��208* ��� $
��386* ��� $
��193* �.+��� -    ��Name$ 
stopButton��$��0q�$��84,16,87,16q�$��35��$��35��$�� ��$��2������ $ /Material/stop-button.png�� j� TileMode$
 Tile=��� -   $ 
playButton��$��0q�$��12,19,166,18q�$��35��$��35��$�� ��$��2������ $ /Material/play.png��$
 Tile=��� -   $ pauseButton��$��0q�$��47,21,131,21q�$��35��$��35��$�� ��$��2������ $; 5/Material/pause-multimedia-big-gross-symbol-lines.png��$
 Tile=��� -    ��Name$ volumeLabel��$��Volume��$��3��$
��Left=�$��
237,10,0,0q�$	��Top=�$��56�� K� ZIndex$ 2��
�������$��80��$��25�� J� RenderTransformOrigin$ 
1.356,0.56&�$��25���� -   $ addVideoButton��$��0q�$�� ��$
��Left=�$	��Top=�$��41��$��50��$	��500��$��40��$��3��$��	45,18,0,0q����� $ /playlist.png���� -    ��Name$ volumeSlide��$��3��$
��Left=�$��
183,34,0,0q�$	��Top=�$	��180�� � Value$ 5Q� �� TickFrequency$	 0.1Q� � Maximum$ 1Q� � LargeChange$	 0.1Q�$��18����!�  !� Visual � .+��� $��1��$��1������ $	 0,0&�$	 1,0&�.��� $	 Red��$ 0Q�� $ Yellow��$	 0.5Q�� $ Green��$ 1Q��� $��1��$��1������ $	 0,0&�$ 0.1,0&� � SpreadMethod$ Repeat=�.��� $ Transparent��$	 0.5Q�� $ White��$	 0.5Q�� $ White��$
 0.55Q�� $ Transparent��$
 0.55Q��� $��1��$��1������ $	 0,1&�$	 0,0&�$ Repeat=�.��� $ 	#11FFFFFF��$ 0Q�� $ 	#22FFFFFF��$	 0.5Q�� $ 	#11000000��$	 0.5Q�� $ 	#11000000��$ 1Q��� -	    ��Name$ videoBar��$��
9,-10,9,63q� �� Orientation$ 
Horizontal=�$
��auto��$��5��$ 50Q����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ White��$ 1Q��� -
   $ 	videoTime��$��No video playing��$��3��
�������$��
385,40,0,0q�$��2���� -   $ previousVideoButton��$��0q�$��120,16,47,15q�$��35��$��35��$�� ��$��2��$ 0.5,0.5&�z�V� .~��� �� ��   �� Angle$  -360.527Q�T� ���� $! /Material/rewind-button.png��$
 Tile=��� -   $ nextVideoButton��$��0q�$��165,19,5,18q�$��35��$��35��$�� ��$��2��$ 0.5,0.5&�z�V� .~��� �� �� $  180.43Q�T� ���� $! /Material/rewind-button.png��$
 Tile=�! j� Stretch$
! Fill=��� -   $ nameOfTheVideoLabel��$��No video playing��$��3��$��	385,8,0,0q�$	��Top=�
�������$��32��$��2��� -   $ 
videoBlock��$
��auto��.+�r� -   " r�Name$" 	mainVideo��# J� OpacityMask
# �   �$��	5,20,5,15q�$ J� 	AllowDrop$
$ True��