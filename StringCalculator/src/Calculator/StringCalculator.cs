namespace StringCalculator;
public class StringCalculator(string expression) : IStringCalculator
{
    public string Expression { get; set; } = expression;

    private OperandLexeme ApplyOperation(OperationLexeme operation, OperandLexeme first, OperandLexeme second)
    {
        switch (operation.Operation)
        {
            case Operation.Addition:
                return new OperandLexeme(first.Value + second.Value);
            case Operation.Subtraction:
                return new OperandLexeme(first.Value - second.Value);
            case Operation.Multiplication:
                return new OperandLexeme(first.Value * second.Value);
            case Operation.Division:
                return new OperandLexeme(first.Value / second.Value);
            default:
                throw new UnknownOperationException();
        }
    }
    private double CalcPostExpression(List<ILexeme> postExpression)
    {
        Stack<OperandLexeme> stack = new Stack<OperandLexeme>();
        foreach (ILexeme lexeme in postExpression)
        {
            if (lexeme is OperandLexeme) stack.Push((OperandLexeme)lexeme);
            if (lexeme is OperationLexeme)
            {
                if (stack.Count < 2) throw new ExpressionSyntaxException();
                OperandLexeme second = stack.Pop();
                OperandLexeme first = stack.Pop();
                OperandLexeme result = ApplyOperation((OperationLexeme)lexeme, first, second);

                stack.Push(result);
            }
        }

        if (stack.Count != 1) throw new ExpressionSyntaxException();
        return stack.Pop().Value;
    }
    public string Calc()
    {
        StringParser parser = new StringParser();
        List<ILexeme> postExpression = parser.ComposePostExpression(Expression);
        return CalcPostExpression(postExpression).ToString();
    }
}