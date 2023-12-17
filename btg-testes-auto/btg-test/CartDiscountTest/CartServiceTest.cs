using btg_testes_auto.CartDiscount;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.CartDiscountTest
{
    public class CartServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private readonly CartService _sut;

        public CartServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _sut = new CartService(_mockDiscountService);
        }

        [Fact]
        public void CalculateTotalWithDiscount_ShouldCalculateCorrectly()
        {
            // Arrange
            var items = new List<CartItem>
            {
                new CartItem { ProductId = "1", Price = 20 },
                new CartItem { ProductId = "2", Price = 30 },
                new CartItem { ProductId = "3", Price = 40 }
            };

            _mockDiscountService.CalculateDiscount(items).Returns(10);

            // Act
            var result = _sut.CalculateTotalWithDiscount(items);

            // Assert
            Assert.Equal(80, result); // total sem desconto é 90 e com o desconto de 10
        }

        [Fact]
        public void CalculateTotalWithDiscount_NoDiscount_ShouldReturnTotalAmount()
        {
            // Arrange
            var items = new List<CartItem>
            {
                new CartItem { ProductId = "1", Price = 20 },
                new CartItem { ProductId = "2", Price = 30 },
                new CartItem { ProductId = "3", Price = 40 }
            };

            //sem desconto pra teste
            _mockDiscountService.CalculateDiscount(items).Returns(0);

            // Act
            var result = _sut.CalculateTotalWithDiscount(items);

            // Assert
            Assert.Equal(90, result); // total sem descconto é 90
        }

    }
}
