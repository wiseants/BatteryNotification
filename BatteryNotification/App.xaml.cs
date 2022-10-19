using BatteryNotification.Views;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows;

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
            ConfigView configView = new ConfigView();
            configView.Show();
        }

        private void menClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
