using System;
using nibble.Interfaces;
using Xamarin.Forms;
using nibble.iOS.Services;
using CoreFoundation;
using UIKit;

[assembly: Dependency(typeof(ToastService))]
namespace nibble.iOS.Services
{
    public class ToastService:IToastService
    {
        UIAlertController _alert;

        public void Toast(string message, ulong ms)
        {
            _alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(_alert, true, null);

            const int ms2ns = 1000000;
            DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, (long)ms * ms2ns), () => {
                if (_alert != null)
                {
                    _alert.DismissViewController(true, null);
                }
            });
        }
    }
}
