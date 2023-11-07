using Calculation.Node;

namespace Calculation.NotationParser;

public class InfixNotationParser : IParserStrategy
{
    public INode Parse(string expression)
    {
        var postfixExpression = Convert2Postfix(expression);
        var postfixNotationParser = new PostfixNotationParser();
        return postfixNotationParser.Parse(postfixExpression);
    }

    public string Convert2Postfix(string expression)
    {
        var queue = new Queue<string>();
        var stack = new Stack<string>();

        foreach (var t in expression.Split(' '))
            if (t == ",")
            {
                if (!stack.Contains("("))
                    throw new Exception();

                while (stack.First() != "(") queue.Enqueue(stack.Pop());
            }
            else if (CalculateUtility.IsPriorityOperator(t))
            {
                while (stack.Count > 0)
                {
                    var top = stack.First();
                    if (CalculateUtility.IsPriorityOperator(top) != true) break;

                    var op1 = CalculateUtility.PriorityOperatorsDictionary()[t];
                    var op2 = CalculateUtility.PriorityOperatorsDictionary()[top];

                    if (op1.leftAssoc)
                    {
                        if (op1.priority < op2.priority) break;
                    }
                    else
                    {
                        if (op1.priority <= op2.priority) break;
                    }

                    queue.Enqueue(stack.Pop());
                }

                stack.Push(t);
            }
            else
            {
                switch (t)
                {
                    case "(":
                        stack.Push(t);
                        break;
                    case ")" when !stack.Contains("("):
                        throw new InvalidOperationException("Unmatched closing parenthesis detected.");
                    case ")":
                    {
                        while (true)
                        {
                            var o = stack.Pop();
                            if (o == "(") break;
                            queue.Enqueue(o);
                        }

                        break;
                    }
                    default:
                        queue.Enqueue(t);
                        break;
                }
            }

        foreach (var o in stack)
            queue.Enqueue(o);

        return string.Join(" ", queue);
    }
}