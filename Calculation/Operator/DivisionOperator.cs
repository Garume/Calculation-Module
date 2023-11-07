namespace Calculation.Operator;

public sealed class DivisionOperator : IOperator
{
    private static string OperatorValue => "/";
    public string Value => OperatorValue;

    public double PerformOperation(double left, double right)
    {
        if (right == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return left / right;
    }
}