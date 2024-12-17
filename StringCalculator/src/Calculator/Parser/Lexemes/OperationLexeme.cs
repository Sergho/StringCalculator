namespace StringCalculator;

public class OperationLexeme(Operation operation) : ILexeme
{
    public Operation Operation { get; set; } = operation;
}