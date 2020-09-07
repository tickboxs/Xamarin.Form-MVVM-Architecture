using System;
using nibble.Interfaces;
using nibble.Services;
using nibble.Constants;
using Autofac;

namespace nibble.ViewModels.Profile
{
    public class ProfilePageViewModel:BaseViewModel
    {

        private ILocalStorageService _localStorageService = DIContainer.Current.Resolve<ILocalStorageService>();

        public bool IsDarkMode
        {
            get
            {
                var isDarkMode = (bool)_localStorageService.GetStorageByKey(LocalStorageKey.DarkMode);
                return isDarkMode;
            }
            set
            {
                _localStorageService.SetStorageWithKey(LocalStorageKey.DarkMode, value);
            }
        }

        public bool IsIphone
        {
            get
            {
                var isDarkMode = (bool)_localStorageService.GetStorageByKey(LocalStorageKey.Iphone);
                return isDarkMode;
            }
            set
            {
                _localStorageService.SetStorageWithKey(LocalStorageKey.Iphone, value);
            }
        }

        public bool IsSumsang
        {
            get
            {
                var isDarkMode = (bool)_localStorageService.GetStorageByKey(LocalStorageKey.Sumsang);
                return isDarkMode;
            }
            set
            {
                _localStorageService.SetStorageWithKey(LocalStorageKey.Sumsang, value);
            }
        }

        public bool IsNotification
        {
            get
            {
                var isDarkMode = (bool)_localStorageService.GetStorageByKey(LocalStorageKey.Notification);
                return isDarkMode;
            }
            set
            {
                _localStorageService.SetStorageWithKey(LocalStorageKey.Notification, value);
            }
        }

        public bool IsCurrency
        {
            get
            {
                var isDarkMode = (bool)_localStorageService.GetStorageByKey(LocalStorageKey.Currency);
                return isDarkMode;
            }
            set
            {
                _localStorageService.SetStorageWithKey(LocalStorageKey.Currency, value);
            }
        }
    }
}
