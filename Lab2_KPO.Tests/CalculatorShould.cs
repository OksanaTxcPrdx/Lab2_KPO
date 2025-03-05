using Lab2_KPO;

namespace Lab2_KPO.Tests;

public class CalculatorShould
{
    private readonly Calculator _sut = new();
    
    [Theory]
    [InlineData("2+2", 4)]
    [InlineData("2+2*2", 6)]
    [InlineData("2/4", 0.5)]
    [InlineData("(2+2)*2", 8)]
    [InlineData("10-5", 5)]
    [InlineData("3*7", 21)]
    [InlineData("12/3", 4)]
    [InlineData("2-8", -6)]
    public void ReturnSuccess_WhenResultEqualExpected(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual);
    }
    
    [Theory]
    [InlineData("sin(0)", 0)]
    [InlineData("sin(pi/2)", 1)]
    [InlineData("cos(0)", 1)]
    [InlineData("cos(pi)", -1)]
    [InlineData("tan(0)", 0)]
    [InlineData("tan(pi/4)", 1)]
    public void ReturnSuccess_WhenTrigonometricFunctionsAreUsed(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual, 5); // Точность до 5 знаков после запятой
    }
    
    [Theory]
    [InlineData("log(10, 100)", 2)]
    [InlineData("log(2, 8)", 3)]
    [InlineData("ln(e)", 1)]
    [InlineData("log10(100)", 2)]
    [InlineData("exp(0)", 1)]
    [InlineData("exp(1)", 2.71828)]
    public void ReturnSuccess_WhenLogarithmsAndExponentsAreUsed(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual, 5); // Точность до 5 знаков после запятой
    }
    
    [Theory]
    [InlineData("2^3", 8)]
    [InlineData("4^0.5", 2)]
    [InlineData("sqrt(16)", 4)]
    [InlineData("sqrt(2)", 1.41421)]
    [InlineData("8^(1/3)", 2)]
    [InlineData("27^(1/3)", 3)]
    public void ReturnSuccess_WhenPowersAndRootsAreUsed(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual, 5); // Точность до 5 знаков после запятой
    }
    
    [Theory]
    [InlineData("pi", 3.14159)]
    [InlineData("e", 2.71828)]
    [InlineData("pi + e", 3.14159 + 2.71828)]
    public void ReturnSuccess_WhenConstantsAreUsed(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual, 5); // Точность до 5 знаков после запятой
    }
    
    [Theory]
    [InlineData("(2+3)*4", 20)]
    [InlineData("2+3*4", 14)]
    [InlineData("(2+3)*(4+5)", 45)]
    [InlineData("2^3 + 4*5", 28)]
    [InlineData("sqrt(16) + log(10, 100)", 6)]
    [InlineData("sin(pi/2) + cos(0)", 2)]
    public void ReturnSuccess_WhenCombinedExpressionsAreUsed(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        Assert.Equal(expectedResult, actual);
    }
    
    [Theory]
    [InlineData("2 / 0", double.NaN)] 
    [InlineData("-2 / 0", double.NaN)] 
    [InlineData("sqrt(-1)", double.NaN)] 
    public void ReturnNaN_WhenExpressionNotValidResult(string expression, double expectedResult)
    {
        var actual = _sut.Compute(expression);
        
        Assert.Equal(actual, expectedResult);
    }

    [Theory]
    [InlineData("2 / ")]
    [InlineData("invalid expression")]
    public void ReturnException_WhenExpressionIsInvalid(string expression)
    {
        Assert.Throws<ArgumentException>(() => _sut.Compute(expression));
    }
}