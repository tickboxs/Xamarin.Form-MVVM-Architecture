
using Xunit;
using nibble.ViewModels.Auth;
using nibble.Interfaces;
using Moq;


namespace nibble.UnitTests.ViewModels
{
    public class LoginPageViewModelTests
    {
        public LoginPageViewModelTests()
        {
            DIContainer.Init();
        }

        private LoginPageViewModel vm;

        [Fact]
        public void TestSwitchAsyncInvocatedWhenLoginWithAppleCommandExecuted()
        {
            vm = new LoginPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.LoginWithAppleCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.MainTabbed), Times.Once());
        }

        [Fact]
        public void TestSwitchAsyncInvocatedWhenLoginWithFacebookCommandExecuted()
        {
            vm = new LoginPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.LoginWithFaceBookCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.MainTabbed), Times.Once());
        }

        [Fact]
        public void TestSwitchAsyncInvocatedWhenLoginWithGoogleCommandExecuted()
        {
            vm = new LoginPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.LoginWithGoogleCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.MainTabbed), Times.Once());
        }

        [Fact]
        public void TestSwitchAsyncInvocatedWhenLoginWithNotLoginCommandExecuted()
        {
            vm = new LoginPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.NotLoginCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.MainTabbed), Times.Once());
        }
    }
}