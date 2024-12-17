
namespace StringCalculator;
public interface IStringParser
{
    List<ILexeme> PostExpression(string expression);
}