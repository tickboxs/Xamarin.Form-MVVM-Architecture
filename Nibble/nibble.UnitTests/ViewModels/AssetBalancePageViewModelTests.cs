using System;
using Xunit;
using nibble.ViewModels.Home;
using nibble.Interfaces;
using nibble.Constants;
using Moq;

namespace nibble.UnitTests.ViewModels
{
    public class AssetBalancePageViewModelTests
    {
        public AssetBalancePageViewModelTests()
        {
            DIContainer.Init();
        }

        private AssetBalancePageViewModel vm;

        [Fact]
        public void TestBalanceNullWhenPagePresented()
        {
            vm = new AssetBalancePageViewModel(0);

            Assert.True(vm.Balance == 0);

        }

        [Fact]
        public void TestBalanceNotNullWhenPagePresentedWithValue()
        {
            vm = new AssetBalancePageViewModel(100);
            Assert.True(vm.Balance == 100);

            vm = new AssetBalancePageViewModel(1000);
            Assert.True(vm.Balance == 1000);

            vm = new AssetBalancePageViewModel(2003);
            Assert.True(vm.Balance == 2003);

            vm = new AssetBalancePageViewModel(999);
            Assert.True(vm.Balance == 999);

        }

        [Fact]
        public void TestDoneButtonBackgroundColorIsGrayWhenPagePresented()
        {
            vm = new AssetBalancePageViewModel(0);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

        }

        [Fact]
        public void TestDoneButtonBackgroundColorIsPurpleWhenPagePresentedWithValue()
        {
            vm = new AssetBalancePageViewModel(100);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

            vm = new AssetBalancePageViewModel(200);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

            vm = new AssetBalancePageViewModel(300);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

            vm = new AssetBalancePageViewModel(999);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

            vm = new AssetBalancePageViewModel(0);
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

        }
    }
}
