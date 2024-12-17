namespace StringCalculator;
public interface IStringCalculator
{
    string Expression { get; set; }
    string Calc();
}