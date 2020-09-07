using System;
using nibble.Interfaces;
using nibble.Droid.Services;
using Xamarin.Forms;
using Android.Widget;
using Java.Util;

[assembly: Dependency(typeof(FormInitService))]
namespace nibble.Droid.Services
{
    public class FormInitService : IFormInitService
    {
        public void Init()
        {
            global::Xamarin.Forms.Forms.Init(new InitializationOptions());
        }
    }
}



