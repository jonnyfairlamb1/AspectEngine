using System.Windows;

namespace AspectEditor.Utilities.Controls;

public class ScalarBox : NumberBox {

    static ScalarBox() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ScalarBox), new FrameworkPropertyMetadata(typeof(ScalarBox)));
    }
}