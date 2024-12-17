namespace StringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        StringParser parser = new StringParser();
        List<ILexeme> result = parser.PostExpression("2 * ( 6 - ( 5 - 2 ) / 3 ) / 4");
    }
}