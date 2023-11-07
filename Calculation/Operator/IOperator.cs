namespace Calculation.Operator;

public interface IOperator
{
    string Value { get; }
    double PerformOperation(double left, double right);
}