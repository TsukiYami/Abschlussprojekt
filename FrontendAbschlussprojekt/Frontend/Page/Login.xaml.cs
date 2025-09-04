using System.Windows;

namespace Frontend.Page
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var oMainWindow = (MainWindow)Application.Current.MainWindow;

            var oMP = new MainPage();

            oMainWindow.MainFrame.Navigate(oMP);
        }
    }
}
