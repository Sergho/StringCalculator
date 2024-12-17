namespace StringCalculatorTests;
using StringCalculator;

public class ComplexTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("5 + 13 - 54")]
    public void TwoOperationsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-46", result);
    }

    [Theory]
    [InlineData("5 * 6 / 3 - 4")]
    public void ThreeOperationsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("6", result);
    }

    [Theory]
    [InlineData("9 / 3 * 8 - 4 + -5")]
    public void FourOperationsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("15", result);
    }

    [Theory]
    [InlineData("30 / (3 + 2) * (5 - 4)")]
    public void BracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-5", result);
    }

    [Theory]
    [InlineData("((5 * 10)) - (5) * (8)")]
    public void ExtraBracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("10", result);
    }
}
