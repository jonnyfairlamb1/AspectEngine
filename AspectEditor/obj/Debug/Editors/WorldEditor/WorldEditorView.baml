   M S B A M L   `   `   `  ����G  CAspectEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AspectEditor.EditorsAspectEditor.Editors  5      ?$clr-namespace:AspectEditor.UtilitiesAspectEditor.Utilities  5      Q-clr-namespace:AspectEditor.Utilities.ControlsAspectEditor.Utilities.Controls  5      *    $AspectEditor.Editors.WorldEditorView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:AspectEditor.Editors     5      6utils$clr-namespace:AspectEditor.Utilities     5      >ctrl-clr-namespace:AspectEditor.Utilities.Controls     5      $
|�True��5	        � 	Resources  5      ��%    5       J� InputBindings 5      �� 5   
   
 �� Key$ Z��65    �� 	Modifiers$
 Ctrlf�6=    �� Command 6   �� *UndoCommand+6=   �� 5   
   $ Y��65   $
 Ctrlf�6=    6   �� *RedoCommand+6=   �� 5   
   $ S��65   $
 Ctrlf�6=    6   �� *SaveCommand+6=   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Undo��6   ��6$   �� *UndoCommand+�� 5      $
��Redo��6   $	��5,0q�6D   ��6$   �� *RedoCommand+6D   �� 5      -   5        $��
New Script��5      6*   �� 5      $��Build��6   $��5,0,0,0q�6%   �� 5      -   5         ��Name$ 	runConfig��5      $��Center=�6*   $��72��6E   .@�5       �� $��Debug��6   �� 5!      $��Release��6   5"      5#      � 5$   
   $��1��6    � ColumnDefinitions 5%      �� 5&      �� 5'      .+�5)      � $��0��6    5*      �� 5+      �� 5,      .+�5.      ��  #  Editor.Selected.BackgroundBrush#���   6   ._�5/      �� $��Center=�6!   .+�50      /   )AspectEditor.Utilities.Controls.NumberBox  	   Value$	 0��6)     Editor.FontBrush#���  63   /   )AspectEditor.Utilities.Controls.ScalarBox  51      $	 10��6)   
   
Multiplier$
 10Q�64   /   )AspectEditor.Utilities.Controls.VectorBox  52         X$ 0��6)      Y$ 1��6/      Z$ 2��65      W$ 3��6;      
VectorType$ Vector2=�6A     53      $ 0��6)   $ 1��6/   $ 2��65   $ 3��6;   $ Vector3=�6A     54      $ 0��6)   $ 1��6/   $ 2��65   $ 3��6;   $ Vector4=�6A     56      $ 0��6)   $ 1��6/   $ 2��65   $ 3��6;   $ Vector2=�6A      Orientation$ Vertical=�6V     57      $ 0��6)   $ 1��6/   $ 2��65   $ 3��6;   $ Vector3=�6A   $ Vertical=�6V     58      $ 0��6)   $ 1��6/   $ 2��65   $ 3��6;   $ Vector4=�6A   $ Vertical=�6V   59      5:      �� 5;      $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�5<      
������ 63   �� 5=      $��1��6     Editor.Window.GrayBrush2#���  6*   $��0,5,0,0q�5>      .@�5?      �� $��History��6   .��5@      )   #AspectEditor.Utilities.UndoRedoView   � DataContext 6-   �� *
UndoRedo+5A      �� 5B      $	��Log��6   .��5C      '   !AspectEditor.Utilities.LoggerView  5D      5E      5F      �� 5G      $��1��6   $��5��6+   $
��Left=�65   $��Stretch=�5H      
������ 63   � 5I      $��1��6   $��5,0,0,0q�6#    5J      �� 5K      �� 5L      .+�5N      �� $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�5O      
������ 63   ,   &AspectEditor.Editors.ProjectLayoutView  5P        Editor.Window.GrayBrush3#���  6*   )   #AspectEditor.Editors.GameEntityView  5Q      $��1��6'   #���  64   $��0,5,0,0q�5R   '   5S      5T      5U      5V      