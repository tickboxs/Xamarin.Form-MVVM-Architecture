using System;
using Xamarin.Forms;
using nibble.ViewModels;
using nibble.Attributes;

namespace nibble.Pages
{
    public class BaseContentPage<T> : ContentPage where T : BaseViewModel
    {
        // Private Life Cycle Flag Indicate Whether ViewDidLoad
        private bool _isAppeared = false;

        public BaseContentPage():base()
        {
        
        }

        public BaseContentPage(BaseViewModel vm)
        {
            BindingContext = vm;
        }

        public T VM => BindingContext as T;

        protected override void OnAppearing()
        {

            if (_isAppeared == false)
            {
                VM.ViewDidLoad();
                _isAppeared = true;
            }

            VM.ViewDidAppear();
        }

        protected override void OnDisappearing()
        {
            VM.ViewDidDisappear();
        }
    }
}

