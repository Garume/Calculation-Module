namespace Calculation;

public class StringNotation : INotation
{
    private StringNotation(string stringNumber, NotationType notationType)
    {
        StringNumber = stringNumber;
        Notation = notationType;
    }

    public string StringNumber { get; }


    public NotationType Notation { get; }

    public static StringNotation CreateInfixNotation(string stringNumber)
    {
        return new StringNotation(stringNumber, NotationType.Infix);
    }

    public static StringNotation CreatePolishNotation(string stringNumber)
    {
        return new StringNotation(stringNumber, NotationType.Polish);
    }

    public static StringNotation CreateReversePolishNotation(string stringNumber)
    {
        return new StringNotation(stringNumber, NotationType.ReversePolish);
    }

    public StringNotation ConvertToReversePolishNotation()
    {
        if (Notation != NotationType.Infix)
            return this;
        var stringNumber = AnalyzeInFixNotation();
        return CreateInfixNotation(stringNumber);
    }

    private string AnalyzeInFixNotation()
    {
        var queue = new Queue<string>();
        var stack = new Stack<string>();

        foreach (var t in StringNumber.Split(' '))
            if (t == ",")
            {
                if (!stack.Contains("("))
                    throw new Exception();

                while (stack.First() != "(") queue.Enqueue(stack.Pop());
            }
            else if (CalculateUtility.IsPriorityOperator(t) == true)
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
                        throw new Exception();
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