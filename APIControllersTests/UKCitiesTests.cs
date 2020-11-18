using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Treely_2020.Controllers.API;

namespace APIControllersTests
{
    public class UnitTest1
    {

        [Fact]
        public void UKCitiesController_Can_Create()
        {
            //Arrange

            var mockHosting = new Mock<IHostingEnvironment>();

            var controller = new UKCitiesController(mockHosting.Object);

            //Act
            //var result = controller.Index();

            //Assert
            //Assert.IsAssignableFrom<ViewResult>(result);
            // mockLeagueService.VerifyGetAll(Times.Once());
            Assert.NotNull(controller);


        }

        [Fact]
        public void UKCitiesController_Get_Returns()
        {
            //Arrange

            var mockHosting = new Mock<IHostingEnvironment>();

            var controller = new UKCitiesController(mockHosting.Object);

            //Act
            var result = controller.Get();

            //Assert
            //Assert.IsAssignableFrom<ViewResult>(result);
            // mockLeagueService.VerifyGetAll(Times.Once());
            Assert.NotNull(result);


        }
    }
}
