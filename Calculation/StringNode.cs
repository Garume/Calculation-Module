namespace Calculation;

public class StringNode : Node<string>
{
    public StringNode(string value, StringNode left, StringNode right) : base(value, left, right)
    {
    }

    public StringNode(string value) : base(value)
    {
    }

    public override double Evaluate()
    {
        if (Value == "") return 0;

        if (CalculateUtility.IsOperator(Value))
        {
            var left = Left?.Evaluate() ?? 0;
            var right = Right?.Evaluate() ?? 0;

            if (Value == "/" && right == 0)
                throw new DivideByZeroException();

            return Value switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                _ => throw new InvalidOperationException("Invalid operator")
            };
        }

        if (!double.TryParse(Value, out var number))
            throw new FormatException();

        if (double.IsInfinity(number))
            throw new OverflowException();

        return number;
    }
}