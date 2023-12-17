using btg_testes_auto.Discount;
using Castle.Core.Resource;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ClienteDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private DiscountService _sut;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _sut = new DiscountService(_mockCustomerService);
        }

        [Fact]
        public void GetDiscount_RegularCustomer_Returns5PercentDiscount()
        {
            // Arrange

            _mockCustomerService.GetCustomerType(1).Returns(CustomerType.Regular);

            // Act
            double discount = _sut.GetDiscount(1, 100);

            // Assert
            _mockCustomerService.Received(1).GetCustomerType(1);
            discount.Should().Be(100 * 0.05);
        }

        [Fact]
        public void GetDiscount_PremiumCustomer_Returns10PercentDiscount()
        {
            // Arrange
            _mockCustomerService.GetCustomerType(2).Returns(CustomerType.Premium);

            // Act
            double discount = _sut.GetDiscount(2, 150);

            // Assert
            _mockCustomerService.Received(1).GetCustomerType(2);
            discount.Should().Be(150 * 0.1);
        }

        [Fact]
        public void GetDiscount_OtherCustomer_ReturnsNoDiscount()
        {
            // Arrange
            _mockCustomerService.GetCustomerType(3).Returns(CustomerType.NotClient);

            // Act
            double discount = _sut.GetDiscount(3, 200);

            // Assert
            _mockCustomerService.Received(1).GetCustomerType(3);
            discount.Should().Be(0); 
        }
    }
}
