using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectManager
{
    public partial class SettingsPage : Page
    {
        private bool darkTheme;

        public SettingsPage()
        {
            InitializeComponent();
            darkTheme = false;
        }

        private void ThemeToggle_Checked(
            object sender,
            RoutedEventArgs e)
        {
            darkTheme = true;

            MainWindow window =
                Window.GetWindow(this) as MainWindow;

            if (window != null)
            {
                window.SetDarkTheme();
            }
        }

        private void ThemeToggle_Unchecked(
            object sender,
            RoutedEventArgs e)
        {
            darkTheme = false;

            MainWindow window =
                Window.GetWindow(this) as MainWindow;

            if (window != null)
            {
                window.SetLightTheme();
            }
        }

        private void NotificationsToggle_Checked(
            object sender,
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Уведомления включены.",
                "Настройки",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void NotificationsToggle_Unchecked(
            object sender,
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Уведомления отключены.",
                "Настройки",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void AutoSaveToggle_Checked(
            object sender,
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Автосохранение включено.",
                "Настройки",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void AutoSaveToggle_Unchecked(
            object sender,
            RoutedEventArgs e)
        {
            MessageBox.Show(
                "Автосохранение отключено.",
                "Настройки",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}