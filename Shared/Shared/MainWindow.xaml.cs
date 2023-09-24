using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Shared
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "Shared";

            this.InitializeComponent();
            (Application.Current as App).EnsureSettings();
            ApplyTheme();
        }
        


        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = (Application.Current as App).Settings;
            settings.IsLightTheme = !settings.IsLightTheme;
            (Application.Current as App).SaveSettings();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            var settings = (Application.Current as App).Settings;
            Root.RequestedTheme = settings.IsLightTheme ? ElementTheme.Light : ElementTheme.Dark;
        }
        private void Root_ActualThemeChanged(FrameworkElement sender, object args)
        {
            // Theme change refinements (e.g. content dialogs and title bar).
        }
    }
}
