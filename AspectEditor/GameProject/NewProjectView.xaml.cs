using System.Windows;
using System.Windows.Controls;

namespace AspectEditor.GameProject {

    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProjectView : UserControl {

        public NewProjectView() {
            InitializeComponent();
        }

        private void OnCreateButton_Click(object sender, System.Windows.RoutedEventArgs e) {
            var vm = DataContext as NewProject;
            var projectPath = vm.CreateProject(templateListBox.SelectedItem as ProjectTemplate);
            bool dialogResult = false;
            var win = Window.GetWindow(this);
            if (!string.IsNullOrEmpty(projectPath)) {
                dialogResult = true;
                var project = OpenProject.Open(new ProjectData() { ProjectName = vm.ProjectName, ProjectPath = projectPath });
                win.DataContext = project;
            }
            win.DialogResult = dialogResult;
            win.Close();
        }
    }
}