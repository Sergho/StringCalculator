namespace StringCalculator;
public class StringCalculator : IStringCalculator
{
    public string Expression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public StringCalculator(string expression)
    {
        Expression = expression;
    }

    public string Calc()
    {
        throw new NotImplementedException();
    }
}