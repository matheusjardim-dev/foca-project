using foca_project.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace foca_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mw = new MainWindow();
            mw.Show();

            NewActivityWindow naw = new NewActivityWindow();
            naw.Show();
            naw.Topmost = true;
        }
    }

}
