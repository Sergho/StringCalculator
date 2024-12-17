namespace StringCalculator;

public class OperandLexeme(double value) : ILexeme
{
    public double Value { get; set; } = Math.Round(value, Constants.RoundDigits, MidpointRounding.AwayFromZero);
}