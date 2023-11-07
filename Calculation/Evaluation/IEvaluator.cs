using Calculation.Node;

namespace Calculation.Evaluation;

public interface IEvaluator
{
    double Evaluate(INode node);
}