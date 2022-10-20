using BatteryNotification.Views;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace BatteryNotification
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private TaskbarIcon? _notifyIcon;

        #endregion

        #region Override methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");

            Application.Current.MainWindow = new MainView()
            {
                Visibility = Visibility.Hidden
            };
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.Dispose();
            }

            base.OnExit(e);
        }

        #endregion

        #region Event handlers

        private void menConfig_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            //Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void menClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
