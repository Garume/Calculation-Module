using Calculation.Node;

namespace Calculation.Evaluation;

public class NotationEvaluator : IEvaluator
{
    public double Evaluate(INode node)
    {
        return node.Evaluate();
    }
}