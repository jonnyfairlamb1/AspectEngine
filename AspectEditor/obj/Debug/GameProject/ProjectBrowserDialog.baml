   M S B A M L   `   `   `  ����G  CAspectEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AspectEditor.GameProjectAspectEditor.GameProject  5   	   3    -AspectEditor.GameProject.ProjectBrowserDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AspectEditor.GameProject     5   	     � 
ResizeMode$  NoResize=�5       � WindowStartupLocation$ CenterScreen=�60    � Title$ Project Browser��5   	   $	��600��6!   $	��800��6.      AspectDialogStyle#��[  5	   	    � 	Resources 5
       �� 
TargetType �� Property �� Value  Editor.Disabled.FontBrush �� 
TargetType J� Effect3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   Opacity �� Triggers P� Property P� Value  Editor.Window.GrayBrush4 ]� 
Conditions �� Property �� Value  Editor.FontBrush��%|  'd�       �� 5   
   " d�6   .�5      ��  � ��$ 32(�6)   �� 5       � ��$ Bahnschrift condensed)�6+   �� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��# �  6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� #��z��6$   ��6L   Z�  5        5   "   $	 2Q�63   $
 1Q�6B   $	 0.6Q�6R   5       5      P� 5       � {�$ False��6;   . �5   "   �� # �  6?    � ��5      P� 5        �@d�	IsChecked$
 TrueY�6;   . �5!   "   ��  � ��
 �����6?   5"      ]� 5#       5$   "   �� 5%   &    �@J�IsMouseOver$
 True��6G   �� 5&   &    �@d�	IsChecked$ FalseY�6E   ./�5(   "   �� # �  6?    � ��5)      5+      5-      5.      5/      .��50      �  � RowDefinitions 51   
   �� 52      $
��Auto �6   �� 53      .+�55   
   �� $	��1.5��6   $��Bottom=�6!   $
��40,0q�6<   ��56      �� 57      ��59      �  � Color$ Transparent��6'    � Offset$ 0Q�6;   � 5:        Editor.Disabled.FontColor# �  6'   $
 0.33Q�6[   � 5;      # �  6'   $
 0.66Q�6[   � 5<      $ Transparent��6'   $ 1Q�6;   5>      5@      �� 5A   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5B      d� -   5         d�Name$ openProjectButton��5B   2   $��OPEN PROJECT��6   $��
10,20,0,20q�6M    d� 	IsChecked$
 TrueY�5C   8   d� 5D      -   5        $ createProjectButton��5D   4   $��CREATE PROJECT��6   $��
40,20,0,20q�6Q   $ FalseY�5E   8   5F      �� 5G   
   -   5         ��Name$ browserContent��5G   ;   $ 
Horizontal=�6   $��1��6.    5H        5I      $	 0.6Q�6#   $	 15Q�61   $
 2Q�6A   .+�5K      .   (AspectEditor.GameProject.OpenProjectView  -   5          Name$ openProjectView��5K   $   -   'AspectEditor.GameProject.NewProjectView  5L      -   5          Name$ newProjectView��5L   #   5M      5N      5O      