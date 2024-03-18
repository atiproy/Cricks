using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cricks.Controllers;
using Cricks.Data;
using Cricks.Data.DbModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
namespace Test
{
    public class PlayerControllerTests
    {
        [Fact]
        public async Task AssignRole_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            var mockUserManager = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object,
                null, null, null, null, null, null, null, null);
            mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((IdentityUser)null);

            var mockLogger = new Mock<ILogger<AdminController>>();

            var controller = new AdminController(mockUserManager.Object, mockLogger.Object);

            // Act
            var result = await controller.AssignRole("nonexistentuser", "Admin");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
