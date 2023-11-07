namespace Calculation;

public static class Calculator
{
    private static double Calculate(INode node)
    {
        var result = (double)node.Evaluate();
        if (double.IsInfinity(result))
            throw new OverflowException("Result is infinity");
        return result;
    }

    public static double Calculate(StringNotation notation)
    {
        var nodeParser = new NodeParser(notation);
        if (!nodeParser.TryParse(out var node))
            throw new InvalidOperationException("Invalid expression");
        return Calculate(node);
    }
}