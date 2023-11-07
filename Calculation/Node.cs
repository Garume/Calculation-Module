namespace Calculation;

public abstract class Node<T> : INode
{
    protected Node(T value, Node<T> left, Node<T> right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    protected Node(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }


    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }
    public T Value { get; }

    public abstract double Evaluate();
}