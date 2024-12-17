using System.Runtime.InteropServices;

namespace StringCalculator;

public class StringParser : IStringParser
{
    private ILexeme Identify(string part)
    {
        foreach (Operation operation in Enum.GetValues(typeof(Operation)))
        {
            if (((char)operation) == part[0]) return new OperationLexeme(operation);
        }

        if (part[0] == '(') return new BracketLexeme(true);
        if (part[0] == ')') return new BracketLexeme(false);

        try
        {
            return new OperandLexeme(int.Parse(part));
        }
        catch (Exception)
        {
            throw new ExpressionSyntaxException();
        }
    }
    private List<ILexeme> Split(string expression)
    {
        string[] parts = expression.Split(" ");
        return parts.Select(Identify).ToList();
    }
    public List<ILexeme> PostExpression(string expression)
    {
        Split(expression);
        return new List<ILexeme>();
    }
}