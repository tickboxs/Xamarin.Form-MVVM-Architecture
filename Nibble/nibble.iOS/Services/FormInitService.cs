using System;
using nibble.Interfaces;
using Xamarin.Forms;
using nibble.iOS.Services;
using CoreFoundation;
using UIKit;

[assembly: Dependency(typeof(FormInitService))]
namespace nibble.iOS.Services
{
    public class FormInitService: IFormInitService
    {
        public void Init()
        {
            global::Xamarin.Forms.Forms.Init();
        }

    }
}
