namespace StringCalculatorTests;
using StringCalculator;

public class RegularTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("2 * (6 - (5 - 2) / 3) / 4")]
    public void ExampleTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("2,5", result);
    }

    [Theory]
    [InlineData("8 * ((6 - 2) / 2) * 1 - 3")]
    public void FirstRegularTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("13", result);
    }

    [Theory]
    [InlineData("((1 + 5) - (8 - 9)) * 2 / 8")]
    public void SecondRegularTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("1,75", result);
    }

    [Theory]
    [InlineData("(5 / 2 * (6 + 3)) / (7 - 8)")]
    public void ThirdRegularTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-22,5", result);
    }

    [Theory]
    [InlineData("7 * 3 * ((9 / 6) + 1) / (5 - 1)")]
    public void ForthRegularTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("13,13", result);
    }

    [Theory]
    [InlineData("((4 - 9) * (9 + 2) / 2) + 8")]
    public void FifthRegularTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("-19,5", result);
    }
}
