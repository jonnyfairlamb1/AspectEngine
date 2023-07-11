using AspectEditor.Components;
using AspectEditor.GameProject;
using AspectEditor.Utilities;
using System.Linq;
using System.Windows.Controls;
using static AspectEditor.Components.GameEntity;

namespace AspectEditor.Editors;

/// <summary>
/// Interaction logic for ProjectLayoutView.xaml
/// </summary>
public partial class ProjectLayoutView : UserControl {

    public ProjectLayoutView() {
        InitializeComponent();
    }

    private void OnAddGameEntity_Button_Click(object sender, System.Windows.RoutedEventArgs e) {
        var btn = sender as Button;
        var vm = btn.DataContext as Scene;
        vm.AddEntityCommand.Execute(new GameEntity(vm) { Name = "Empty Game Entity" });
    }

    private void OnGameEntities_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var listBox = sender as ListBox;
        var newSelection = listBox.SelectedItems.Cast<GameEntity>().ToList();
        var previousSelection = newSelection.Except(e.AddedItems.Cast<GameEntity>()).Concat(e.RemovedItems.Cast<GameEntity>().ToList());

        Project.UndoRedo.Add(new UndoRedoAction(
            () => { //undo action
                listBox.UnselectAll();
                foreach (var item in previousSelection) {
                    (listBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem).IsSelected = true;
                }
            },
            () => {//redo action
                listBox.UnselectAll();
                foreach (var item in newSelection) {
                    (listBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem).IsSelected = true;
                }
            },
            "Selection Changed"
            ));

        MSGameEntity msEntity = null;
        if (newSelection.Any()) msEntity = new(newSelection);

        GameEntityView.Instance.DataContext = msEntity;
    }
}