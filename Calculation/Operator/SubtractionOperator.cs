﻿namespace Calculation.Operator;

public sealed class SubtractionOperator : IOperator
{
    private static string OperatorValue => "-";
    public string Value => OperatorValue;

    public double PerformOperation(double left, double right)
    {
        return left - right;
    }
}