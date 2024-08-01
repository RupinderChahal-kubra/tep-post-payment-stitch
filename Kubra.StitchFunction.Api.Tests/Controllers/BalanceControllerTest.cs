using Kubra.Common.Stitch.Models;
using Kubra.StitchFunction.Api.Controllers;
using Kubra.StitchFunction.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Kubra.StitchFunction.Api.Tests.Controllers
{
    public class BalanceControllerTest
    {
        private readonly Mock<IBalanceService> _balanceServiceMock = new();

        [Fact]
        public async void GetBalance_ReturnsOk()
        {
            //Arrange
            var balance = GetMinimumRequiredBalance();
            _balanceServiceMock.Setup(x => x.GetBalance("1")).ReturnsAsync(balance);

            //Act
            var balController = new BalancesController(_balanceServiceMock.Object);
            var balanceResult = await balController.GetBalance(new BalanceRequest{AccountId = "1"});
            var result = balanceResult.Result as OkObjectResult;
            var actualResult = result?.Value as StitchBalanceResponse;

            //Assert
            Assert.NotNull(actualResult);
            Assert.Equal(GetMinimumRequiredBalance(), actualResult);
            Assert.Equal(200, result?.StatusCode);
        }

        [Fact]
        public async void GetBalance_ReturnsNoContent()
        {
            //Arrange
            var balance = GetNullBalanceResponse();
            _balanceServiceMock.Setup(x => x.GetBalance("1")).ReturnsAsync(balance);
            var balController = new BalancesController(_balanceServiceMock.Object);

            //Act
            var balanceResult = await balController.GetBalance(new BalanceRequest());
            var result = balanceResult.Result as NoContentResult;

            //Assert
            Assert.Equal(204, result!.StatusCode);
        }

        [Fact]
        public void GetBalance_ThrowsExceptionOnNullConstructor()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new BalancesController(null));
        }

        private StitchBalanceResponse GetMinimumRequiredBalance()
        {
            return new StitchBalanceResponse
            {
                CurrentAmountDue = 20.0m,
                DueDate = DateTime.Parse("2023-09-29"),
                LastUpdatedAtSourceDate = DateTime.Parse("2023-09-29")
            };
        }

        private StitchBalanceResponse? GetNullBalanceResponse()
        {
            return null;
        }
    }
}
