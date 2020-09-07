
using Xunit;
using nibble.ViewModels.Home;
using nibble.Interfaces;
using Moq;


namespace nibble.UnitTests.ViewModels
{
    public class HomePageViewModelTests
    {
        public HomePageViewModelTests()
        {
            DIContainer.Init();
        }

        private HomePageViewModel vm;

        [Fact]
        public void TestAssetViewModelsNotNullWhenLoadAssetsCommandExecuted()
        {
            vm = new HomePageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            Assert.NotNull(vm.FilteredAssetViewModels);
            Assert.True(vm.FilteredAssetViewModels.Count == 0);

            vm.LoadAssetsCommand.Execute(null);

            Assert.True(vm.FilteredAssetViewModels.Count == 5);

        }


        [Fact]
        public void TestPushAsyncInvocatedWhenShowAssetChartCommandExecuted()
        {   
            vm = new HomePageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.ShowAssetChartCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.PushAsync(Scene.Chart), Times.Once());
        }

        [Fact]
        public void TestSearchFunctionWhenSearchBarInput()
        {
            vm = new HomePageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            Assert.NotNull(vm.AssetViewModels);
            
            Assert.True(vm.FilteredAssetViewModels.Count == 0);

            vm.LoadAssetsCommand.Execute(null);
            Assert.True(vm.FilteredAssetViewModels.Count == 5);

            vm.Keyword = "S";
            Assert.True(vm.FilteredAssetViewModels.Count == 3);

            vm.Keyword = "";
            Assert.True(vm.FilteredAssetViewModels.Count == 5);

        }

    }
}