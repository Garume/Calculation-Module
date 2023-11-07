namespace Calculation.Node;

public interface INode
{
    string Value { get; }
    INode Left { get; }
    INode Right { get; }
    double Evaluate();
}