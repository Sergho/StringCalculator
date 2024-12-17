namespace StringCalculator;

public class StringParser : IStringParser
{
    private ILexeme Identify(string part)
    {
        foreach (Operation operation in Enum.GetValues(typeof(Operation)))
        {
            if (part.Length != 1) break;
            if (((char)operation) == part[0]) return new OperationLexeme(operation);
        }

        if (part[0] == '(') return new OpenBracketLexeme();
        if (part[0] == ')') return new CloseBracketLexeme();

        try
        {
            return new OperandLexeme(double.Parse(part));
        }
        catch (Exception)
        {
            throw new ExpressionSyntaxException();
        }
    }
    private List<ILexeme> Split(string expression)
    {
        StringFormatter formatter = new StringFormatter();
        expression = formatter.Format(expression);

        string[] parts = expression.Split(" ");
        return parts.Select(Identify).ToList();
    }
    private List<ILexeme> PushOutOperations(OperationLexeme add, Stack<ILexeme> stack)
    {
        List<ILexeme> popped = new List<ILexeme>();
        while (stack.Count != 0)
        {
            ILexeme first = stack.First();

            if (first is OpenBracketLexeme) break;

            int currentPriority = Constants.Priorities[add.Operation];
            int firstPriority = Constants.Priorities[((OperationLexeme)first).Operation];

            if (firstPriority < currentPriority) break;

            popped.Add(stack.Pop());
        }

        stack.Push(add);
        return popped;
    }
    private List<ILexeme> PushOutBrackets(Stack<ILexeme> stack)
    {
        List<ILexeme> popped = new List<ILexeme>();
        while (stack.Count != 0)
        {
            ILexeme first = stack.First();

            if (first is OpenBracketLexeme)
            {
                stack.Pop();
                break;
            }

            popped.Add(stack.Pop());
        }

        return popped;
    }
    private List<ILexeme> PushOutAll(Stack<ILexeme> stack)
    {
        List<ILexeme> popped = new List<ILexeme>();
        while (stack.Count != 0)
        {
            popped.Add(stack.Pop());
        }
        return popped;
    }
    public List<ILexeme> ComposePostExpression(string expression)
    {
        List<ILexeme> postExpression = new List<ILexeme>();
        Stack<ILexeme> stack = new Stack<ILexeme>();

        foreach (ILexeme lexeme in Split(expression))
        {
            if (lexeme is OperandLexeme) postExpression.Add(lexeme);
            if (lexeme is OperationLexeme)
            {
                List<ILexeme> subExpression = PushOutOperations((OperationLexeme)lexeme, stack);
                postExpression.AddRange(subExpression);
            }
            if (lexeme is OpenBracketLexeme) stack.Push(lexeme);
            if (lexeme is CloseBracketLexeme)
            {
                List<ILexeme> subExpression = PushOutBrackets(stack);
                postExpression.AddRange(subExpression);
            }
        }
        postExpression.AddRange(PushOutAll(stack));
        return postExpression;
    }
}