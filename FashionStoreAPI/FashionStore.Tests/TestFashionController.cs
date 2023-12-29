using FashionStore.Core.Interfaces.Services;
using FashionStore.Core.Models;
using FashionStoreAPI.Controllers;
using Moq;
using Xunit;

namespace FashionStore.Tests
{
    public class TestFashionController
    {
        #region Tests

        [Fact]
        public async Task TestController_GetProducts()
        {
            //Arrange
            var mockIFashionStoreService = new Mock<IFashionStoreService>();
            mockIFashionStoreService.Setup(x => x.GetProducts()).ReturnsAsync(MockProducts);

            //Act
            var controller = new FashionStoreController(mockIFashionStoreService.Object);
            var response = await controller.GetProducts();

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TestController_GetCountries()
        {
            //Arrange
            var mockIFashionStoreService = new Mock<IFashionStoreService>();
            mockIFashionStoreService.Setup(x => x.GetCountries()).ReturnsAsync(MockCountries);

            //Act
            var controller = new FashionStoreController(mockIFashionStoreService.Object);
            var response = await controller.GetCountries();

            //Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task TestController_GetCurrency()
        {
            //Arrange
            var mockIFashionStoreService = new Mock<IFashionStoreService>();
            mockIFashionStoreService.Setup(x => x.GetCurrency(It.IsAny<string>())).ReturnsAsync(MockCurrency);

            //Act
            var controller = new FashionStoreController(mockIFashionStoreService.Object);
            var response = await controller.GetCurrency(It.IsAny<string>());

            //Assert
            Assert.NotNull(response);
        }
        #endregion

        #region MockData

        public static List<Product> MockProducts
        {
            get {
                return new List<Product> 
                { 
                    new Product 
                    { 
                        ProductId = 1, 
                        Name = "T-shirt", 
                        Description = "Mens t-shirt, size medium", 
                        Price = 19.99M 
                    } 
                };
            }
         }

        public static List<Country> MockCountries
        {
            get
            {
                return new List<Country>
                {
                    new Country
                    {
                        CountryId = 1, Name = "United States of America", CountryCode = "USA", CurrencyCode = "USD"
                    }
                };
            }
        }

        public static CurrencyExchangeRate MockCurrency
        {
            get
            {
                return new CurrencyExchangeRate
                {
                    CurrencyExchangeRateId = 1,
                    ExchangeRate = 1.24M,
                    CurrencyCode = "USD",
                    ValidFromDate = new DateTime(2023, 11, 1)
                };
            }
        }

        #endregion
    }
}
