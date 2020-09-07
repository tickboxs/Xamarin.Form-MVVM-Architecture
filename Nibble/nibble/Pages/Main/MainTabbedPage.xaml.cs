
using Xamarin.Forms.Xaml;
using nibble.Interfaces;

using Autofac;
using System.Diagnostics;
using nibble.ViewModels;
using nibble.ViewModels.Main;
using nibble.Attributes;

namespace nibble.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Router(Path = "main")]
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage
    {
        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();
        public MainTabbedPage(BaseViewModel vm)
        {
            Debug.Assert(vm is MainTabbedPageViewModel);
            BindingContext = vm;
            InitializeComponent();

        }

        void NavigationPage_Pushed(System.Object sender, Xamarin.Forms.NavigationEventArgs e)
        {

        }

        void NavigationPage_Popped(System.Object sender, Xamarin.Forms.NavigationEventArgs e)
        {
            // Only popped callback here,so we can only decrease push stack depth count here
            _pageService.PushDepthDescrease();
        }
    }
}
