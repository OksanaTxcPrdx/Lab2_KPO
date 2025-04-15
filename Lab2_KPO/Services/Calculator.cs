using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO.Services;

public class Calculator : ICalculator
{
    public double Compute(string expression)
    {
        Expression expressionCalculator = new Expression(expression);

        if (expressionCalculator.checkSyntax())
        {
            return expressionCalculator.calculate();
        }

        throw new ArgumentException("Invalid expression " + expression);

    }
}