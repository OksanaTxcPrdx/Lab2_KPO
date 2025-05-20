namespace Lab2_KPO.Services;

public abstract class CalculatorDecorator : ICalculator
{
    protected readonly ICalculator _calculator;

    public CalculatorDecorator(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public virtual double Compute(string expression)
    {
        return _calculator.Compute(expression);
    }
}