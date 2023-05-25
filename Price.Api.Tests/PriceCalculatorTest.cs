using Price.Api.PriceCalculator;
using Xunit;

namespace Price.Api.Tests
{
    public class PriceCalculatorTest
    {
        [Fact]
        public void Factory_Economy_Ok()
        {
            //Act
            var calculator = PriceCalculatorFactory.GetCalculator(RoomType.Economy);

            //Assert
            Assert.IsType<EconomyCalculator>(calculator);
        }

        [Fact]
        public void Factory_Standard_Ok()
        {
            //Act
            var calculator = PriceCalculatorFactory.GetCalculator(RoomType.Standard);

            //Assert
            Assert.IsType<StandardCalculator>(calculator);
        }

        [Fact]
        public void Factory_Deluxe_Ok()
        {
            //Act
            var calculator = PriceCalculatorFactory.GetCalculator(RoomType.Deluxe);

            //Assert
            Assert.IsType<DeluxeCalculator>(calculator);
        }

        public static IEnumerable<object[]> GetRequests()
        {
            yield return new object[] 
            {
                new PriceRequest { Guests = 2, Nights = 5, RoomType= RoomType.Economy}, 2250
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 2, Nights = 5, RoomType= RoomType.Standard}, 3100
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 2, Nights = 5, RoomType= RoomType.Deluxe}, 3950
            };
        }

        [Theory]
        [MemberData(nameof(GetRequests))]
        public void Calculator_GetPrice_Ok(PriceRequest req, decimal expectedPrice)
        {
            //Assign
            var calculator = PriceCalculatorFactory.GetCalculator(req.RoomType);

            var price = calculator.GetPrice(req);

            //Assert
            Assert.Equal(expectedPrice, price);
        }

        public static IEnumerable<object[]> GetValidationErrors()
        {
            yield return new object[]
            {
                new PriceRequest { Guests = 3, Nights = 5, RoomType= RoomType.Economy}
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 4, Nights = 5, RoomType= RoomType.Standard}
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 5, Nights = 5, RoomType= RoomType.Deluxe}
            };
        }

        [Theory]
        [MemberData(nameof(GetValidationErrors))]
        public void Validate_Guests_NotValid(PriceRequest req)
        {
            //Assign
            var calculator = PriceCalculatorFactory.GetCalculator(req.RoomType);

            var isValid = calculator.Validate(req);

            //Assert

            Assert.False(isValid);
        }

        public static IEnumerable<object[]> GetValidationSuccess()
        {
            yield return new object[]
            {
                new PriceRequest { Guests = 2, Nights = 5, RoomType= RoomType.Economy}
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 3, Nights = 5, RoomType= RoomType.Standard}
            };
            yield return new object[]
            {
                new PriceRequest { Guests = 4, Nights = 5, RoomType= RoomType.Deluxe}
            };
        }

        [Theory]
        [MemberData(nameof(GetValidationSuccess))]
        public void Validate_Ok(PriceRequest req)
        {
            //Assign
            var calculator = PriceCalculatorFactory.GetCalculator(req.RoomType);

            var isValid = calculator.Validate(req);

            //Assert

            Assert.True(isValid);
        }
    }
}