﻿using System.Windows;
using System.Windows.Controls;

namespace AspectEditor.GameProject;

/// <summary>
/// Interaction logic for OpenProject.xaml
/// </summary>
public partial class OpenProjectView : UserControl {

    public OpenProjectView() {
        InitializeComponent();

        Loaded += (s, e) => {
            var item = projectsListBox.ItemContainerGenerator.ContainerFromIndex(projectsListBox.SelectedIndex) as ListBoxItem;
            item?.Focus();
        };
    }

    private void OnOpenButton_Click(object sender, System.Windows.RoutedEventArgs e) {
        OpenSelectedProject();
    }

    private void OnListBoxItem_Mouse_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) {
        OpenSelectedProject();
    }

    private void OpenSelectedProject() {
        var project = OpenProject.Open(projectsListBox.SelectedItem as ProjectData);
        bool dialogResult = false;
        var win = Window.GetWindow(this);
        if (project != null) {
            dialogResult = true;
            win.DataContext = project;
        }
        win.DialogResult = dialogResult;
        win.Close();
    }
}