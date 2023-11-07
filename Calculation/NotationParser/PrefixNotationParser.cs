using Calculation.Node;
using Calculation.Operator;

namespace Calculation.NotationParser;

public sealed class PrefixNotationParser : IParserStrategy
{
    public INode Parse(string expression)
    {
        var stack = new Stack<INode>();
        var tokens = new Stack<string>(expression.Split(' '));

        while (tokens.Any())
        {
            var token = tokens.Pop();
            INode node;
            if (CalculateUtility.IsOperator(token))
            {
                var left = stack.Pop();
                var right = stack.Pop();
                var @operator = OperatorFactory.Create(token);
                node = new OperatorNode(@operator, left, right);
            }
            else
            {
                node = new OperandNode(token);
            }

            stack.Push(node);
        }

        return stack.Pop();
    }
}