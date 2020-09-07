using Xunit;
using nibble.ViewModels.Transaction;
using nibble.Interfaces;
using nibble.Constants;
using Moq;

namespace nibble.UnitTests.ViewModels
{
    public class TransactionPageViewModelTests
    {
        public TransactionPageViewModelTests()
        {
            DIContainer.Init();
        }

        private TransactionPageViewModel vm;

        [Fact]
        public void TestTransactionAllNullWhenPagePresented()
        {
            vm = new TransactionPageViewModel();

            Assert.Null(vm.Name);
            Assert.Null(vm.Type);
            Assert.True(vm.Amount == 0);
            Assert.True(vm.Timestamp == 0);

        }

        [Fact]
        public void TestSaveButtonDisabledWhenPagePresented()
        {
            vm = new TransactionPageViewModel();
            Assert.False(vm.IsSaveButtonEnabled);
            
        }

        [Fact]
        public void TestSaveButtonBackgroundColorIsGrayWhenPagePresented()
        {
            vm = new TransactionPageViewModel();
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

        }

        [Fact]
        public void TestSaveButtonEnabilityWhenAmountOrTypeOrNameOrTimestampChange()
        {
            vm = new TransactionPageViewModel();

            Assert.False(vm.IsSaveButtonEnabled);

            vm.Name = "name";
            Assert.False(vm.IsSaveButtonEnabled);

            vm.Amount = 100;
            Assert.False(vm.IsSaveButtonEnabled);

            vm.Type = ItemType.Charity;
            Assert.False(vm.IsSaveButtonEnabled);

            vm.Timestamp = 1585117677753;
            Assert.True(vm.IsSaveButtonEnabled);

        }

        [Fact]
        public void TestSaveButtonBackgroundColorWhenAmountOrTypeOrNameOrTimestampChange()
        {
            vm = new TransactionPageViewModel();

            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Name = "name";
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Amount = 100;
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Type = ItemType.Charity;
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Silver);

            vm.Timestamp = 1585117677753;
            Assert.True(vm.SaveButtonBackgroundColor == Theme.Purple);

        }

        [Fact]
        public void TestPushAsyncWhenTapAmountCommandExecuted()
        {
            vm = new TransactionPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            vm.TapAmountCommand.Execute(null);
            pageServiceMock.Verify(pageService => pageService.SwitchAsync(Scene.MainTabbed), Times.Once());
        }


    }
}