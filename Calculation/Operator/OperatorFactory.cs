namespace Calculation.Operator;

public static class OperatorFactory
{
    public static IOperator Create(string symbol)
    {
        return symbol switch
        {
            "+" => new AdditionOperator(),
            "-" => new SubtractionOperator(),
            "*" => new MultiplicationOperator(),
            "/" => new DivisionOperator(),
            _ => throw new ArgumentException($"Unknown operator: {symbol}")
        };
    }
}