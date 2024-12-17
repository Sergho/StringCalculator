namespace StringCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        StringCalculator calculator = new StringCalculator("2 * ( 6 - ( 5 - 2 ) / 3 ) / 4");
        Console.WriteLine(calculator.Calc());
    }
}