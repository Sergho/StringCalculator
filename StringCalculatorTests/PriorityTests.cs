namespace StringCalculatorTests;
using StringCalculator;

public class PriorityTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("5 * 8 - 20")]
    public void OrderedTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("20", result);
    }

    [Theory]
    [InlineData("5 + 5 * 2")]
    public void AdditionMultiplicationTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("15", result);
    }

    [Theory]
    [InlineData("(5 + 5) * 2")]
    public void AdditionMultiplicationBracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("20", result);
    }

    [Theory]
    [InlineData("5 - 5 * 2")]
    public void SubtractionMultiplicationTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-5", result);
    }

    [Theory]
    [InlineData("(5 - 5) * 2")]
    public void SubtractionMultiplicationBracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("0", result);
    }

    [Theory]
    [InlineData("5 + 4 / 2")]
    public void AdditionDivisionTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("7", result);
    }

    [Theory]
    [InlineData("(5 + 4) / 2")]
    public void AdditionDivisionBracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("4,5", result);
    }

    [Theory]
    [InlineData("5 - 6 / 3")]
    public void SubtractionDivisionTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("3", result);
    }

    [Theory]
    [InlineData("(5 - 6) / 3")]
    public void SubtractionDivisionBracketsTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-0,33", result);
    }
}
