   M S B A M L   `   `   `  ����G  CAspectEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AspectEditorAspectEditor  5   	   #    AspectEditor.EnginePathDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AspectEditor     5   	      AspectDialogStyle#��[  5        � 
ResizeMode$  NoResize=�5   	    � ShowInTaskbar$ False��6    � WindowStartupLocation$ CenterOwner=�65    � Title$% Where is Aspect Engine Located?��5	   	   $	��250��61   $	��400��6>   .��5
      ��  �� CornerRadius$ 3��6     Editor.Window.GrayBrush3#���  6   $��Stretch=�6V   $��10q�6t    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Opacity$	 0.6Q�6      
BlurRadius$ 15Q�6-      ShadowDepth$ 2Q�6=   ._�5   
   � $
��32,0q�6   .+�5      �� -   5        	 ��Name$	 messageTextBlock��5   >   $	��Top=�5      $��Center=�60     Editor.RedBrush#���  6M   $��0,10,0,0q�5      $
��Wrap=�6*   6>   ]� 5      .+�5      �� $��Engine path��6   $��72��6/     LightTextBlockStyle#��[ 6:   �� 5      -   5        
 ��Name$
 pathTextBox��5      5      �� 5       �� Orientation$ 
Horizontal=�6   $��Bottom=�62   $��Right=�6M   $��0,0,0,20q�6i   .+�5      �� -   5        $
��Okay��5      $��64��6(   $
��32,0q�63    �� 	IsDefault$
 True��6A   6R   �� 5      $��Cancel��6   $��64��6*    �� IsCancel$
 True��65   5      5      5      5      