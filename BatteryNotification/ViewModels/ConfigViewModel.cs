using BatteryNotification.Interfaces;
using BatteryNotification.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using Application = System.Windows.Application;

namespace BatteryNotification.ViewModels
{
    public class ConfigViewModel : BindableBase
    {
        #region Fields

        private ConfigInfo _config;
        private bool _isUseNotice;
        private int _minPercent;

        #endregion

        #region Constructors

        public ConfigViewModel()
        {
            CloseCommand = new DelegateCommand<ICloseable>(OnClose);

            _config = ConfigInfo.Load();
            if (_config != null)
            {
                IsUseNotice = _config.IsUseNotice;
                MinPercent = _config.MinPercent;
            }
        }

        #endregion

        #region Properties

        public bool IsUseNotice
        {
            get => _isUseNotice;
            set => _ = SetProperty(ref _isUseNotice, value);
        }

        public int MinPercent
        {
            get => _minPercent;
            set => _ = SetProperty(ref _minPercent, value);
        }

        #endregion

        #region Commands

        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Event handlers

        private void OnClose(ICloseable param)
        {
            if (_config != null)
            {
                _config.IsUseNotice = IsUseNotice;
                _config.MinPercent = MinPercent;
                _config.Save();
            }

            param.Close();

            var a = Application.Current.Dispatcher;
            var b = Application.Current.MainWindow;

            Notifier notifier = new Notifier(cfg =>
            {
                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });

            notifier.ShowInformation("테스트");
        }

        #endregion
    }
}
