using System.Windows;

namespace ProjectManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            try
            {
                MainWindow window = new MainWindow();

                MainWindow = window;

                window.Show();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(
                    ex.ToString(),
                    "Ошибка запуска ProjectManager",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                Shutdown();
            }
        }
    }
}