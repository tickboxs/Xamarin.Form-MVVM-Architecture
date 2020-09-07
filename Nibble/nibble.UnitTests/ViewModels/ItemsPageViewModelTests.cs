using Xunit;
using nibble.ViewModels.Home;
using nibble.Interfaces;
using Moq;

namespace nibble.UnitTests.ViewModels
{
    public class ItemsPageViewModelTests
    {
        public ItemsPageViewModelTests()
        {
            DIContainer.Init();
        }

        private ItemsPageViewModel vm;

        [Fact]
        public void TestItemViewModelsNotNullWhenLoadItemsCommandExecuted()
        {
            vm = new ItemsPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            Assert.NotNull(vm.FilteredItemViewModels);
            Assert.True(vm.FilteredItemViewModels.Count == 0);

            vm.LoadItemsCommand.Execute(null);

            Assert.True(vm.FilteredItemViewModels.Count == 5);

        }

        [Fact]
        public void TestSearchFunctionWhenSearchBarInput()
        {
            vm = new ItemsPageViewModel();
            var pageServiceMock = new Mock<IPageService>();
            vm.pageService = pageServiceMock.Object;

            Assert.NotNull(vm.FilteredItemViewModels);
            Assert.True(vm.FilteredItemViewModels.Count == 0);

            vm.LoadItemsCommand.Execute(null);
            Assert.True(vm.FilteredItemViewModels.Count == 5);

            vm.Keyword = "D";
            Assert.True(vm.FilteredItemViewModels.Count == 1);

            vm.Keyword = "Coff";
            Assert.True(vm.FilteredItemViewModels.Count == 1);

            vm.Keyword = "o";
            Assert.True(vm.FilteredItemViewModels.Count == 4);

        }

    }
}