
namespace StringCalculator;
public interface IStringParser
{
    List<ILexeme> ComposePostExpression(string expression);
}