using Moq;
using MVC8.Business;
using System.Linq;
using Should;
using Xunit;

namespace Tests
{
    public class NavigationBuilderTest
    {
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly NavigationBuilder _navigationBuilder;

        private readonly TestItem _child1;
        private readonly TestItem _child2;
        private readonly TestItem _homeItem;

        public NavigationBuilderTest()
        {
            _itemRepository = new Mock<IItemRepository>();

            _navigationBuilder = new NavigationBuilder(_itemRepository.Object);

            _homeItem = new TestItem { Name = "Home", TemplateName = "Sample Item", Url = "/" };

            _child1 = new TestItem { Name = "child1", TemplateName = "Sample Item", Url = "/child1" };
            _child2 = new TestItem { Name = "child2", TemplateName = "Sample Item", Url = "/child2" };


            _itemRepository.Setup(r => r.GetItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"))
                           .Returns(_homeItem);

            _itemRepository.Setup(r => r.GetChildren(_homeItem))
                           .Returns(new[] { _child1, _child2 });
        }

        [Fact]
        public void ItemDoesNotExistReturnsEmptyList()
        {
            _itemRepository.Setup(r => r.GetItem(It.IsAny<string>()))
                           .Returns<IItem>(null);

            _navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
                             .Count()
                             .ShouldEqual(0);
        }

        [Fact]
        public void ReturnsAllFirstLevelChildren()
        {
            var result = _navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}").ToArray();

            result.Any(x => x.Url == _child1.Url).ShouldBeTrue();
            result.Any(x => x.Url == _child2.Url).ShouldBeTrue();
        }

        [Fact]
        public void ReturnsHomeItem()
        {
            _navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
                              .First()
                              .Url.ShouldEqual(_homeItem.Url);
        }
    }
}
