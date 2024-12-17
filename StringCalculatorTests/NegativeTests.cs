namespace StringCalculatorTests;
using StringCalculator;

public class NegativeTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("6 / 0")]
    public void DivisionZeroTest(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => { Calculate(expression); });
    }

    [Theory]
    [InlineData("(5 + 3")]
    public void IncorrectBracketsTest(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() => { Calculate(expression); });
    }

    [Theory]
    [InlineData("5 / *")]
    public void DoubleOperatorTest(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() => { Calculate(expression); });
    }

    [Theory]
    [InlineData("5 6 *")]
    public void DoubleOperandTest(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() => { Calculate(expression); });
    }

    [Theory]
    [InlineData("5 - 5 a 2")]
    public void UnknownSymbolTest(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() => { Calculate(expression); });
    }

    [Theory]
    [InlineData("5")]
    public void ConstantTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("5", result);
    }

    [Theory]
    [InlineData("5+  4   /2")]
    public void SpacesTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("7", result);
    }

    [Theory]
    [InlineData("5 + 5, * 7")]
    public void FractionalSyntaxTest(string expression)
    {
        Assert.Throws<ExpressionSyntaxException>(() => { Calculate(expression); });
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
