using System;
using nibble.Interfaces;
using nibble.Droid.Services;
using Xamarin.Forms;
using Android.Widget;
using Java.Util;

[assembly: Dependency(typeof(ToastService))]
namespace nibble.Droid.Services
{
    public class ToastService : IToastService
    {
        public void Toast(string message, ulong ms)
        {
            var toast = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long);
            toast.SetGravity(Android.Views.GravityFlags.Center, 0, 0);
            ShowMyToast(toast, ms);
        }

        private void ShowMyToast(Android.Widget.Toast toast, ulong cnt)
        {

            Timer timer = new Timer();
            toast.Show();
            timer.Schedule(new ToastTimerTask(toast), (long)cnt);

        }
    }

    // Let Toast Support Time Control
    class ToastTimerTask : TimerTask
    {
        private Android.Widget.Toast _toast;
        public ToastTimerTask(Android.Widget.Toast toast)
        {
            _toast = toast;
        }

        public override void Run()
        {
            _toast.Cancel();
            this.Cancel();
        }
    }
}



