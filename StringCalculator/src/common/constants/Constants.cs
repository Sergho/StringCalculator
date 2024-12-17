namespace StringCalculator;

public static class Constants
{
    public static readonly Dictionary<Operation, int> Priorities = new Dictionary<Operation, int>
    {
        {Operation.Addition, 1},
        {Operation.Subtraction, 1},
        {Operation.Multiplication, 2},
        {Operation.Division, 2},
    };
}