   M S B A M L   `   `   `  ����A  =Kliens, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KliensKliens  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   
HeaderText  BaseTextBlockStyle �� BasedOn �� Property  ForegoundMainBrush �� Value  	BaseStyle  FontSizeMedium  LatoBold  LoginBorderBrush �� 
TargetType ��Name J� SnapsToDevicePixels ��Name ��Name	 J� IsHitTestVisible

 � Tag  	LatoLight �� Padding  ForegroundVeryDarkBrush �� Triggers �� Binding �� RelativeSource �� Value �� Triggers P� Property P� Value �� 
TargetName 	 MouseOverBrush�    �Kliens.BaseAttachedProperty`2[[Kliens.MonitorPasswordProperty, Kliens, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] �� 	Converter)   #Kliens.BooleanToVisibilityConverter 
 SpinningText  FontAwesome �� 	Resources  Key �� TargetProperty W� From	 W� To g� Duration g� RepeatBehavior �� Self �� Path N� EnterActions ��Name  Spin N� ExitActions  �� BeginStoryboardName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:Kliens  5      %
  &	        7  7  '�� �     7  7  7  7  7  7  7 	 7 	 'G� �    7  7  7  7  7  7  7 	 7 	 &	
 �	    7  7  7  �� 5      "  ��6   8   .�5   
   ��  � ��8  6'   �� 5   
    � ��$ Center=�6.   �� 5   
    � ��$ Center=�60   �� 5	   
    � ��$	 0 2q�6#   5
      �� 5      "  ��6   8   .�5   
   ��  � ��8  6%   �� 5   
    � ��8  6'   �� 5   
    � ��$ 10q�6$   �� 5   
    � ��$ 0 5 0 5q�6#   �� 5   
    � ��8  6(   �� 5   
    � ��$ 	0 0 0 0.5q�6,   �� 5   
    � �� 5      �� 5      " ��6#   .R�5      � .+�5      �� $ border��6!   #��z��5   !   #��z��5   !   #��z��5   !    . ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5      �� 5      $ placeholder��5!   $   	 .  #��z
 5    $   8�� # z��5#   $   $��Center=�5$   $   #��z��5%   $   8�� ��5(      �� 5)   "   "  ��6(   .�5*   &   ��  � y�$ 	Collapsed=�6C    5+   &   �� 5,   *    66   �� *Text+ �� *TemplatedParent+  6�   .a�5-   .   ��  � y�$ Visible=�6K   5.   +   50   #   53      54       56      P� 57       � {� .  . �58      �� $ border��68    �@J�Opacity$
 0.56Q�6L   59      P� 5:       �@J�IsMouseOver . . �5;      �� $ border��6<   8   � ��6P   5<      P� 5=       �@J�IsKeyboardFocused . . �5>      �� $ border��6<   8   � ��6P   5?      5A      5C      5E      �� 5G      "  G�6   8   .�5H   
   ��  � ��8  6%   �� 5I   
    � ��8  6'   �� 5J   
    � ��$ 10q�6$   �� 5K   
    � ��$ 0 5 0 5q�6#   �� 5L   
    � ��8  6(   �� 5M   
    � ��$ 	0 0 0 0.5q�6,   �� 5O   
    �@  Value . 6@   �� 5Q   
    � �� 5R      �� 5S      " G�6#   .R�5T      � .+�5U      �� $ border��6!   #��z��5V   !   #��z��5W   !   #��z��5X   !    . ._�5Z      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5[      �� 5\      $ placeholder��5^   $   	 .  #��z
 5]   $   8�� # z��5`   $   $��Center=�5b   $   #��z��5c   $   8�� y�5a   $   �� *local:HasTextProperty.Value+   5h      5i       5k      P� 5l       � {� .  . �5m      �� $ border��68    �@J�Opacity$
 0.56Q�6L   5n      P� 5o       �@J�IsMouseOver . . �5p      �� $ border��6<   8   � ��6P   5q      P� 5r       �@J�IsKeyboardFocused . . �5s      �� $ border��6<   8   � ��6P   5t      5v      5x      5z      �� 5|      "  ��6   8   .�5}   
   ��  � ��8  6'   �� 5~   
    � ��$	 ��6!   �� 5   
    �@J�RenderTransformOrigin$ 0.5, 0.5&�62   �� 5�   
    � z� 5�      �� 5�      6$   5�       5�   
   ���� 5�      Spin .��5�      W� $9 3(UIElement.RenderTransform).(RotateTransform.Angle)�5�      $ 0X�5�      $	 360X�5�      $ 0:0:2D�5�      $ Forever��5�      5�      5�       5�   
   �� 5�       6   �� # Z $ 	IsVisible� True6l    5�      �� 5�      $ SpinStoryboard��6&   8�� 6<    5�      �� 5�      $  SpinStoryboard��6'   5�      5�      5�      