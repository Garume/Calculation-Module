namespace Calculation;

public sealed class NodeParser
{
    public NodeParser(StringNotation stringNotation)
    {
        StringNotation = stringNotation;
    }

    private StringNotation StringNotation { get; set; }
    private IEnumerable<string> Tokens => StringNotation.StringNumber.Split(' ');

    public bool TryParse(out StringNode? node)
    {
        try
        {
            node = Parse();
            return true;
        }
        catch (Exception e)
        {
            node = null;
            Console.WriteLine(e);
            return false;
        }
    }

    public StringNode Parse()
    {
        return StringNotation.Notation switch
        {
            NotationType.ReversePolish => ParseReversePolishNotation(),
            NotationType.Polish => ParsePolishNotation(),
            NotationType.Infix => ParseInFixNotation(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private StringNode ParseInFixNotation()
    {
        StringNotation = StringNotation.ConvertToReversePolishNotation();
        var node = ParseReversePolishNotation();
        return node;
    }


    private StringNode ParseReversePolishNotation()
    {
        var stack = new Stack<StringNode>();

        foreach (var token in Tokens)
            if (CalculateUtility.IsOperator(token))
            {
                var right = stack.Pop();
                var left = stack.Pop();
                var node = new StringNode(token, left, right);
                stack.Push(node);
            }
            else
            {
                var node = new StringNode(token);
                stack.Push(node);
            }

        return stack.Pop();
    }


    private StringNode ParsePolishNotation()
    {
        var stack = new Stack<StringNode>();
        var tokens = new Stack<string>(Tokens);

        while (tokens.Any())
        {
            var token = tokens.Pop();
            var node = new StringNode(token);
            if (CalculateUtility.IsOperator(token))
            {
                node.Left = stack.Pop();
                node.Right = stack.Pop();
            }

            stack.Push(node);
        }

        return stack.Pop();
    }
}