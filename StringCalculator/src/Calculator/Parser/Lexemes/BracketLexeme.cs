namespace StringCalculator;

public class BracketLexeme(bool open) : ILexeme
{
    public bool Open { get; set; } = open;
}