   M S B A M L   `   `   `  ����G  CAspectEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AspectEditor.GameDevAspectEditor.GameDev  5   	   *    $AspectEditor.GameDev.NewScriptDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:AspectEditor.GameDev     5   	      AspectDialogStyle#��[  5        � 
ResizeMode$  NoResize=�5   	    � ShowInTaskbar$ False��6    � WindowStartupLocation$ CenterOwner=�65    � Title$ 
New Script��5	   	   $	��250��6   $	��400��6)   .��5
      ��  �� CornerRadius$ 3��6     Editor.Window.GrayBrush3#���  6   $��Stretch=�6V   $��10q�6t    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.6Q�6      
BlurRadius$ 15Q�6-      ShadowDepth$ 2Q�6=   ._�5   
   � $
��32,0q�6   .+�5      � -   5        	 �Name$	 busyAnimation��5   ]   $
��Left=�6   $��Center=�6.   $y�Hidden=�6I   
 � 	Resources
 5        Editor.FontColor �� Color  	busyBrush��%)   &	       �� 5      # �  6&   6Q   5      .+�5      A� $	��164��6   $	��164��6&   #��[ 63   $��Center=�6W   $��Center=�6t   $��
-155,0,0,0q�5      $��1��6*    J� RenderTransformOrigin$ 0.5,0.5&�6>   A� 5      $	��154��6   $	��154��6&   #��[ 63   $��Center=�6W   $��Center=�6t   $��
-155,0,0,0q�5      $��10��6*    �� StrokeDashArray$ 	0.3, 0.22R�6?   $ 0.5,0.5&�6[   z�5      �� 5       � Triggers 5      :� 5       :� RoutedEvent$ Loaded��6'   .[�5      �� .��5   "   �� .��5    &   W�  �� TargetProperty$7 1(Ellipse.RenderTransform).(RotateTransform.Angle)�66   	 W� To -3605!   6    g� Duration$ 0:0:2D�6@    g� RepeatBehavior$ Forever��6Q   5"   #   5#      5$      5&      A� 5'      $	��174��6   $	��174��6&   #��[ 63   $��Center=�6W   $��Center=�6t   $��
-155,0,0,0q�5(      $��5��6*   $ 
0.5, 1.186R�6>   $ 0.5,0.5&�6[   z�5)      �� 5*       5,      :� 5-      $ Loaded��6'   .[�5.      �� .��5/   "   �� .��50   &   W� $7 1(Ellipse.RenderTransform).(RotateTransform.Angle)�66    W� From 36051   6    06A   $ 0:0:10D�6H   $ Forever��6Z   52   #   53      54      56      � 57      #��[ 6    � Points 59      8�  8� X$	 160Q�6     8� Y$ 35Q�6(   8� 5:      $	 180Q�6    $ 20Q�6(   8� 5;      $	 340Q�6    $ 20Q�6(   5=      �� 5>      $��Creating new script...��6   
�������$	��Top=�6M   $��Right=�5?      $��0,20,0,0q�68    5@      :� 5A      $ Loaded��6'   .[�5B      �� .��5C   "   �� .��5D   &   W� $ Opacity�66    16Z    06c   $ 0:0:1D�6j   $ Forever��5E   6    g� AutoReverse$
 True��6O   5F   #   5G      5H      5J      5K      � 5M      ��5N      �� 5O       �� 
TargetType" �6    �� Triggers 5P      P� 5Q       P� Property � {� P� Value$ False��6;   . �5R   "   ��  �� Property �@J�Opacity �� Value$	 0.5Q�6<   5S      5U      .+�5W      �� -   5         ��Name$ messageTextBlock��5X   B   $	��Top=�5W      $��Center=�64     Editor.RedBrush#���  6Q   $��0,10,0,0q�5X      $
��Wrap=�6.   6B   �� 5Y      $��Center=�6   .+�5Z      ]� .+�5[      �� $��Script Name��6$   $��72��67     LightTextBlockStyle#��[ 6B   �� 5\      -   5          ��Name$  
scriptName��5\   "   66   5]      ]� 5^      $��0.,5,0,0q�6    .+�5_      �� $
��Path��6$   $��72��60   #��[ 6;   �� 5`      -   5        $  
scriptPath��5`   "   66   5a      5b      �� 5c      ! �� Orientation$! 
Horizontal=�6   $��Bottom=�66   $��Right=�6Q   $��0,0,0,20q�6m   .+�5d      �� -   5        $��Create��5d      $��64��6.   $
��32,0q�69   " �� 	IsDefault$
" True��6G   6X   �� 5e      $��Cancel��6   $��64��6.   # �� IsCancel$
# True��69   5f      5g      5h      5i      5j      