﻿using BatteryNotification.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BatteryNotification.ViewModels
{
    public class ConfigViewModel : BindableBase
    {
        #region Fields

        private int _minPercent = 1;

        #endregion

        #region Constructors

        public ConfigViewModel()
        {
            CloseCommand = new DelegateCommand<ICloseable>(OnClose);
        }

        #endregion

        #region Properties

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
            param.Close();
        }

        #endregion
    }
}
