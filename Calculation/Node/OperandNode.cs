namespace Calculation.Node;

public sealed class OperandNode : INode
{
    public OperandNode(string value)
    {
        Value = value;
    }

    public string Value { get; }
    public INode Left => null!;
    public INode Right => null!;

    public double Evaluate()
    {
        if (Value.Count(x => Equals(x, '.')) > 1)
            throw new FormatException("Operand cannot contain more than one decimal point.");

        if (!double.TryParse(Value, out var result))
            throw new FormatException("Operand must be a number.");
        return result;
    }
}