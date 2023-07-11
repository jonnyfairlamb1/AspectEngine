using System.IO;
using System.Windows;

namespace AspectEditor {

    /// <summary>
    /// Interaction logic for EnginePathDialog.xaml
    /// </summary>
    public partial class EnginePathDialog : Window {
        public string AspectPath { get; private set; }

        public EnginePathDialog() {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }

        private void OnOkay_Button_Click(object sender, RoutedEventArgs e) {
            var path = pathTextBox.Text;
            messageTextBlock.Text = string.Empty;
            if (string.IsNullOrEmpty(path)) messageTextBlock.Text = "Invalid path.";
            else if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1) messageTextBlock.Text = "Invalid character(s) used in path";
            else if (!Directory.Exists(Path.Combine(path, @"Engine\EngineAPI"))) messageTextBlock.Text = "Unable to find the engine at the specified location";

            if (string.IsNullOrEmpty(messageTextBlock.Text)) {
                if (!Path.EndsInDirectorySeparator(path)) path += @"\";
                AspectPath = path;
                DialogResult = true;
                Close();
            }
        }
    }
}