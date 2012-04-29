using System.Globalization;
using System.Threading;
using System.Windows;

namespace DriveSchool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CultureInfo ci = CultureInfo.CreateSpecificCulture("zh-cn");
            ci.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            Thread.CurrentThread.CurrentCulture = ci;

            DriveSchool.MainWindow window = new MainWindow();
            MainWindowViewModel VM = new MainWindowViewModel(window);
            window.DataContext = VM;
            window.Show();
        }
    }
}
