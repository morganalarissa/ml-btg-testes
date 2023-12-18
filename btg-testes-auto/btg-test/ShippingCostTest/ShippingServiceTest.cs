using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
        private readonly ShippingService _service;

        public ShippingServiceTest()
        {
            _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _service = new(_mockDeliveryCostCalculator);
        }


        [Fact]
        public void CalculateShippingCost_OrdinaryDelivery_ReturnsCorrectCost()
        {
            // Arrange
            double distance = 100;
            DeliveryType deliveryType = DeliveryType.Ordinary;
            double expectedCost = 10;

            _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(expectedCost);

            // Act
            double actualCost = _service.CalculateShippingCost(distance, deliveryType);

            // Assert
            actualCost.Should().Be(expectedCost);
            _mockDeliveryCostCalculator.Received(1).CalculateCost(Arg.Is(distance), Arg.Is(deliveryType));
        }

        [Fact]
        public void CalculateShippingCost_ExpressDeliveryAbove200km_Applies50PercentDiscount()
        {
            // Arrange
            double distance = 250;
            DeliveryType deliveryType = DeliveryType.Express;
            double originalCost = 20;
            double expectedCostAfterDiscount = originalCost * 0.5;

            _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(originalCost);

            // Act
            double actualCost = _service.CalculateShippingCost(distance, deliveryType);

            // Assert
            actualCost.Should().Be(expectedCostAfterDiscount);
            _mockDeliveryCostCalculator.Received(1).CalculateCost(Arg.Is(distance), Arg.Is(deliveryType));
        }

        [Fact]
        public void CalculateShippingCost_ApplyDiscount_ReturnDiscountApplied()
        {
            // Arrange
            double distance = 250;
            DeliveryType deliveryType = DeliveryType.Express;
            _mockDeliveryCostCalculator.CalculateCost(Arg.Any<double>(), Arg.Any<DeliveryType>()).Returns(100);

            // Act
            double result = _service.CalculateShippingCost(distance, deliveryType);

            // Assert
            result.Should().Be(50);
        }

        [Theory]
        [InlineData(200, DeliveryType.Express)]
        [InlineData(100, DeliveryType.Express)]
        [InlineData(250, DeliveryType.Ordinary)]
        [InlineData(100, DeliveryType.Ordinary)]
        [InlineData(200, DeliveryType.Ordinary)]
        public void CalculateShippingCost_ApplyDiscount_ReturnDiscountNotApplied(double distance, DeliveryType deliveryType)
        {
            // Arrange
            _mockDeliveryCostCalculator.CalculateCost(Arg.Any<double>(), Arg.Any<DeliveryType>()).Returns(100);

            // Act
            double result = _service.CalculateShippingCost(distance, deliveryType);

            // Assert
            result.Should().Be(100);
        }

        [Fact]
        public void CalculateShippingCost_ApplyDiscountForExpressAbove200_ReturnDiscountApplied()
        {
            // Arrange
            double distance = 210; 
            DeliveryType deliveryType = DeliveryType.Express;
            _mockDeliveryCostCalculator.CalculateCost(Arg.Any<double>(), Arg.Any<DeliveryType>()).Returns(100);

            // Act
            double result = _service.CalculateShippingCost(distance, deliveryType);

            // Assert
            result.Should().Be(50);
        }

    }
}
