   M S B A M L   `   `   `  ����G  CAspectEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AspectEditor.GameProjectAspectEditor.GameProject  5      -    'AspectEditor.GameProject.NewProjectView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:AspectEditor.GameProject     5      $	��800��5        � DataContext  5
      )  #AspectEditor.GameProject.NewProject  5   
   .��5      ��  �� CornerRadius$ 3��6      Editor.Window.GrayBrush3#���   6   $	��700��6V   $��Center=�5      $
��0,30q�6*   ._�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,20,0,0q�6O   .+�5      �� -   5         ��Name$ templateListBox��5   \   $	��195��6   $	��250��6&    �� SelectedIndex$ 0��5      ��5   3   �� *ProjectTemplates+��5      �� 5      .R�5      �� $ 
Horizontal=�6)   .+�5   "   �� $��0,0,5,0q�6@   $��44��6Q   $��44��6\   ��6(   �� *Icon+6\   �� 5   "   $��18(�6I   $��Bahnschrift condensed)�6W   $��Center=�5   ,   ��5   ,   �� *ProjectType+5   ,   5      5      5      �� 5      $	��400��6   $	��250��6%   $��5,0,0,0q�62   ��5      �� 5        �� ImageSource 6%   ��  �� Path$ SelectedItem.Screenshot� �� ElementName$ templateListBox��5"      5#      �� 5$      $ 
Horizontal=�6   $��Center=�62   $��0,30,0,0q�5%      .+�5&      �� $
��Name��6   $��50��6(     LightTextBlockStyle#��[ 63   �� 5'      $	��550��6   ��6&   �� *ProjectName+ �� UpdateSourceTrigger$ PropertyChanged=�5(      �� 5)      $ 
Horizontal=�6   $��Center=�62   $��0,5,0,0q�5*      .+�5+      �� $
��Path��6   $��50��6(   #��[ 63   �� 5,      $	��500��6   ��6&   �� *ProjectPath+$ PropertyChanged=��� 5-      $��Browse��6   $��45��6*   $��5,0,0,0q�65   5.      �� 5/      $ 
Horizontal=�6   $��Center=�62   $��0,30,0,0q�50      .+�51      �� -   5        $��Create��51      $��96��6*   	 �� 	IsDefault$
	 True��65   {�6F   �� *	IsValid+6d   �� 52      $
��Exit��6   $��96��6(   $��30,0,0,0q�63   
 �� IsCancel$

 True��6E   53      �� 54      $��0,10,0,0q�62   $��Center=�6D     Editor.RedBrush#���  6a   ��6   �� *
ErrorMsg+6a   55      56      57      