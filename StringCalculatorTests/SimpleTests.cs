namespace StringCalculatorTests;
using StringCalculator;

public class SimpleTests
{
    private string Calculate(string expression)
    {
        var calculator = new StringCalculator(expression);
        string result = calculator.Calc();

        return result;
    }

    [Theory]
    [InlineData("5 + 13")]
    public void AdditionTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("18", result);
    }

    [Theory]
    [InlineData("18 - 14")]
    public void SubtractionTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("4", result);
    }

    [Theory]
    [InlineData("14 * 9")]
    public void MultiplicationTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("126", result);
    }

    [Theory]
    [InlineData("169 / 13")]
    public void DivisionTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("13", result);
    }

    [Theory]
    [InlineData("-14 + 27")]
    public void FirstNegativeOperandTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("13", result);
    }

    [Theory]
    [InlineData("13 - -13")]
    public void SecondNegativeOperandTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("26", result);
    }

    [Theory]
    [InlineData("54 / -9")]
    public void NegativeResultTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("6", result);
    }

    [Theory]
    [InlineData("+14 + 27")]
    public void FirstForcePositiveOperandTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("41", result);
    }

    [Theory]
    [InlineData("13 - +13")]
    public void SecondForcePositiveOperandTest(string expression)
    {
        string result = Calculate(expression);
        Assert.Equal("0", result);
    }
}
