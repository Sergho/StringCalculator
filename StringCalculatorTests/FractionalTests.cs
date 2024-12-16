namespace StringCalculatorTests;
using StringCalculator;

public class FractionalTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("5,34 * 8")]
    public void OneFractionalOperandTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("42,72", result);
    }

    [Theory]
    [InlineData("5,34 - 6,16")]
    public void TwoFractionalOperandsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-0,82", result);
    }

    [Theory]
    [InlineData("7 / 2")]
    public void FractionalResultTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("3,5", result);
    }

    [Theory]
    [InlineData("5 / 3")]
    public void RoundingUpTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("1,67", result);
    }

    [Theory]
    [InlineData("1 / 3")]
    public void RoundingDownTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("0,33", result);
    }
}
