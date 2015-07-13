using System.Windows;

namespace _005_App_xaml
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();

            wnd.Title = "Title from App startup";

            if (e.Args.Length == 1)
                MessageBox.Show("Now opening file: " + e.Args[0]);


            wnd.Show();
        }
    }
}
