using Calculation.Operator;

namespace Calculation.Node;

public sealed class OperatorNode : INode
{
    public OperatorNode(IOperator operatorStrategy, INode left, INode right)
    {
        OperatorStrategy = operatorStrategy ?? throw new ArgumentNullException(nameof(operatorStrategy));
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    private IOperator OperatorStrategy { get; }
    public INode Left { get; }
    public INode Right { get; }

    public string Value => OperatorStrategy.Value;

    public double Evaluate()
    {
        var leftValue = Left.Evaluate();
        var rightValue = Right.Evaluate();
        return OperatorStrategy.PerformOperation(leftValue, rightValue);
    }
}