using System;
using Xunit;
using nibble.ViewModels.Home;
using nibble.Interfaces;
using nibble.Constants;
using Moq;

namespace nibble.UnitTests.ViewModels
{
    public class AssetCreatePageViewModelTests
    {
        public AssetCreatePageViewModelTests()
        {
            DIContainer.Init();
        }

        private AssetCreatePageViewModel vm;

        [Fact]
        public void TestAssetAllNullWhenPagePresented()
        {
            vm = new AssetCreatePageViewModel();

            Assert.Null(vm.Name);
            Assert.Null(vm.Type);
            Assert.True(vm.Balance == 0);

        }

        [Fact]
        public void TestSaveButtonDisabledWhenPagePresented()
        {
            vm = new AssetCreatePageViewModel();
            Assert.False(vm.IsSaveButtonEnabled);

        }

        [Fact]
        public void TestSaveButtonBackgroundColorIsGrayWhenPagePresented()
        {
            vm = new AssetCreatePageViewModel();
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

        }

        [Fact]
        public void TestSaveButtonEnabilityWhenAmountOrTypeOrNameOrTimestampChange()
        {
            vm = new AssetCreatePageViewModel();

            Assert.False(vm.IsSaveButtonEnabled);

            vm.Name = "name";
            Assert.False(vm.IsSaveButtonEnabled);

            vm.Balance = 100;
            Assert.False(vm.IsSaveButtonEnabled);

            vm.Type = AssetType.Bitcoin;
            Assert.True(vm.IsSaveButtonEnabled);

        }

        [Fact]
        public void TestSaveButtonBackgroundColorWhenAmountOrTypeOrNameOrTimestampChange()
        {
            vm = new AssetCreatePageViewModel();

            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Name = "name";
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Balance = 100;
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Type = AssetType.Bitcoin;
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

        }

        [Fact]
        public void TestPushAsyncWhenInputBalanceCommandExecuted()
        {
            vm = new AssetCreatePageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.InputBalanceCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.AssetBalance,new AssetBalancePageViewModel(It.IsAny<long>())), Times.Once());
        }
    }

}
