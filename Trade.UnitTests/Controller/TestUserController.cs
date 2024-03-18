using Microsoft.AspNetCore.Mvc;
using Moq;
using Trade.Domain.Interfaces.Services;
using Trade.Technology.Controllers;
using Trade.UnitTests.MockData;
using Xunit;


namespace Trade.UnitTests.Controller
{
    public class TestUserController
    {
        private readonly Mock<IUserService> userService;
        public TestUserController()
        {
            userService = new Mock<IUserService>();
        }

        [Fact]
        public async Task GetUserAsync_ShouldReturn200Status()
        {
            //arrange
            var userList = UserMockData.GetUsersData();

            userService.Setup(x => x.GetUser("testeUser@gmail.com"))
                .ReturnsAsync(userList[1]);

            var userController = new UserController(userService.Object);

            //act
            var userResult = await userController.Get("testeUser@gmail.com");
            var okResult = userResult as ObjectResult;


            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetUserAsync_ShouldReturn204NoContentStatus()
        {
            //arrange
            var userList = UserMockData.GetUsersData();

            userService.Setup(x => x.GetUser("testeUser@hotmail.com"))
                .ReturnsAsync(userList[1]);

            var userController = new UserController(userService.Object);

            //act
            var userResult = (NoContentResult)await userController.Get("testeUser@hotmail.com");
            

            //assert
            Assert.NotNull(userResult);
            Assert.Equal(204, userResult.StatusCode);
        }
    }
}
