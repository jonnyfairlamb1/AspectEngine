using AspectEditor.GameProject;
using AspectEditor.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AspectEditor.GameDev {

    /// <summary>
    /// Interaction logic for NewScriptDialog.xaml
    /// </summary>
    public partial class NewScriptDialog : Window {

        private static readonly string _cppCode =
@"#include ""{0}.h""
namespace {1} {{
REGISTER_SCRIPT({0});
    void {0}::begin_play() {{
    }}
    void {0}::update(float dt) {{
        //do update
    }}
}} // namespace {1}";

        private static readonly string _hCode =
@"#pragma once
namespace {1} {{
    class {0} : public aspect::script::entity_script {{
    public:
        constexpr explicit {0}(aspect::game_entity::entity entity) : aspect::script::entity_script{{entity}} {{}}
        void begin_play() override;
        void update(float dt) override;
    private:
    }};
}} // namespace {1}";

        private static readonly string _namespace = GetNamespaceFromProjectName();

        private static string GetNamespaceFromProjectName() {
            var projectName = Project.Current.ProjectName;
            projectName = projectName.Replace(' ', '_');
            return projectName;
        }

        public NewScriptDialog() {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            scriptPath.Text = @"GameCode\";
        }

        private bool Validate() {
            bool isValid = false;
            var name = scriptName.Text.Trim();
            var path = scriptPath.Text.Trim();
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(name)) errorMsg = "Type in a script name.";
            else if (name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1 || name.Any(x => char.IsWhiteSpace(x))) errorMsg = "Invalid character(s) useed in script name.";
            else if (string.IsNullOrEmpty(path)) errorMsg = "Select a valid script folder.";
            else if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1) errorMsg = "Invalid character(s) useed in script path.";
            else if (!Path.GetFullPath(Path.Combine(Project.Current.ProjectPath, path)).Contains(Path.Combine(Project.Current.ProjectPath, @"GameCode\"))) errorMsg = "Script must be added to (a sub-folder) of GameCode.";
            else if (File.Exists(Path.GetFullPath(Path.Combine(Path.Combine(Project.Current.ProjectPath, path), $"{name}.cpp"))) ||
                File.Exists(Path.GetFullPath(Path.Combine(Path.Combine(Project.Current.ProjectPath, path), $"{name}.h")))) errorMsg = $"Script {name} already exists in this folder.";
            else isValid = true;

            if (!isValid) messageTextBlock.Foreground = FindResource("Editor.RedBrush") as Brush;
            else messageTextBlock.Foreground = FindResource("Editor.FontBrush") as Brush;
            messageTextBlock.Text = errorMsg;
            return isValid;
        }

        private void OnScriptName_Textbox_TextChanged(object sender, TextChangedEventArgs e) {
            if (!Validate()) return;
            var name = scriptName.Text.Trim();
            messageTextBlock.Text = $"{name}.h and {name}.cpp will be added to {Project.Current.ProjectName}";
        }

        private void OnScriptPath_Textbox_TextChanged(object sender, TextChangedEventArgs e) {
            Validate();
        }

        private async void OnCreate_Button_Click(object sender, RoutedEventArgs e) {
            if (!Validate()) return;
            IsEnabled = false;

            busyAnimation.Opacity = 0;
            busyAnimation.Visibility = Visibility.Visible;
            DoubleAnimation fadeIn = new(0, 1, new(TimeSpan.FromMilliseconds(500)));
            busyAnimation.BeginAnimation(OpacityProperty, fadeIn);

            try {
                var name = scriptName.Text;
                var path = Path.GetFullPath(Path.Combine(Project.Current.ProjectPath, scriptPath.Text.Trim()));
                var solution = Project.Current.Solution;
                var projectName = Project.Current.ProjectName;

                await Task.Run(() => CreateScript(name, path, solution, projectName));
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                Logger.Log(MessageType.Error, $"Failed to create script {scriptName.Text}");
            } finally {
                DoubleAnimation fadeOut = new(1, 0, new(TimeSpan.FromMilliseconds(200)));
                fadeOut.Completed += (s, e) => {
                    busyAnimation.Opacity = 0;
                    busyAnimation.Visibility = Visibility.Hidden;
                    Close();
                };
                busyAnimation.BeginAnimation(OpacityProperty, fadeOut);
            }
        }

        private void CreateScript(string name, string path, string solution, string projectName) {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var cpp = Path.GetFullPath(Path.Combine(path, $"{name}.cpp"));
            var h = Path.GetFullPath(Path.Combine(path, $"{name}.h"));

            using (var sw = File.CreateText(cpp)) {
                sw.Write(string.Format(_cppCode, name, _namespace));
            }
            using (var sw = File.CreateText(h)) {
                sw.Write(string.Format(_hCode, name, _namespace));
            }

            string[] files = new string[] { cpp, h };

            for (int i = 0; i < 3; i++) {
                if (!VisualStudio.AddFilesToSolution(solution, projectName, files)) Thread.Sleep(1000);
                else break;
            }
        }
    }
}