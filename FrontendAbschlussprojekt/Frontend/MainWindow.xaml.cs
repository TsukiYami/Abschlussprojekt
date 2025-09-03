using System.Windows;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMaxMin_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                SVGMaxMin.Source = new Uri("file:///.coding/c%23/Abschlussprojekt/FrontendAbschlussprojekt/Frontend/img/ico/window-maximize.svg", UriKind.Absolute);
            }
            else
            {
                WindowState = WindowState.Maximized;
                SVGMaxMin.Source = new Uri("file:///.coding/c%23/Abschlussprojekt/FrontendAbschlussprojekt/Frontend/img/ico/window-restore.svg", UriKind.Absolute);
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}