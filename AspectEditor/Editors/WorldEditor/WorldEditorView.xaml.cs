using AspectEditor.Content;
using AspectEditor.GameDev;
using System.Windows;
using System.Windows.Controls;

namespace AspectEditor.Editors;

/// <summary>
/// Interaction logic for WorldEditorView.xaml
/// </summary>
public partial class WorldEditorView : UserControl {

    public WorldEditorView() {
        InitializeComponent();
        Loaded += OnWorldEditorLoaded;
    }

    private void OnWorldEditorLoaded(object sender, RoutedEventArgs e) {
        Loaded -= OnWorldEditorLoaded;
        Focus();
    }

    private void OnNewScript_Button_Click(object sender, RoutedEventArgs e) {
        new NewScriptDialog().ShowDialog();
    }

    private void OnCreatePrimitiveMesh_Button_Click(object sender, RoutedEventArgs e) {
        var dlg = new PrimitiveMeshDialog();
        dlg.ShowDialog();
    }
}