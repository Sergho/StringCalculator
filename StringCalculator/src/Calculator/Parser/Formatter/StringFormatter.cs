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
        expression = Regex.Replace(expression, @"_\*", " * ");
        expression = Regex.Replace(expression, @"_\/", " / ");
        return expression;
    }
    private string CollapseOffsets(string expression)
    {
        expression = Regex.Replace(expression, @"\s+", " ");
        return expression;
    }
    public string Format(string expression)
    {
        expression = MarkBinary(expression);
        expression = MakeOffsets(expression);
        expression = CollapseOffsets(expression);
        return expression;
    }
}