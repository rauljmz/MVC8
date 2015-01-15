using Moq;
using MVC8.Business;
using System.Linq;
using Should;
using Xunit;
using Xunit.Extensions;

namespace Tests
{
    public class NavigationBuilderTest
    {
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly NavigationBuilder _navigationBuilder;

        private readonly TestItem _homeItem;

         private const string HomeItemId = "{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}";


        public NavigationBuilderTest()
        {
            _itemRepository = new Mock<IItemRepository>();

            _navigationBuilder = new NavigationBuilder(_itemRepository.Object);

            _homeItem = new TestItem { Name = "Home", TemplateName = "Sample Item", Url = "/" };

            var child1 = new TestItem { Name = "child1", TemplateName = "Sample Item", Url = "/child1" };
            var child2 = new TestItem { Name = "child2", TemplateName = "Sample Item", Url = "/child2" };

            _itemRepository.Setup(r => r.GetItem(HomeItemId))
                           .Returns(_homeItem);

            _itemRepository.Setup(r => r.GetChildren(_homeItem))
                           .Returns(new[] { child1, child2 });
        }

        [Fact]
        public void ItemDoesNotExistReturnsEmptyList()
        {
            _itemRepository.Setup(r => r.GetItem(It.IsAny<string>()))
                           .Returns<IItem>(null);

            _navigationBuilder.NavigationForItem(HomeItemId)
                             .Count()
                             .ShouldEqual(0);
        }

        [Theory]
        [InlineData(HomeItemId, "/", true)]
        [InlineData(HomeItemId, "/child1", true)]
        [InlineData(HomeItemId, "/child2", true)]
        [InlineData("{110D559F-DEA5-42EA-9C1C-8A5DF7E70111}", "/", false)]
        public void VerifyReturnedItems(string itemId, string returnedItemUrl, bool isPresent)
        {
            _navigationBuilder.NavigationForItem(itemId)
                              .Any(x => x.Url == returnedItemUrl)
                              .ShouldEqual(isPresent);
        }
    }
}