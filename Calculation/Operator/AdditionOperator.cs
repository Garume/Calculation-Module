﻿namespace Calculation.Operator;

public sealed class AdditionOperator : IOperator
{
    public string Value => "+";

    public double PerformOperation(double left, double right)
    {
        return left + right;
    }
}