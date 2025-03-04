using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO;

public class Calculator : ICalculator
{
    public double Compute(string expression)
    {
        Expression expressionCalculator = new Expression(expression);
        
        return expressionCalculator.calculate();
    }
}