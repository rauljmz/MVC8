using Moq;
using MVC8.Business;
using MVC8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class NavigationBuilderTest
    {
        [Fact]
        public void ItemDoesNotExistReturnsEmptyList()
        {
            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(r => r.GetItem(It.IsAny<string>())).Returns((IItem)null);

            var navigationBuilder = new NavigationBuilder(itemRepository.Object);

            var result = navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");

            Assert.Empty(result);
        }

        [Fact]
        public void ReturnsAllFirstLevelChildren()
        {
            var homeItem = new TestItem() { Name = "Home", TemplateName = "Sample Item", Url = "/" };
            var child1 = new TestItem() { Name = "child1", TemplateName = "Sample Item", Url = "/child1" };
            var child2 = new TestItem() { Name = "child2", TemplateName = "Sample Item", Url = "/child2" };

            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(r => r.GetItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")).Returns(homeItem);
            itemRepository.Setup(r => r.GetChildren(homeItem)).Returns(new[] {child1,child2 });

            var navigationBuilder = new NavigationBuilder(itemRepository.Object);

            var result = navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");

            Assert.Single(result, n => n.Url == child1.Url);
            Assert.Single(result, n => n.Url == child2.Url);
        }

        [Fact]
        public void ReturnsHomeItem()
        {
            var homeItem = new TestItem() { Name = "Home", TemplateName = "Sample Item", Url = "/" };
            var child1 = new TestItem() { Name = "child1", TemplateName = "Sample Item", Url = "/child1" };
            var child2 = new TestItem() { Name = "child2", TemplateName = "Sample Item", Url = "/child2" };

            var itemRepository = new Mock<IItemRepository>();
            itemRepository.Setup(r => r.GetItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")).Returns(homeItem);
            itemRepository.Setup(r => r.GetChildren(homeItem)).Returns(new[] { child1, child2 });

            var navigationBuilder = new NavigationBuilder(itemRepository.Object);

            var result = navigationBuilder.NavigationForItem("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");

            Assert.Single(result, n => n.Url == homeItem.Url);
        }
    }
}
