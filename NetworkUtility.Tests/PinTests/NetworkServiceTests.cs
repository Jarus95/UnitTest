using FluentAssertions;
using FluentAssertions.Formatting;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PinTests
{
    public class NetworkServiceTests : IClassFixture<NetworkServices>
    {
        private readonly NetworkServices _pingServices;
        public NetworkServiceTests(NetworkServices services)
        {
            _pingServices = services;
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange

            //Act
            var result = _pingServices.SendPing();
            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: ping sent");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(2, 4, 6)]
        public void NetworkService_PingTimeOut_ReturnInt(int a, int b, int expected) 
        {
            //Arrange
            //Act
            var result = _pingServices.PingTimeOut(a,b);
            //Assert
            result.Should().Be(expected);
            result.Should().NotBeInRange(-1000, 0);
            result.Should().BeGreaterThanOrEqualTo(4);
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _pingServices.GetPingOption();
            //Assert
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.DontFragment.Should().BeTrue();
            result.Ttl.Should().Be(1);
     
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObjects()
        {
            //Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 1
            };
            //Act
            var result = _pingServices.GetPingOptions();
            //Assert
            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
            result.Should().Contain(x => x.Ttl == 1);

        }
    }
}
