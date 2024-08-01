using System.ServiceModel;
using Kubra.Common.Stitch.Models;
using Kubra.StitchFunction.Api.Services;
using MockClientSOAPService;
using Moq;
using BalanceRequest = MockClientSOAPService.BalanceRequest;

namespace Kubra.StitchFunction.Api.Tests.Services
{
    public class SoapBalanceServiceTest
    {
        private Mock<ISoapService> _mockSoapService = new();
        [Fact]
        public void GetBalance_ThrowsNullArgumentException()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new SoapBalanceService(null));
        }

        [Fact]
        public async void GetBalance_ReturnsStitchBalanceResponse()
        {
            //Arrange
            _mockSoapService.Setup(s => s.BalanceAsync(It.IsAny<BalanceRequest>()))
                .ReturnsAsync(GetSoapBalanceResponse);
            var balanceService = new SoapBalanceService(_mockSoapService.Object);
            //Act
            var response = await balanceService.GetBalance("1");

            //Assert
            Assert.IsType<StitchBalanceResponse>(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async void GetBalance_ThrowsExeptionOnNull()
        {
            //Arrange
            _mockSoapService.Setup(s => s.BalanceAsync(It.IsAny<BalanceRequest>()))
                .ReturnsAsync(new BalanceResponse());
            var balanceService = new SoapBalanceService(_mockSoapService.Object);
            //Act

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await balanceService.GetBalance("1"));
        }

        private BalanceResponse GetSoapBalanceResponse()
        {
            return new BalanceResponse(new BalanceResponseBody(new Response
                { DueDate = DateTime.Parse("2023-10-13"), AmountDue = 13.00m }));

        }
    }
}
