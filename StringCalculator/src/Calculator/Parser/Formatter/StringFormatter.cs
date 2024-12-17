using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringFormatter : IStringFormatter
{
    private string MarkBinary(string expression)
    {
        expression = Regex.Replace(expression, @"([0-9]\s*)([\-])", "$1_-");
        expression = Regex.Replace(expression, @"([0-9]\s*)([\+])", "$1_+");
        return expression;
    }
    private string MakeOffsets(string expression)
    {
        expression = Regex.Replace(expression, @"_-", " - ");
        expression = Regex.Replace(expression, @"_\+", " + ");
        expression = Regex.Replace(expression, @"\*", " * ");
        expression = Regex.Replace(expression, @"\/", " / ");
        expression = Regex.Replace(expression, @"\(", " ( ");
        expression = Regex.Replace(expression, @"\)", " ) ");
        return expression;
    }
    private string CollapseOffsets(string expression)
    {
        expression = Regex.Replace(expression, @"\s+", " ");
        return expression;
    }
    private void CheckDoubleOperators(string expression)
    {
        if (Regex.Match(expression, @"[\+\-\*\/]\s[\+\-\*\/]").Success)
        {
            throw new ExpressionSyntaxException();
        }
    }
    private void CheckDoubleOperands(string expression)
    {
        if (Regex.Match(expression, @"[0-9]\s[0-9]").Success)
        {
            throw new ExpressionSyntaxException();
        }
    }
    public string Format(string expression)
    {
        expression = MarkBinary(expression);
        expression = MakeOffsets(expression);
        expression = CollapseOffsets(expression);

        CheckDoubleOperands(expression);
        CheckDoubleOperators(expression);

        return expression;
    }
}