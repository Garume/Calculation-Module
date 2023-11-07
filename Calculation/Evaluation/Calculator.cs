using Calculation.Evaluation;
using Calculation.NotationParser;

namespace Calculation;

public class Calculator
{
    private readonly IEvaluator _calculator;

    public Calculator(IEvaluator calculator)
    {
        _calculator = calculator;
    }

    public Calculator()
    {
        _calculator = new NotationEvaluator();
    }

    private double Calculate(string expression, IParserStrategy parserStrategy)
    {
        var parser = new Parser(parserStrategy);
        var node = parser.Parse(expression);
        var result = _calculator.Evaluate(node);
        if (double.IsInfinity(result))
            throw new OverflowException();
        return result;
    }

    public double CalculateInfix(string expression)
    {
        return Calculate(expression, new InfixNotationParser());
    }

    public double CalculatePrefix(string expression)
    {
        return Calculate(expression, new PrefixNotationParser());
    }

    public double CalculatePostfix(string expression)
    {
        return Calculate(expression, new PostfixNotationParser());
    }
}