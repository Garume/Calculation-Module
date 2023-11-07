namespace Calculation.Operator;

public interface IOperator
{
    static string OperatorValue { get; }
    string Value { get; }
    double PerformOperation(double left, double right);
}