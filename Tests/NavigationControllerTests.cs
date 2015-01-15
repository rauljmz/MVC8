using Moq;
using MVC8.Business;
using MVC8.Controllers;
using MVC8.Models;
using MVC8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace Tests
{
    
    public class NavigationControllerTests
    {
        [Fact]
        public void ShouldPassDatasourceGuidToBuilder()
        {
            var homeID = "{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}";
            var renderingContext = new Mock<IRenderingContext>();
            renderingContext.Setup(rc => rc.DatasourceGuid).Returns(homeID);

            var navigationBuilder = new Mock<INavigationBuilder>();
            

            var navigationMenuController = new NavigationMenuController(navigationBuilder.Object, renderingContext.Object);

            var result = navigationMenuController.Index() as ViewResult;

            navigationBuilder.Verify(n => n.NavigationForItem(homeID), Times.Once);

        }
    }
}
