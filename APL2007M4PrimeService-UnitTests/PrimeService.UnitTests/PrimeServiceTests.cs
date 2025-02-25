namespace System.Number.UnitTests
{
public class PrimeServiceTest{
    [Fact]
    public void IsPrime_InputIs1_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(1);

        // Assert
        Assert.False(result, "1 should not be prime");
    }
}
namespace System.Number.UnitTests;
public class PrimeServiceTest
{
    [Fact]
    public void IsPrime_InputIs1_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(1);

        // Assert
        Assert.False(result, "1 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIsNegative_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(-5);

        // Assert
        Assert.False(result, "-5 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIs0_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(0);

        // Assert
        Assert.False(result, "0 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIs2_ReturnTrue()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(2);

        // Assert
        Assert.True(result, "2 should be prime");
    }

    [Fact]
    public void IsPrime_InputIsEvenNumberGreaterThan2_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(4);

        // Assert
        Assert.False(result, "4 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIsOddPrimeNumber_ReturnTrue()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(5);

        // Assert
        Assert.True(result, "5 should be prime");
    }

    [Fact]
    public void IsPrime_InputIsOddNonPrimeNumber_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(9);

        // Assert
        Assert.False(result, "9 should not be prime");
    }

    [Fact]
    public void IsPrime_InputIsLargePrimeNumber_ReturnTrue()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(7919);

        // Assert
        Assert.True(result, "7919 should be prime");
    }

    [Fact]
    public void IsPrime_InputIsLargeNonPrimeNumber_ReturnFalse()
    {
        // Arrange
        var primeService = new PrimeService();

        // Act
        var result = primeService.IsPrime(8000);

        // Assert
        Assert.False(result, "8000 should not be prime");
    }
}
}