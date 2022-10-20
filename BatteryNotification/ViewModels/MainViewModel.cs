using BatteryNotification.Interfaces;
using BatteryNotification.Models;
using Microsoft.Toolkit.Uwp.Notifications;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Application;

namespace BatteryNotification.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Fields

        private ConfigInfo? _config = null;
        private bool _isUseNotice;
        private int _minPercent;

        #endregion

        #region Constructors

        public MainViewModel()
        {
            CloseCommand = new DelegateCommand(OnClose);

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

        private void OnClose()
        {
            if (_config != null)
            {
                _config.IsUseNotice = IsUseNotice;
                _config.MinPercent = MinPercent;
                _config.Save();
            }

            Application.Current.MainWindow.Hide();

            new ToastContentBuilder()
                .AddHeader("hcan", "ACCESS WE", "arg")
                .AddText("배터리 충전이 필요합니다.")
                .AddAppLogoOverride(new Uri(Path.GetFullPath(@"Icons\battery_48x48.png")), ToastGenericAppLogoCrop.Circle)
                .Show();
        }

        #endregion
    }
}
