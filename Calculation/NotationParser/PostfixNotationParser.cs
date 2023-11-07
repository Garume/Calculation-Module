using Calculation.Node;
using Calculation.Operator;

namespace Calculation.NotationParser;

public sealed class PostfixNotationParser : IParserStrategy
{
    public INode Parse(string expression)
    {
        var stack = new Stack<INode>();

        foreach (var token in expression.Split(' '))
            if (CalculateUtility.IsOperator(token))
            {
                var right = stack.Pop();
                var left = stack.Pop();
                var @operator = OperatorFactory.Create(token);
                var node = new OperatorNode(@operator, left, right);
                stack.Push(node);
            }
            else
            {
                var node = new OperandNode(token);
                stack.Push(node);
            }

        return stack.Pop();
    }
}