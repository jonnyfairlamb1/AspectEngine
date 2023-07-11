using AspectEditor.GameProject;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace AspectEditor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        Loaded += OnMainWindowLoaded;
        Closing += OnMainWindowClosing;
    }

    public static string AspectPath { get; private set; }

    private void OnMainWindowClosing(object? sender, CancelEventArgs e) {
        Closing -= OnMainWindowClosing;
        Project.Current?.UnLoad();
    }

    private void OnMainWindowLoaded(object sender, RoutedEventArgs e) {
        Loaded -= OnMainWindowLoaded;
        GetEnginePath();
        OpenProjectBrowserDialog();
    }

    private void OpenProjectBrowserDialog() {
        var projectBrowser = new ProjectBrowserDialog();

        if (projectBrowser.ShowDialog() == false || projectBrowser.DataContext == null) Application.Current.Shutdown();
        else {
            Project.Current?.UnLoad();
            DataContext = projectBrowser.DataContext;
        }
    }

    private void GetEnginePath() {
        var aspectPath = Environment.GetEnvironmentVariable("ASPECT_ENGINE", EnvironmentVariableTarget.User);
        if (aspectPath == null || !Directory.Exists(Path.Combine(aspectPath, @"Engine\EngineAPI"))) {
            var dlg = new EnginePathDialog();
            if (dlg.ShowDialog() == true) {
                AspectPath = dlg.AspectPath;
                Environment.SetEnvironmentVariable("ASPECT_ENGINE", AspectPath.ToUpper(), EnvironmentVariableTarget.User);
            } else {
                Application.Current.Shutdown();
            }
        } else {
            AspectPath = aspectPath;
        }
    }
}